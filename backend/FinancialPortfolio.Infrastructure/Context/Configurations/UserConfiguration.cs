using FinancialPortfolio.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialPortfolio.Infrastructure.Context.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            builder.HasKey(user => user.Id);

            builder.Property(user => user.Email)
                .IsRequired();

            builder.Property(user => user.Password)
                .IsRequired();

            builder.Property(user => user.Role)
                .HasConversion<string>()
                .IsRequired();

            builder.HasIndex(user => user.Email).IsUnique();
        }
    }
}
