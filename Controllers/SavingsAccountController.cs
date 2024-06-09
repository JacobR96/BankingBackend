using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SavingsAccount>>> GetSavingsAccounts()
    {
        return await _context.SavingsAccounts.ToListAsync();
    }

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

    // Implement other CRUD operations as needed
}
