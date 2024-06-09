using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CD>>> GetCDs()
    {
        return await _context.CDs.ToListAsync();
    }

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

    // Implement other CRUD operations as needed
}
