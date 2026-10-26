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

            builder.HasKey(e => e.MIC);

            builder.Property(e => e.Name)
                .IsRequired();

            builder.Property(e => e.MIC)
                .HasColumnName("Mic")
                .HasMaxLength(4)
                .IsRequired();

            builder.Property(e => e.Suffix)
                .HasDefaultValue("");

            builder.HasData(
                new Exchange { MIC = "XETR", Name = "Deutsche Börse Xetra", Suffix = "DE" },
                new Exchange { MIC = "XFRA", Name = "Frankfurt Stock Exchange", Suffix = "F" },
                new Exchange { MIC = "XLON", Name = "London Stock Exchange", Suffix = "L" },
                new Exchange { MIC = "XAMS", Name = "Euronext Amsterdam", Suffix = "AS" },
                new Exchange { MIC = "XPAR", Name = "Euronext Paris", Suffix = "PA" },
                new Exchange { MIC = "XBRU", Name = "Euronext Brussels", Suffix = "BR" },
                new Exchange { MIC = "XLIS", Name = "Euronext Lisbon", Suffix = "LS" },
                new Exchange { MIC = "XMIL", Name = "Borsa Italiana / Euronext Milan", Suffix = "MI" },
                new Exchange { MIC = "XSWX", Name = "SIX Swiss Exchange", Suffix = "SW" },
                new Exchange { MIC = "XWAR", Name = "Warsaw Stock Exchange", Suffix = "WA" },
                new Exchange { MIC = "XSTO", Name = "Nasdaq Stockholm", Suffix = "ST" },
                new Exchange { MIC = "XCSE", Name = "Nasdaq Copenhagen", Suffix = "CO" },
                new Exchange { MIC = "XHEL", Name = "Nasdaq Helsinki", Suffix = "HE" },
                new Exchange { MIC = "XOSL", Name = "Oslo Børs", Suffix = "OL" },
                new Exchange { MIC = "XWBO", Name = "Vienna Stock Exchange", Suffix = "VI" },
                new Exchange { MIC = "XPRA", Name = "Prague Stock Exchange", Suffix = "PR" },
                new Exchange { MIC = "XBUD", Name = "Budapest Stock Exchange", Suffix = "BD" },
                new Exchange { MIC = "XATH", Name = "Athens Stock Exchange", Suffix = "AT" },
                new Exchange { MIC = "XMAD", Name = "Madrid Stock Exchange", Suffix = "MC" },
                new Exchange { MIC = "XIST", Name = "Borsa Istanbul", Suffix = "IS" },
                new Exchange { MIC = "XNAS", Name = "Nasdaq US", Suffix = "" },
                new Exchange { MIC = "XNYS", Name = "New York Stock Exchange", Suffix = "" },
                new Exchange { MIC = "ARCX", Name = "NYSE Arca", Suffix = "" },
                new Exchange { MIC = "XTSE", Name = "Toronto Stock Exchange", Suffix = "TO" },
                new Exchange { MIC = "XTSX", Name = "TSX Venture Exchange", Suffix = "V" },
                new Exchange { MIC = "XASX", Name = "Australian Securities Exchange", Suffix = "AX" },
                new Exchange { MIC = "XTKS", Name = "Tokyo Stock Exchange", Suffix = "T" },
                new Exchange { MIC = "XHKG", Name = "Hong Kong Stock Exchange", Suffix = "HK" },
                new Exchange { MIC = "XSES", Name = "Singapore Exchange", Suffix = "SI" },
                new Exchange { MIC = "XBOM", Name = "BSE India", Suffix = "BO" },
                new Exchange { MIC = "XSHG", Name = "Shanghai Stock Exchange", Suffix = "SS" },
                new Exchange { MIC = "XSHE", Name = "Shenzhen Stock Exchange", Suffix = "SZ" }
            );
        }
    }
}
