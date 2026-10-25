using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinancialPortfolio.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameMarketDataTo_market_data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_marketData",
                table: "marketData");

            migrationBuilder.RenameTable(
                name: "marketData",
                newName: "market_data");

            migrationBuilder.AddPrimaryKey(
                name: "PK_market_data",
                table: "market_data",
                column: "Symbol");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_market_data",
                table: "market_data");

            migrationBuilder.RenameTable(
                name: "market_data",
                newName: "marketData");

            migrationBuilder.AddPrimaryKey(
                name: "PK_marketData",
                table: "marketData",
                column: "Symbol");
        }
    }
}
