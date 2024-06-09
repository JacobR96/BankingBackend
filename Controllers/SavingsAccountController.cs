using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class SavingsAccountController : ControllerBase
{
    private readonly BankingContext _context;

    public SavingsAccountController(BankingContext context)
    {
        _context = context;
    }

    // GET: api/SavingsAccount
    [HttpGet]
    public async Task<ActionResult<IEnumerable<SavingsAccount>>> GetSavingsAccounts()
    {
        return await _context.SavingsAccounts.ToListAsync();
    }

    // GET: api/SavingsAccount/5
    [HttpGet("{id}")]
    public async Task<ActionResult<SavingsAccount>> GetSavingsAccount(int id)
    {
        var savingsAccount = await _context.SavingsAccounts.FindAsync(id);

        if (savingsAccount == null)
        {
            return NotFound();
        }

        return savingsAccount;
    }

    // POST: api/SavingsAccount
    [HttpPost]
    public async Task<ActionResult<SavingsAccount>> PostSavingsAccount(SavingsAccount savingsAccount)
    {
        _context.SavingsAccounts.Add(savingsAccount);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetSavingsAccount", new { id = savingsAccount.SavingsAccountId }, savingsAccount);
    }

    // PUT: api/SavingsAccount/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutSavingsAccount(int id, SavingsAccount savingsAccount)
    {
        if (id != savingsAccount.SavingsAccountId)
        {
            return BadRequest();
        }

        _context.Entry(savingsAccount).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!SavingsAccountExists(id))
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

    // DELETE: api/SavingsAccount/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSavingsAccount(int id)
    {
        var savingsAccount = await _context.SavingsAccounts.FindAsync(id);
        if (savingsAccount == null)
        {
            return NotFound();
        }

        _context.SavingsAccounts.Remove(savingsAccount);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool SavingsAccountExists(int id)
    {
        return _context.SavingsAccounts.Any(e => e.SavingsAccountId == id);
    }
}
