using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinancialPortfolio.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameAmountToQuantityCreateComplexTypeFromMoneyValueObject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_assets_WalletId_Name",
                table: "assets");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "assets",
                newName: "Quantity");

            migrationBuilder.AlterColumn<string>(
                name: "Currency",
                table: "assets",
                type: "character varying(3)",
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(5)",
                oldMaxLength: 5,
                oldDefaultValue: "EUR");

            migrationBuilder.CreateIndex(
                name: "IX_assets_WalletId",
                table: "assets",
                column: "WalletId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_assets_WalletId",
                table: "assets");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "assets",
                newName: "Amount");

            migrationBuilder.AlterColumn<string>(
                name: "Currency",
                table: "assets",
                type: "character varying(5)",
                maxLength: 5,
                nullable: false,
                defaultValue: "EUR",
                oldClrType: typeof(string),
                oldType: "character varying(3)",
                oldMaxLength: 3);

            migrationBuilder.CreateIndex(
                name: "IX_assets_WalletId_Name",
                table: "assets",
                columns: new[] { "WalletId", "Name" },
                unique: true);
        }
    }
}
