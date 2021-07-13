using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mcp.Server.Data;
using mcp.Server.Models;
using mcp.Shared.ViewModels;
using mcp.Server.ModelExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using mcp.Shared.Enum;

namespace mcp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public VehicleController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Vehicle
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehicle>>> GetVehicle()
        {
            string username = HttpContext.User.Identity.Name;

            return await _context.Vehicle.ToListAsync();
        }

        // GET: api/Vehicle/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleViewModel>> GetVehicle(int id)
        {
            var vehicle = await _context.Vehicle.FindAsync(id);


            if (vehicle == null || vehicle.IsDeleted)
            {
                return NotFound();
            }

            return vehicle.ToViewModel();
        }

        [HttpGet("shop/{vehicleID}")]
        public async Task<ActionResult<List<ProjectShoppingListViewModel>>> GetShoppingList(int vehicleID)
        {
            var t = await _context.ProjectPart
                .Include(i => i.Project)
                .Where(w => w.Project.VehicleID == vehicleID)
                .Where(w => w.Project.ProjectStatusID == (int)ProjectStatusEnum.Active)
                .Where(w => w.QuantityPurchased < w.Quantity)
                .OrderBy(o => o.ProjectID)
                .ToListAsync();

            try
            {
                var pg = await _context.ProjectPart
                    .Include(i => i.Project)
                    .Where(w => w.Project.VehicleID == vehicleID)
                    .Where(w => w.Project.ProjectStatusID == (int)ProjectStatusEnum.Active)
                    .Where(w => w.QuantityPurchased < w.Quantity)
                    .ToListAsync();

                throw new NotImplementedException();

                var grouped = pg.GroupBy(g => g.Project).ToList();
            }
            catch(Exception ex)
            {
                throw;
            }

            var partGroups = await _context.ProjectPart
                .Include(i => i.Project)
                .Where(w => w.Project.VehicleID == vehicleID)
                .Where(w => w.Project.ProjectStatusID == (int)ProjectStatusEnum.Active)
                .Where(w => w.QuantityPurchased < w.Quantity)
                .OrderBy(o => o.ProjectID)
                .GroupBy(g => g.ProjectID)
                .ToListAsync();

            var vm = new List<ProjectShoppingListViewModel>();

            //loop through projects
            foreach(var group in partGroups)
            {
                var firstPart = group.FirstOrDefault();
                if(firstPart != null)
                {
                    var projectList = new ProjectShoppingListViewModel();
                    projectList.PendingPartCost = 0.00M;
                    projectList.ProjectID = firstPart.ProjectID;
                    projectList.ProjectName = firstPart.Project?.Name;

                    projectList.Parts = new List<ProjectPartViewModel>();


                    foreach (var part in group)
                    {
                        projectList.Parts.Add(part.ToViewModel());
                        if (part.Price.HasValue)
                        {
                            var quantityToBuy = part.Quantity - part.QuantityPurchased;
                            projectList.PendingPartCost += (part.Price.Value * quantityToBuy);
                        }
                        if (part.ExtraCost.HasValue)
                        {
                            projectList.PendingPartCost += part.ExtraCost.Value;
                        }
                    }
                    vm.Add(projectList);
                }

                
            }

            return vm;
        }

        [HttpGet("listitems")]
        public async Task<ActionResult<List<VehicleListItemViewModel>>> GetVehicleListItems()
        {
            var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var vehicles = await _context.Vehicle
                .Include(e => e.Projects.Where(w => w.IsDeleted == false).Where(w => w.ParentProjectID == null))
                .Include(e => e.Modifications)
                .Where(w => w.UserID == userID)
                .Where(w => w.IsDeleted == false)
                .Where(w => w.IsSold == false)
                .ToListAsync();

            if (vehicles == null)
            {
                return NotFound();
            }

            return vehicles.ToListItemViewModel();
                
        }

        [HttpGet("listitem/{id}")]
        [Authorize]
        public async Task<ActionResult<VehicleListItemViewModel>> GetVehicleListItem(int id)
        {


            var vehicle = await _context.Vehicle
                .Include(e => e.Projects)
                .Include(e => e.Modifications)
                .Where(w => w.IsDeleted == false)
                .FirstOrDefaultAsync(e => e.VehicleID == id);

            if(vehicle == null)
            {
                return NotFound();
            }

            return vehicle.ToListItemViewModel();
        }

        // PUT: api/Vehicle/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicle(int id, Vehicle vehicle)
        {
            if (id != vehicle.VehicleID)
            {
                return BadRequest();
            }

            _context.Entry(vehicle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleExists(id))
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

        // POST: api/Vehicle
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vehicle>> PostVehicle(Vehicle vehicle)
        {
            var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            vehicle.UserID = userID;

            _context.Vehicle.Add(vehicle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVehicle", new { id = vehicle.VehicleID }, vehicle);
        }

        // DELETE: api/Vehicle/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            var vehicle = await _context.Vehicle.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            _context.Vehicle.Remove(vehicle);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VehicleExists(int id)
        {
            return _context.Vehicle.Any(e => e.VehicleID == id);
        }
    }
}
