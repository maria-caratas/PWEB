using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication8.Data;
using WebApplication8.Models;

namespace WebApplication8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IstoricRezultateController : ControllerBase
    {
        private readonly AppDbContext _context;

        public IstoricRezultateController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/IstoricRezultate
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IstoricRezultate>>> GetIstoricRezultate()
        {
            return await _context.Istorice.ToListAsync();
        }

        // GET: api/IstoricRezultate/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IstoricRezultate>> GetIstoricRezultate(int id)
        {
            var istoricRezultate = await _context.Istorice.FindAsync(id);

            if (istoricRezultate == null)
            {
                return NotFound();
            }

            return istoricRezultate;
        }

        // POST: api/IstoricRezultate
        [HttpPost]
        public async Task<ActionResult<IstoricRezultate>> PostIstoricRezultate(IstoricRezultate istoricRezultate)
        {
            _context.Istorice.Add(istoricRezultate);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetIstoricRezultate), new { id = istoricRezultate.Id }, istoricRezultate);
        }

        // DELETE: api/IstoricRezultate/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIstoricRezultate(int id)
        {
            var istoricRezultate = await _context.Istorice.FindAsync(id);
            if (istoricRezultate == null)
            {
                return NotFound();
            }

            _context.Istorice.Remove(istoricRezultate);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IstoricRezultateExists(int id)
        {
            return _context.Istorice.Any(e => e.Id == id);
        }
    }
}
