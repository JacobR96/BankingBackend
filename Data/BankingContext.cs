using Microsoft.EntityFrameworkCore;

public class BankingContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<CheckingAccount> CheckingAccounts { get; set; }
    public DbSet<SavingsAccount> SavingsAccounts { get; set; }
    public DbSet<Loan> Loans { get; set; }
    public DbSet<Stock> Stocks { get; set; }
    public DbSet<CD> CDs { get; set; }
    public DbSet<CreditCard> CreditCards { get; set; }

    public BankingContext(DbContextOptions<BankingContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasMany(u => u.Accounts)
            .WithOne(a => a.User)
            .HasForeignKey(a => a.UserId);

        base.OnModelCreating(modelBuilder);
    }
}
