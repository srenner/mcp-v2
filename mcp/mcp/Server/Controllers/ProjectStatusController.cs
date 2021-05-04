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
using mcp.Shared.Enum;

namespace mcp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectStatusController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProjectStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ProjectStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectStatus>>> GetProjectStatus()
        {
            return await _context.ProjectStatus.ToListAsync();
        }

        // GET: api/ProjectStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectStatus>> GetProjectStatus(int id)
        {
            var projectStatus = await _context.ProjectStatus.FindAsync(id);

            if (projectStatus == null)
            {
                return NotFound();
            }

            return projectStatus;
        }

        [HttpPut("makeactive/{projectID}")]
        public async Task<IActionResult> MakeProjectActive(int projectID)
        {
            if(DoesUserOwnProject(projectID))
            {
                var project = await _context.Project.FindAsync(projectID);
                project.ProjectStatusID = (int)ProjectStatusEnum.Active;
                project.LastUpdate = DateTime.Now;
                _context.Entry(project).State = EntityState.Modified;
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw;
                }
                return NoContent();
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPut("sendtobacklog/{projectID}")]
        public async Task<IActionResult> MakeProjectBacklog(int projectID)
        {
            if (DoesUserOwnProject(projectID))
            {
                var project = await _context.Project.FindAsync(projectID);
                project.ProjectStatusID = (int)ProjectStatusEnum.Backlog;
                project.LastUpdate = DateTime.Now;
                _context.Entry(project).State = EntityState.Modified;
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw;
                }
                return NoContent();
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPut("sendtocomplete/{projectID}")]
        public async Task<IActionResult> MakeProjectComplete(int projectID)
        {
            if (DoesUserOwnProject(projectID))
            {
                var project = await _context.Project.FindAsync(projectID);
                project.ProjectStatusID = (int)ProjectStatusEnum.Complete;
                project.LastUpdate = DateTime.Now;
                _context.Entry(project).State = EntityState.Modified;
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw;
                }
                return NoContent();
            }
            else
            {
                return Unauthorized();
            }
        }

        // PUT: api/ProjectStatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectStatus(int id, ProjectStatus projectStatus)
        {
            if (id != projectStatus.ProjectStatusID)
            {
                return BadRequest();
            }

            _context.Entry(projectStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectStatusExists(id))
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

        //// POST: api/ProjectStatus
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<ProjectStatus>> PostProjectStatus(ProjectStatus projectStatus)
        //{
        //    _context.ProjectStatus.Add(projectStatus);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (ProjectStatusExists(projectStatus.ProjectStatusID))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction("GetProjectStatus", new { id = projectStatus.ProjectStatusID }, projectStatus);
        //}

        //// DELETE: api/ProjectStatus/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteProjectStatus(int id)
        //{
        //    var projectStatus = await _context.ProjectStatus.FindAsync(id);
        //    if (projectStatus == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.ProjectStatus.Remove(projectStatus);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool ProjectStatusExists(int id)
        {
            return _context.ProjectStatus.Any(e => e.ProjectStatusID == id);
        }

        //todo move to common location
        private bool DoesUserOwnProject(int projectID)
        {
            var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return _context.Project
                .Include(i => i.Vehicle)
                .Any(a => a.Vehicle.UserID == userID);
        }
    }
}
