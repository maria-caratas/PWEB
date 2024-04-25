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
    public class UtilizatorController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UtilizatorController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Utilizator
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Utilizator>>> GetUtilizatori()
        {
            return await _context.Utilizatori.ToListAsync();
        }

        // GET: api/Utilizator/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Utilizator>> GetUtilizator(int id)
        {
            var utilizator = await _context.Utilizatori.FindAsync(id);

            if (utilizator == null)
            {
                return NotFound();
            }

            return utilizator;
        }

        // POST: api/Utilizator
        [HttpPost]
        public async Task<ActionResult<Utilizator>> PostUtilizator(Utilizator utilizator)
        {
            _context.Utilizatori.Add(utilizator);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUtilizator", new { id = utilizator.UtilizatorId }, utilizator);
        }

        // PUT: api/Utilizator/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUtilizator(int id, Utilizator utilizator)
        {
            if (id != utilizator.UtilizatorId)
            {
                return BadRequest();
            }

            _context.Entry(utilizator).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UtilizatorExists(id))
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

        // DELETE: api/Utilizator/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUtilizator(int id)
        {
            var utilizator = await _context.Utilizatori.FindAsync(id);
            if (utilizator == null)
            {
                return NotFound();
            }

            _context.Utilizatori.Remove(utilizator);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UtilizatorExists(int id)
        {
            return _context.Utilizatori.Any(e => e.UtilizatorId == id);
        }
    }
}
