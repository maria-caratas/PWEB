namespace WebApplication8;


using Microsoft.AspNetCore.Authorization;
using WebApplication8.Data;
using WebApplication8.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class CapitoleController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    public CapitoleController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    // [Authorize(Roles = "User")]
    public List<CapitolInvatare> GetCapitole()
    {
        return _dbContext.Capitole.ToList();
    }

    [HttpGet("{id}")]
    // Authorize(Roles = "User")]
    public ActionResult<CapitolInvatare> GetCapitolById(int id)
    {
        var ci = _dbContext.Capitole.Find(id);
        if (ci == null)
        {
            return NotFound();
        }
        return ci;
    }

    [HttpPost]
    // [Authorize(Roles = "User")]
   // [Authorize(Policy = "RequireAdministratorRole")]
    public ActionResult<Todo> CreeazaCapitol([FromBody] CapitolInvatare ci)
    {
        _dbContext.Capitole.Add(ci);
        _dbContext.SaveChanges();
        return CreatedAtAction(nameof(GetCapitolById), new { id = ci.CapitolInvatareId }, ci);
    }

    [HttpPut("{id}")]
    // [Authorize(Roles = "User")]
   // [Authorize(Policy = "RequireAdministratorRole")]
    public IActionResult UpdateCapitol(int id, [FromBody] CapitolInvatare capitolUpdatat)
    {
        var ci = _dbContext.Capitole.Find(id);
        if (ci == null)
        {
            return NotFound();
        }

        ci.Titlu = capitolUpdatat.Titlu;
        ci.Continut = capitolUpdatat.Continut;
        _dbContext.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    // [Authorize(Roles = "User")]
    // [Authorize(Policy = "RequireAdministratorRole")]
    public IActionResult DeleteCapitol(int id)
    {
        var ci = _dbContext.Capitole.Find(id);
        if (ci == null)
        {
            return NotFound();
        }

        _dbContext.Capitole.Remove(ci);
        _dbContext.SaveChanges();
        return NoContent();
    }
}
