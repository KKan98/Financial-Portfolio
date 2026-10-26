using FinancialPortfolio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialPortfolio.Infrastructure.Context.Configurations
{
    public class StockConfiguration : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.ToTable("stocks");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id).ValueGeneratedOnAdd();

            builder.Property(s => s.Symbol)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(s => s.MIC)
                .HasMaxLength(4)
                .IsRequired();

            builder.Property(s => s.Quantity)
                .HasPrecision(18, 4)
                .IsRequired();

            builder.ComplexProperty(s => s.BuyingPrice, price =>
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

            builder.Property(s => s.Timestamp)
                .HasDefaultValueSql("now()");

            builder.HasOne(s => s.Wallet)
                .WithMany(w => w.Assets)
                .HasForeignKey(s => s.WalletId)
                .IsRequired();
        }
    }
}
