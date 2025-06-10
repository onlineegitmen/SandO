using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SandO.Bll.Migrations
{
    /// <inheritdoc />
    public partial class _030520251538 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Company_Code",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Company_Name",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Company_TaxNumber",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Company_TradeRegistryNumber",
                table: "Companies");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Company_Code",
                table: "Companies",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Company_Name",
                table: "Companies",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Company_TaxNumber",
                table: "Companies",
                column: "TaxNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Company_TradeRegistryNumber",
                table: "Companies",
                column: "TradeRegistryNumber",
                unique: true);
        }
    }
}
