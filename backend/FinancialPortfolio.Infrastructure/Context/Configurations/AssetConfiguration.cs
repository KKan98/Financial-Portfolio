using FinancialPortfolio.Domain.Entities.Assets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialPortfolio.Infrastructure.Context.Configurations
{
    public class AssetConfiguration : IEntityTypeConfiguration<Asset>
    {
        public void Configure(EntityTypeBuilder<Asset> builder)
        {
            builder.ToTable("assets");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id).ValueGeneratedOnAdd();

            builder.Property(a => a.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(a => a.Amount)
                .HasPrecision(18, 4)
                .IsRequired();

            builder.Property(a => a.BuyingPrice)
                .HasPrecision(18, 2);

            builder.Property(a => a.Currency)
                .HasDefaultValue("EUR")
                .HasMaxLength(5)
                .IsRequired();

            builder.Property(a => a.Timestamp)
                .HasDefaultValueSql("now()");

            builder.HasOne(a => a.Wallet)
                .WithMany(w => w.Assets)
                .HasForeignKey(a => a.WalletId)
                .IsRequired();

            builder.HasIndex(a => new { a.WalletId, a.Name }).IsUnique();
        }
    }
}
