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
    public class ProjectController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProjectController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Project
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> GetProject()
        {
            return await _context.Project.ToListAsync();
        }

        [HttpGet("active/{id}")]
        public async Task<ActionResult<List<ProjectListItemViewModel>>> GetActiveProjects(int id)
        {
            try
            {
                var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var now = DateTime.Now;
                var projects = await _context.Project
                    .Include(i => i.Vehicle)
                    .Include(i => i.Parts)
                    .Where(w => w.VehicleID == id)
                    .Where(w => w.Vehicle.UserID == userID)
                    .Where(w => w.IsDeleted == false)
                    .Where(w => w.ParentProjectID == null)
                    .Where(w => w.ProjectStatusID == (int)ProjectStatusEnum.Active)
                    .ToListAsync();
                return projects.ToListItemViewModel();
            }

            catch(Exception ex)
            {
                return null;
            }
        }

        [HttpGet("backlog/{id}")]
        public async Task<ActionResult<List<ProjectListItemViewModel>>> GetBacklogProjects(int id)
        {
            try
            {
                var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var now = DateTime.Now;
                var projects = await _context.Project
                    .Include(i => i.Vehicle)
                    .Include(i => i.Parts)
                    .Include(i => i.Dependencies)
                    .ThenInclude(i => i.DependsOnProject)
                    .Where(w => w.VehicleID == id)
                    .Where(w => w.Vehicle.UserID == userID)
                    .Where(w => w.IsDeleted == false)
                    .Where(w => w.ParentProjectID == null)
                    .Where(w => w.ProjectStatusID == (int)ProjectStatusEnum.Backlog)
                    .ToListAsync();
                return projects.ToListItemViewModel();
            }
            catch(Exception ex)
            {
                throw;
            }
            
        }

        [HttpGet("complete/{id}")]
        public async Task<ActionResult<List<ProjectListItemViewModel>>> GetCompleteProjects(int id)
        {
            var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var now = DateTime.Now;
            var projects = await _context.Project
                .Include(i => i.Vehicle)
                .Include(i => i.Parts)
                .Where(w => w.VehicleID == id)
                .Where(w => w.Vehicle.UserID == userID)
                .Where(w => w.ProjectStatusID == (int)ProjectStatusEnum.Complete)
                .Where(w => w.IsDeleted == false)
                .Where(w => w.ParentProjectID == null)
                .ToListAsync();
            return projects.ToListItemViewModel();;
        }

        // GET: api/Project/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectViewModel>> GetProject(int id)
        {
            try
            {
                var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);

                var project = await _context.Project
                    .Include(i => i.Vehicle)
                    .Include(i => i.Parts)
                    .Include(i => i.ChecklistItems)
                    .Include(i => i.UserCategory)
                    .Include(i => i.Dependencies)
                        .ThenInclude(i => i.DependsOnProject)
                    .Include(i => i.DependenciesOf)
                        .ThenInclude(i => i.Project)
                    .Include(i => i.SubProjects)
                    .Include(i => i.ParentProject)
                    .Where(w => w.ProjectID == id)
                    .Where(w => w.Vehicle.UserID == userID)
                    .Where(w => w.IsDeleted == false)
                    .FirstOrDefaultAsync();

                if (project == null)
                {
                    return NotFound();
                }

                return project.ToViewModel();
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        [HttpGet("basic/{id}")]
        public async Task<ActionResult<ProjectViewModel>> GetProjectBasics(int id)
        {
            try
            {
                var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);

                var project = await _context.Project
                    .Where(w => w.ProjectID == id)
                    .Where(w => w.Vehicle.UserID == userID)
                    .Where(w => w.IsDeleted == false)
                    .FirstOrDefaultAsync();

                if (project == null)
                {
                    return NotFound();
                }

                return project.ToViewModel();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // PUT: api/Project/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProject(int id, Project project)
        {
            if (id != project.ProjectID)
            {
                return BadRequest();
            }

            _context.Entry(project).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(id))
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

        // POST: api/Project
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Project>> PostProject(Project project)
        {
            _context.Project.Add(project);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProject", new { id = project.ProjectID }, project);
        }

        // DELETE: api/Project/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var project = await _context.Project.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            _context.Project.Remove(project);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProjectExists(int id)
        {
            return _context.Project.Any(e => e.ProjectID == id);
        }
    }
}
