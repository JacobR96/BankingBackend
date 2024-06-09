using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class CreditCardController : ControllerBase
{
    private readonly BankingContext _context;

    public CreditCardController(BankingContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CreditCard>>> GetCreditCards()
    {
        return await _context.CreditCards.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CreditCard>> GetCreditCard(int id)
    {
        var creditCard = await _context.CreditCards.FindAsync(id);

        if (creditCard == null)
        {
            return NotFound();
        }

        return creditCard;
    }

    // Implement other CRUD operations as needed
}
