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

namespace mcp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserCategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/UserCategory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserCategoryViewModel>>> GetUserCategory()
        {
            var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var categories = await _context.UserCategory
                .Include(i => i.BaseCategory)
                .Where(w => w.UserID == userID)
                .Where(w => w.IsDeleted == false)
                .OrderBy(o => o.SortOrder)
                .ThenBy(o => o.Name)
                .ToListAsync();

            return categories.ToViewModel();
        }

        // GET: api/UserCategory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserCategory>> GetUserCategory(int id)
        {
            var userCategory = await _context.UserCategory.FindAsync(id);

            if (userCategory == null)
            {
                return NotFound();
            }

            return userCategory;
        }

        // PUT: api/UserCategory/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserCategory(int id, UserCategory userCategory)
        {
            if (id != userCategory.UserCategoryID)
            {
                return BadRequest();
            }

            _context.Entry(userCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserCategoryExists(id))
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

        // POST: api/UserCategory
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserCategory>> PostUserCategory(UserCategory userCategory)
        {
            _context.UserCategory.Add(userCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserCategory", new { id = userCategory.UserCategoryID }, userCategory);
        }

        // DELETE: api/UserCategory/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserCategory(int id)
        {
            var userCategory = await _context.UserCategory.FindAsync(id);
            if (userCategory == null)
            {
                return NotFound();
            }

            _context.UserCategory.Remove(userCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserCategoryExists(int id)
        {
            return _context.UserCategory.Any(e => e.UserCategoryID == id);
        }
    }
}
