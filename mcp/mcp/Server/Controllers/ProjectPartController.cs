﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mcp.Server.Data;
using mcp.Server.Models;
using System.Security.Claims;

namespace mcp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectPartController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProjectPartController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ProjectPart
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectPart>>> GetProjectPart()
        {
            return await _context.ProjectPart.ToListAsync();
        }

        // GET: api/ProjectPart/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectPart>> GetProjectPart(int id)
        {
            var projectPart = await _context.ProjectPart.FindAsync(id);

            if (projectPart == null)
            {
                return NotFound();
            }

            return projectPart;
        }

        // PUT: api/ProjectPart/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectPart(int id, [FromBody] ProjectPart projectPart)
        {
            if (id != projectPart.ProjectPartID)
            {
                return BadRequest();
            }

            _context.Entry(projectPart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectPartExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ProjectPart
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProjectPart>> PostProjectPart(ProjectPart projectPart)
        {
            if(DoesUserOwnProject(projectPart.ProjectID))
            {
                _context.ProjectPart.Add(projectPart);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetProjectPart", new { id = projectPart.ProjectPartID }, projectPart);
            }
            else
            {
                //todo use proper response
                return null;
            }

        }

        // DELETE: api/ProjectPart/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectPart(int id)
        {
            if(DoesUserOwnPart(id))
            {
                var projectPart = await _context.ProjectPart.FindAsync(id);
                if (projectPart == null)
                {
                    return NotFound();
                }

                _context.ProjectPart.Remove(projectPart);
                await _context.SaveChangesAsync();
            }
            return NoContent();
        }

        private bool ProjectPartExists(int id)
        {
            return _context.ProjectPart.Any(e => e.ProjectPartID == id);
        }

        private bool DoesUserOwnPart(int projectPartID)
        {
            var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return _context.ProjectPart
                    .Include(i => i.Project)
                    .ThenInclude(i => i.Vehicle)
                    .Any(a => a.Project.Vehicle.UserID == userID);
        }

        private bool DoesUserOwnProject(int projectID)
        {
            var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return _context.Project
                .Include(i => i.Vehicle)
                .Any(a => a.Vehicle.UserID == userID);
        }
    }
}
