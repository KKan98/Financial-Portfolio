using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinancialPortfolio.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangePKToSymbolAndDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_market_data",
                table: "market_data");

            migrationBuilder.AddPrimaryKey(
                name: "PK_market_data",
                table: "market_data",
                columns: new[] { "Symbol", "Date" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_market_data",
                table: "market_data");

            migrationBuilder.AddPrimaryKey(
                name: "PK_market_data",
                table: "market_data",
                column: "Symbol");
        }
    }
}
