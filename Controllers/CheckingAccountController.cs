using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class CheckingAccountController : ControllerBase
{
    private readonly BankingContext _context;

    public CheckingAccountController(BankingContext context)
    {
        _context = context;
    }

    // GET: api/CheckingAccount
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CheckingAccount>>> GetCheckingAccounts()
    {
        return await _context.CheckingAccounts.ToListAsync();
    }

    // GET: api/CheckingAccount/5
    [HttpGet("{id}")]
    public async Task<ActionResult<CheckingAccount>> GetCheckingAccount(int id)
    {
        var checkingAccount = await _context.CheckingAccounts.FindAsync(id);

        if (checkingAccount == null)
        {
            return NotFound();
        }

        return checkingAccount;
    }

    // POST: api/CheckingAccount
    [HttpPost]
    public async Task<ActionResult<CheckingAccount>> PostCheckingAccount(CheckingAccount checkingAccount)
    {
        _context.CheckingAccounts.Add(checkingAccount);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetCheckingAccount", new { id = checkingAccount.CheckingAccountId }, checkingAccount);
    }

    // PUT: api/CheckingAccount/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCheckingAccount(int id, CheckingAccount checkingAccount)
    {
        if (id != checkingAccount.CheckingAccountId)
        {
            return BadRequest();
        }

        _context.Entry(checkingAccount).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CheckingAccountExists(id))
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

    // DELETE: api/CheckingAccount/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCheckingAccount(int id)
    {
        var checkingAccount = await _context.CheckingAccounts.FindAsync(id);
        if (checkingAccount == null)
        {
            return NotFound();
        }

        _context.CheckingAccounts.Remove(checkingAccount);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool CheckingAccountExists(int id)
    {
        return _context.CheckingAccounts.Any(e => e.CheckingAccountId == id);
    }
}
