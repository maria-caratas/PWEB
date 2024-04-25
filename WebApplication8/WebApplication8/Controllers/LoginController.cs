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
    public class LoginController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LoginController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/login
        [HttpPost]
        public async Task<ActionResult<Utilizator>> Login(String utilizator, String parola)
        {
            foreach (Utilizator u in _context.Utilizatori)
            {
                if (u.NumeUtilizator == utilizator && u.Parola == parola)
                {
                    return CreatedAtAction("Login", true, "logat");

                }
            }

            return CreatedAtAction("Login", false, "nu");
        }

        private bool UtilizatorExists(int id)
        {
            return _context.Utilizatori.Any(e => e.UtilizatorId == id);
        }
    }
}
