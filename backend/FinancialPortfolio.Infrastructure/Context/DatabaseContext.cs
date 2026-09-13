using FinancialPortfolio.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;


namespace FinancialPortfolio.Infrastructure.Context
{
    public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);
        }

    }
}
