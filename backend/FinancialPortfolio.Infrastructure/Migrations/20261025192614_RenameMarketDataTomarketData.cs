using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinancialPortfolio.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameMarketDataTomarketData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MarketData",
                table: "MarketData");

            migrationBuilder.RenameTable(
                name: "MarketData",
                newName: "marketData");

            migrationBuilder.AddPrimaryKey(
                name: "PK_marketData",
                table: "marketData",
                column: "Symbol");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_marketData",
                table: "marketData");

            migrationBuilder.RenameTable(
                name: "marketData",
                newName: "MarketData");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MarketData",
                table: "MarketData",
                column: "Symbol");
        }
    }
}
