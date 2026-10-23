using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinancialPortfolio.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedExchangesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "exchanges",
                columns: new[] { "Symbol", "Name", "Suffix" },
                values: new object[,]
                {
                    { "ARCX", "NYSE Arca", "" },
                    { "XAMS", "Euronext Amsterdam", "AS" },
                    { "XASX", "Australian Securities Exchange", "AX" },
                    { "XATH", "Athens Stock Exchange", "AT" },
                    { "XBOM", "BSE India", "BO" },
                    { "XBRU", "Euronext Brussels", "BR" },
                    { "XBUD", "Budapest Stock Exchange", "BD" },
                    { "XCSE", "Nasdaq Copenhagen", "CO" },
                    { "XETR", "Deutsche Börse Xetra", "DE" },
                    { "XFRA", "Frankfurt Stock Exchange", "F" },
                    { "XHEL", "Nasdaq Helsinki", "HE" },
                    { "XHKG", "Hong Kong Stock Exchange", "HK" },
                    { "XIST", "Borsa Istanbul", "IS" },
                    { "XLIS", "Euronext Lisbon", "LS" },
                    { "XLON", "London Stock Exchange", "L" },
                    { "XMAD", "Madrid Stock Exchange", "MC" },
                    { "XMIL", "Borsa Italiana / Euronext Milan", "MI" },
                    { "XNAS", "Nasdaq US", "" },
                    { "XNYS", "New York Stock Exchange", "" },
                    { "XOSL", "Oslo Børs", "OL" },
                    { "XPAR", "Euronext Paris", "PA" },
                    { "XPRA", "Prague Stock Exchange", "PR" },
                    { "XSES", "Singapore Exchange", "SI" },
                    { "XSHE", "Shenzhen Stock Exchange", "SZ" },
                    { "XSHG", "Shanghai Stock Exchange", "SS" },
                    { "XSTO", "Nasdaq Stockholm", "ST" },
                    { "XSWX", "SIX Swiss Exchange", "SW" },
                    { "XTKS", "Tokyo Stock Exchange", "T" },
                    { "XTSE", "Toronto Stock Exchange", "TO" },
                    { "XTSX", "TSX Venture Exchange", "V" },
                    { "XWAR", "Warsaw Stock Exchange", "WA" },
                    { "XWBO", "Vienna Stock Exchange", "VI" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "exchanges",
                keyColumn: "Symbol",
                keyValue: "ARCX");

            migrationBuilder.DeleteData(
                table: "exchanges",
                keyColumn: "Symbol",
                keyValue: "XAMS");

            migrationBuilder.DeleteData(
                table: "exchanges",
                keyColumn: "Symbol",
                keyValue: "XASX");

            migrationBuilder.DeleteData(
                table: "exchanges",
                keyColumn: "Symbol",
                keyValue: "XATH");

            migrationBuilder.DeleteData(
                table: "exchanges",
                keyColumn: "Symbol",
                keyValue: "XBOM");

            migrationBuilder.DeleteData(
                table: "exchanges",
                keyColumn: "Symbol",
                keyValue: "XBRU");

            migrationBuilder.DeleteData(
                table: "exchanges",
                keyColumn: "Symbol",
                keyValue: "XBUD");

            migrationBuilder.DeleteData(
                table: "exchanges",
                keyColumn: "Symbol",
                keyValue: "XCSE");

            migrationBuilder.DeleteData(
                table: "exchanges",
                keyColumn: "Symbol",
                keyValue: "XETR");

            migrationBuilder.DeleteData(
                table: "exchanges",
                keyColumn: "Symbol",
                keyValue: "XFRA");

            migrationBuilder.DeleteData(
                table: "exchanges",
                keyColumn: "Symbol",
                keyValue: "XHEL");

            migrationBuilder.DeleteData(
                table: "exchanges",
                keyColumn: "Symbol",
                keyValue: "XHKG");

            migrationBuilder.DeleteData(
                table: "exchanges",
                keyColumn: "Symbol",
                keyValue: "XIST");

            migrationBuilder.DeleteData(
                table: "exchanges",
                keyColumn: "Symbol",
                keyValue: "XLIS");

            migrationBuilder.DeleteData(
                table: "exchanges",
                keyColumn: "Symbol",
                keyValue: "XLON");

            migrationBuilder.DeleteData(
                table: "exchanges",
                keyColumn: "Symbol",
                keyValue: "XMAD");

            migrationBuilder.DeleteData(
                table: "exchanges",
                keyColumn: "Symbol",
                keyValue: "XMIL");

            migrationBuilder.DeleteData(
                table: "exchanges",
                keyColumn: "Symbol",
                keyValue: "XNAS");

            migrationBuilder.DeleteData(
                table: "exchanges",
                keyColumn: "Symbol",
                keyValue: "XNYS");

            migrationBuilder.DeleteData(
                table: "exchanges",
                keyColumn: "Symbol",
                keyValue: "XOSL");

            migrationBuilder.DeleteData(
                table: "exchanges",
                keyColumn: "Symbol",
                keyValue: "XPAR");

            migrationBuilder.DeleteData(
                table: "exchanges",
                keyColumn: "Symbol",
                keyValue: "XPRA");

            migrationBuilder.DeleteData(
                table: "exchanges",
                keyColumn: "Symbol",
                keyValue: "XSES");

            migrationBuilder.DeleteData(
                table: "exchanges",
                keyColumn: "Symbol",
                keyValue: "XSHE");

            migrationBuilder.DeleteData(
                table: "exchanges",
                keyColumn: "Symbol",
                keyValue: "XSHG");

            migrationBuilder.DeleteData(
                table: "exchanges",
                keyColumn: "Symbol",
                keyValue: "XSTO");

            migrationBuilder.DeleteData(
                table: "exchanges",
                keyColumn: "Symbol",
                keyValue: "XSWX");

            migrationBuilder.DeleteData(
                table: "exchanges",
                keyColumn: "Symbol",
                keyValue: "XTKS");

            migrationBuilder.DeleteData(
                table: "exchanges",
                keyColumn: "Symbol",
                keyValue: "XTSE");

            migrationBuilder.DeleteData(
                table: "exchanges",
                keyColumn: "Symbol",
                keyValue: "XTSX");

            migrationBuilder.DeleteData(
                table: "exchanges",
                keyColumn: "Symbol",
                keyValue: "XWAR");

            migrationBuilder.DeleteData(
                table: "exchanges",
                keyColumn: "Symbol",
                keyValue: "XWBO");
        }
    }
}
