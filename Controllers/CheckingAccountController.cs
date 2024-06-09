using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CheckingAccount>>> GetCheckingAccounts()
    {
        return await _context.CheckingAccounts.ToListAsync();
    }

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

    // Implement other CRUD operations as needed
}
