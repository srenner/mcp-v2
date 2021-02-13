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

namespace mcp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        //private readonly UserManager<IdentityUser> _userManager;

        public VehicleController(ApplicationDbContext context)//, UserManager<IdentityUser> userManager)
        {
            _context = context;
            //_userManager = userManager;
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
        public async Task<ActionResult<Vehicle>> GetVehicle(int id)
        {
            var vehicle = await _context.Vehicle.FindAsync(id);


            if (vehicle == null)
            {
                return NotFound();
            }

            return vehicle;
        }

        [HttpGet("listitems")]
        public async Task<ActionResult<List<VehicleListItemViewModel>>> GetVehicleListItems()
        {
            var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var vehicles = await _context.Vehicle
                .Include(e => e.Projects)
                .Include(e => e.Modifications)
                .Where(w => w.UserID == userID)
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
