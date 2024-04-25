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
    public class IntrebariController : ControllerBase
    {
        private readonly AppDbContext _context;

        public IntrebariController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/IntrebariQuizz
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IntrebariQuizz>>> GetIntrebariQuizz()
        {
            return await _context.Intrebari.ToListAsync();
        }

        // GET: api/IntrebariQuizz/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IntrebariQuizz>> GetIntrebariQuizz(int id)
        {
            var intrebareQuizz = await _context.Intrebari.FindAsync(id);

            if (intrebareQuizz == null)
            {
                return NotFound();
            }

            return intrebareQuizz;
        }

        // POST: api/IntrebariQuizz
        [HttpPost]
        public async Task<ActionResult<IntrebariQuizz>> PostIntrebariQuizz(IntrebariQuizz intrebariQuizz)
        {
            _context.Intrebari.Add(intrebariQuizz);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIntrebariQuizz", new { id = intrebariQuizz.IntrebareId }, intrebariQuizz);
        }

        // PUT: api/IntrebariQuizz/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIntrebariQuizz(int id, IntrebariQuizz intrebariQuizz)
        {
            if (id != intrebariQuizz.IntrebareId)
            {
                return BadRequest();
            }

            _context.Entry(intrebariQuizz).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IntrebariQuizzExists(id))
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

        // DELETE: api/IntrebariQuizz/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIntrebariQuizz(int id)
        {
            var intrebariQuizz = await _context.Intrebari.FindAsync(id);
            if (intrebariQuizz == null)
            {
                return NotFound();
            }

            _context.Intrebari.Remove(intrebariQuizz);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IntrebariQuizzExists(int id)
        {
            return _context.Intrebari.Any(e => e.IntrebareId == id);
        }
    }
}
