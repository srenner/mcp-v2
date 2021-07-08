using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mcp.Server.Data;
using mcp.Server.Models;
using System.Security.Claims;
using mcp.Shared.ViewModels;
using mcp.Server.ModelExtensions;
using mcp.Shared.Enum;

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

        [HttpGet("project/{projectID}")]
        public async Task<ActionResult<IEnumerable<ProjectPartViewModel>>> GetPartsForProject(int projectID)
        {
            if(DoesUserOwnProject(projectID))
            {
                var parts = await _context.ProjectPart.Where(w => w.ProjectID == projectID).ToListAsync();
                return parts.ToViewModel();
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpGet("shop/{vehicleID}")]
        public async Task<ActionResult<List<ProjectPartViewModel>>> GetPartShoppingList(int vehicleID)
        {
            var parts = await _context.ProjectPart
                .Include(i => i.Project)
                .Where(w => w.Project.VehicleID == vehicleID)
                .Where(w => w.Project.ProjectStatusID == (int)ProjectStatusEnum.Active)
                .Where(w => w.QuantityPurchased < w.Quantity)
                .OrderBy(o => o.ProjectID)
                .ToListAsync();

            return parts.ToViewModel();
        }

        // PUT: api/ProjectPart/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectPart(int id, [FromBody] ProjectPart projectPart)
        {
            if(DoesUserOwnPart(projectPart.ProjectPartID))
            {
                if (id != projectPart.ProjectPartID)
                {
                    return BadRequest();
                }

                if(projectPart.QuantityPurchased > 0 || projectPart.QuantityInstalled > 0)
                {
                    projectPart.ExcludeFromTotal = false;
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
            }
            
            return NoContent();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of project that parts are moving to</param>
        /// <param name="parts">list of parts (only move when IsSelected == true)</param>
        /// <returns></returns>
        [HttpPut("move/{id}")]
        public async Task<IActionResult> MoveParts(int id, [FromBody] List<ProjectPartViewModel> parts)
        {
            if(DoesUserOwnProject(id))
            {
                foreach(var partViewModel in parts)
                {
                    if(partViewModel.IsSelected && DoesUserOwnPart(partViewModel.ProjectPartID))
                    {
                        var part = await _context.ProjectPart.FindAsync(partViewModel.ProjectPartID);
                        part.ProjectID = id;
                        _context.Entry(part).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                    }
                }
            }
            else
            {
                return Unauthorized();
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
