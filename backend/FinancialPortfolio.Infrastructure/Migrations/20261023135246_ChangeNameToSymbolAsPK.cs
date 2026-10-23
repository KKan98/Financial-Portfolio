using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinancialPortfolio.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNameToSymbolAsPK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_exchanges",
                table: "exchanges");

            migrationBuilder.AddPrimaryKey(
                name: "PK_exchanges",
                table: "exchanges",
                column: "Symbol");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_exchanges",
                table: "exchanges");

            migrationBuilder.AddPrimaryKey(
                name: "PK_exchanges",
                table: "exchanges",
                column: "Name");
        }
    }
}
