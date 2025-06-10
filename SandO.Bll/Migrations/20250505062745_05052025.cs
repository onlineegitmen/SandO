using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SandO.Bll.Migrations
{
    /// <inheritdoc />
    public partial class _05052025 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_User_Username",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Plant_Code",
                table: "Plants");

            migrationBuilder.DropIndex(
                name: "IX_Plant_Name",
                table: "Plants");

            migrationBuilder.DropIndex(
                name: "IX_Department_Code",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Department_Name",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Appellation_Code",
                table: "Appellations");

            migrationBuilder.DropIndex(
                name: "IX_Appellation_Name",
                table: "Appellations");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_User_Username",
                table: "Users",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Plant_Code",
                table: "Plants",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Plant_Name",
                table: "Plants",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Department_Code",
                table: "Departments",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Department_Name",
                table: "Departments",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appellation_Code",
                table: "Appellations",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appellation_Name",
                table: "Appellations",
                column: "Name",
                unique: true);
        }
    }
}
