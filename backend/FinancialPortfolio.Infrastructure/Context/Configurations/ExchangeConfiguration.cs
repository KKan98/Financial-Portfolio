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

            builder.Property(e => e.MIC)
                .IsRequired();

            builder.Property(e => e.Suffix)
                .HasDefaultValue("");

            builder.HasData(
                new Exchange { Symbol = "XETR", MIC = "Deutsche Börse Xetra", Suffix = "DE" },
                new Exchange { Symbol = "XFRA", MIC = "Frankfurt Stock Exchange", Suffix = "F" },
                new Exchange { Symbol = "XLON", MIC = "London Stock Exchange", Suffix = "L" },
                new Exchange { Symbol = "XAMS", MIC = "Euronext Amsterdam", Suffix = "AS" },
                new Exchange { Symbol = "XPAR", MIC = "Euronext Paris", Suffix = "PA" },
                new Exchange { Symbol = "XBRU", MIC = "Euronext Brussels", Suffix = "BR" },
                new Exchange { Symbol = "XLIS", MIC = "Euronext Lisbon", Suffix = "LS" },
                new Exchange { Symbol = "XMIL", MIC = "Borsa Italiana / Euronext Milan", Suffix = "MI" },
                new Exchange { Symbol = "XSWX", MIC = "SIX Swiss Exchange", Suffix = "SW" },
                new Exchange { Symbol = "XWAR", MIC = "Warsaw Stock Exchange", Suffix = "WA" },
                new Exchange { Symbol = "XSTO", MIC = "Nasdaq Stockholm", Suffix = "ST" },
                new Exchange { Symbol = "XCSE", MIC = "Nasdaq Copenhagen", Suffix = "CO" },
                new Exchange { Symbol = "XHEL", MIC = "Nasdaq Helsinki", Suffix = "HE" },
                new Exchange { Symbol = "XOSL", MIC = "Oslo Børs", Suffix = "OL" },
                new Exchange { Symbol = "XWBO", MIC = "Vienna Stock Exchange", Suffix = "VI" },
                new Exchange { Symbol = "XPRA", MIC = "Prague Stock Exchange", Suffix = "PR" },
                new Exchange { Symbol = "XBUD", MIC = "Budapest Stock Exchange", Suffix = "BD" },
                new Exchange { Symbol = "XATH", MIC = "Athens Stock Exchange", Suffix = "AT" },
                new Exchange { Symbol = "XMAD", MIC = "Madrid Stock Exchange", Suffix = "MC" },
                new Exchange { Symbol = "XIST", MIC = "Borsa Istanbul", Suffix = "IS" },
                new Exchange { Symbol = "XNAS", MIC = "Nasdaq US", Suffix = "" },
                new Exchange { Symbol = "XNYS", MIC = "New York Stock Exchange", Suffix = "" },
                new Exchange { Symbol = "ARCX", MIC = "NYSE Arca", Suffix = "" },
                new Exchange { Symbol = "XTSE", MIC = "Toronto Stock Exchange", Suffix = "TO" },
                new Exchange { Symbol = "XTSX", MIC = "TSX Venture Exchange", Suffix = "V" },
                new Exchange { Symbol = "XASX", MIC = "Australian Securities Exchange", Suffix = "AX" },
                new Exchange { Symbol = "XTKS", MIC = "Tokyo Stock Exchange", Suffix = "T" },
                new Exchange { Symbol = "XHKG", MIC = "Hong Kong Stock Exchange", Suffix = "HK" },
                new Exchange { Symbol = "XSES", MIC = "Singapore Exchange", Suffix = "SI" },
                new Exchange { Symbol = "XBOM", MIC = "BSE India", Suffix = "BO" },
                new Exchange { Symbol = "XSHG", MIC = "Shanghai Stock Exchange", Suffix = "SS" },
                new Exchange { Symbol = "XSHE", MIC = "Shenzhen Stock Exchange", Suffix = "SZ" }
            );
        }
    }
}
