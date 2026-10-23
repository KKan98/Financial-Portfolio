using FinancialPortfolio.Domain.Entities;
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

            builder.Property(a => a.Quantity)
                .HasPrecision(18, 4)
                .IsRequired();

            builder.ComplexProperty(a => a.BuyingPrice, price =>
            {
                price.Property(m => m.Amount)
                    .HasColumnName("BuyingPrice")
                    .HasPrecision(18, 2)
                    .IsRequired();

                price.Property(m => m.Currency)
                    .HasColumnName("Currency")
                    .HasConversion<string>()
                    .HasMaxLength(3)
                    .IsRequired();
            }); //Can be chained from EF11

            builder.Property(a => a.Timestamp)
                .HasDefaultValueSql("now()");

            builder.HasOne(a => a.Wallet)
                .WithMany(w => w.Assets)
                .HasForeignKey(a => a.WalletId)
                .IsRequired();
        }
    }
}
