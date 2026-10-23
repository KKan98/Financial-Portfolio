using FinancialPortfolio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialPortfolio.Infrastructure.Context.Configurations
{
    public class ExchangeConfiguration : IEntityTypeConfiguration<Exchange>
    {
        public void Configure(EntityTypeBuilder<Exchange> builder)
        {
            builder.ToTable("exchanges");

            builder.HasKey(e => e.Symbol);

            builder.Property(e => e.Symbol)
                .IsRequired();

            builder.Property(e => e.Name)
                .IsRequired();

            builder.Property(e => e.Suffix)
                .HasDefaultValue("");

            builder.HasData(
                new Exchange { Symbol = "XETR", Name = "Deutsche Börse Xetra", Suffix = "DE" },
                new Exchange { Symbol = "XFRA", Name = "Frankfurt Stock Exchange", Suffix = "F" },
                new Exchange { Symbol = "XLON", Name = "London Stock Exchange", Suffix = "L" },
                new Exchange { Symbol = "XAMS", Name = "Euronext Amsterdam", Suffix = "AS" },
                new Exchange { Symbol = "XPAR", Name = "Euronext Paris", Suffix = "PA" },
                new Exchange { Symbol = "XBRU", Name = "Euronext Brussels", Suffix = "BR" },
                new Exchange { Symbol = "XLIS", Name = "Euronext Lisbon", Suffix = "LS" },
                new Exchange { Symbol = "XMIL", Name = "Borsa Italiana / Euronext Milan", Suffix = "MI" },
                new Exchange { Symbol = "XSWX", Name = "SIX Swiss Exchange", Suffix = "SW" },
                new Exchange { Symbol = "XWAR", Name = "Warsaw Stock Exchange", Suffix = "WA" },
                new Exchange { Symbol = "XSTO", Name = "Nasdaq Stockholm", Suffix = "ST" },
                new Exchange { Symbol = "XCSE", Name = "Nasdaq Copenhagen", Suffix = "CO" },
                new Exchange { Symbol = "XHEL", Name = "Nasdaq Helsinki", Suffix = "HE" },
                new Exchange { Symbol = "XOSL", Name = "Oslo Børs", Suffix = "OL" },
                new Exchange { Symbol = "XWBO", Name = "Vienna Stock Exchange", Suffix = "VI" },
                new Exchange { Symbol = "XPRA", Name = "Prague Stock Exchange", Suffix = "PR" },
                new Exchange { Symbol = "XBUD", Name = "Budapest Stock Exchange", Suffix = "BD" },
                new Exchange { Symbol = "XATH", Name = "Athens Stock Exchange", Suffix = "AT" },
                new Exchange { Symbol = "XMAD", Name = "Madrid Stock Exchange", Suffix = "MC" },
                new Exchange { Symbol = "XIST", Name = "Borsa Istanbul", Suffix = "IS" },
                new Exchange { Symbol = "XNAS", Name = "Nasdaq US", Suffix = "" },
                new Exchange { Symbol = "XNYS", Name = "New York Stock Exchange", Suffix = "" },
                new Exchange { Symbol = "ARCX", Name = "NYSE Arca", Suffix = "" },
                new Exchange { Symbol = "XTSE", Name = "Toronto Stock Exchange", Suffix = "TO" },
                new Exchange { Symbol = "XTSX", Name = "TSX Venture Exchange", Suffix = "V" },
                new Exchange { Symbol = "XASX", Name = "Australian Securities Exchange", Suffix = "AX" },
                new Exchange { Symbol = "XTKS", Name = "Tokyo Stock Exchange", Suffix = "T" },
                new Exchange { Symbol = "XHKG", Name = "Hong Kong Stock Exchange", Suffix = "HK" },
                new Exchange { Symbol = "XSES", Name = "Singapore Exchange", Suffix = "SI" },
                new Exchange { Symbol = "XBOM", Name = "BSE India", Suffix = "BO" },
                new Exchange { Symbol = "XSHG", Name = "Shanghai Stock Exchange", Suffix = "SS" },
                new Exchange { Symbol = "XSHE", Name = "Shenzhen Stock Exchange", Suffix = "SZ" }
            );
        }
    }
}
