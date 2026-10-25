using FinancialPortfolio.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace FinancialPortfolio.Infrastructure.Context
{
    public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<Exchange> Exchanges { get; set; }
        public DbSet<MarketData> MarketData { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);
        }

    }
}
