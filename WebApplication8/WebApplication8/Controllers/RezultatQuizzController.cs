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
    public class RezultatQuizzController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RezultatQuizzController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/RezultatQuizz
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RezultatQuizz>>> GetRezultatQuizz()
        {
            return await _context.Rezultate.ToListAsync();
        }

        // GET: api/RezultatQuizz/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RezultatQuizz>> GetRezultatQuizz(int id)
        {
            var rezultatQuizz = await _context.Rezultate.FindAsync(id);

            if (rezultatQuizz == null)
            {
                return NotFound();
            }

            return rezultatQuizz;
        }

        // POST: api/RezultatQuizz
        [HttpPost]
        public async Task<ActionResult<RezultatQuizz>> PostRezultatQuizz(RezultatQuizz rezultatQuizz)
        {
            _context.Rezultate.Add(rezultatQuizz);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRezultatQuizz", new { id = rezultatQuizz.RezultatQuizzId }, rezultatQuizz);
        }

        // PUT: api/RezultatQuizz/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRezultatQuizz(int id, RezultatQuizz rezultatQuizz)
        {
            if (id != rezultatQuizz.RezultatQuizzId)
            {
                return BadRequest();
            }

            _context.Entry(rezultatQuizz).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RezultatQuizzExists(id))
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

        // DELETE: api/RezultatQuizz/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRezultatQuizz(int id)
        {
            var rezultatQuizz = await _context.Rezultate.FindAsync(id);
            if (rezultatQuizz == null)
            {
                return NotFound();
            }

            _context.Rezultate.Remove(rezultatQuizz);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RezultatQuizzExists(int id)
        {
            return _context.Rezultate.Any(e => e.RezultatQuizzId == id);
        }
    }
}
