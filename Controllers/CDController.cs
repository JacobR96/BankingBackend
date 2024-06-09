using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class CDController : ControllerBase
{
    private readonly BankingContext _context;

    public CDController(BankingContext context)
    {
        _context = context;
    }

    // GET: api/CD
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CD>>> GetCDs()
    {
        return await _context.CDs.ToListAsync();
    }

    // GET: api/CD/5
    [HttpGet("{id}")]
    public async Task<ActionResult<CD>> GetCD(int id)
    {
        var cd = await _context.CDs.FindAsync(id);

        if (cd == null)
        {
            return NotFound();
        }

        return cd;
    }

    // POST: api/CD
    [HttpPost]
    public async Task<ActionResult<CD>> PostCD(CD cd)
    {
        _context.CDs.Add(cd);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetCD", new { id = cd.CDId }, cd);
    }

    // PUT: api/CD/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCD(int id, CD cd)
    {
        if (id != cd.CDId)
        {
            return BadRequest();
        }

        _context.Entry(cd).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CDExists(id))
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

    // DELETE: api/CD/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCD(int id)
    {
        var cd = await _context.CDs.FindAsync(id);
        if (cd == null)
        {
            return NotFound();
        }

        _context.CDs.Remove(cd);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool CDExists(int id)
    {
        return _context.CDs.Any(e => e.CDId == id);
    }
}
