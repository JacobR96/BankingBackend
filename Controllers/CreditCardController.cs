using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

    // GET: api/CreditCard
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CreditCard>>> GetCreditCards()
    {
        return await _context.CreditCards.ToListAsync();
    }

    // GET: api/CreditCard/5
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

    // POST: api/CreditCard
    [HttpPost]
    public async Task<ActionResult<CreditCard>> PostCreditCard(CreditCard creditCard)
    {
        _context.CreditCards.Add(creditCard);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetCreditCard", new { id = creditCard.CreditCardId }, creditCard);
    }

    // PUT: api/CreditCard/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCreditCard(int id, CreditCard creditCard)
    {
        if (id != creditCard.CreditCardId)
        {
            return BadRequest();
        }

        _context.Entry(creditCard).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CreditCardExists(id))
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

    // DELETE: api/CreditCard/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCreditCard(int id)
    {
        var creditCard = await _context.CreditCards.FindAsync(id);
        if (creditCard == null)
        {
            return NotFound();
        }

        _context.CreditCards.Remove(creditCard);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool CreditCardExists(int id)
    {
        return _context.CreditCards.Any(e => e.CreditCardId == id);
    }
}
