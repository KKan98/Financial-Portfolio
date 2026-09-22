using FinancialPortfolio.Domain.Entities.Users;
using FinancialPortfolio.Domain.Entities.Wallets;
using Microsoft.EntityFrameworkCore;


namespace FinancialPortfolio.Infrastructure.Context
{
    public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Wallet> Wallets { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);
        }

    }
}
