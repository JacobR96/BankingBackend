using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class StockController : ControllerBase
{
    private readonly BankingContext _context;

    public StockController(BankingContext context)
    {
        _context = context;
    }

    // GET: api/Stock
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Stock>>> GetStocks()
    {
        return await _context.Stocks.ToListAsync();
    }

    // GET: api/Stock/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Stock>> GetStock(int id)
    {
        var stock = await _context.Stocks.FindAsync(id);

        if (stock == null)
        {
            return NotFound();
        }

        return stock;
    }

    // POST: api/Stock
    [HttpPost]
    public async Task<ActionResult<Stock>> PostStock(Stock stock)
    {
        _context.Stocks.Add(stock);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetStock", new { id = stock.Id }, stock);
    }

    // PUT: api/Stock/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutStock(int id, Stock stock)
    {
        if (id != stock.Id)
        {
            return BadRequest();
        }

        _context.Entry(stock).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!StockExists(id))
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

    // DELETE: api/Stock/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStock(int id)
    {
        var stock = await _context.Stocks.FindAsync(id);
        if (stock == null)
        {
            return NotFound();
        }

        _context.Stocks.Remove(stock);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool StockExists(int id)
    {
        return _context.Stocks.Any(e => e.Id == id);
    }
}
