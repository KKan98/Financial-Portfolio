using FinancialPortfolio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialPortfolio.Infrastructure.Context.Configurations
{
    internal class MarketDataConfiguration : IEntityTypeConfiguration<MarketData>
    {
        public void Configure(EntityTypeBuilder<MarketData> builder)
        {
            builder.ToTable("MarketData");

            builder.HasKey(md => md.Symbol);

            builder.Property(md => md.Symbol)
                .IsRequired();

            builder.Property(md => md.Open)
                .HasPrecision(18, 4)
                .IsRequired();

            builder.Property(md => md.Low)
                .HasPrecision(18, 4)
                .IsRequired();

            builder.Property(md => md.High)
                .HasPrecision(18, 4)
                .IsRequired();

            builder.Property(md => md.Close)
                .HasPrecision(18, 4)
                .IsRequired();
        }
    }
}
