using FinancialPortfolio.Domain.Entities.Wallets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialPortfolio.Infrastructure.Context.Configurations
{
    internal class WalletConfiguration : IEntityTypeConfiguration<Wallet>
    {
        public void Configure(EntityTypeBuilder<Wallet> builder)
        {
            builder.ToTable("wallets");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.UserId)
                .IsRequired();

            builder.Property(e => e.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasOne(e => e.User)
                .WithMany(e => e.Wallets)
                .HasForeignKey(e => e.UserId)
                .IsRequired();

            builder.HasIndex(e => new { e.UserId, e.Name }).IsUnique();
        }
    }
}
