using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SandO.Bll.Migrations
{
    /// <inheritdoc />
    public partial class _0105252218 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "DelFlag",
                table: "Plants",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DelFlag",
                table: "Departments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DelFlag",
                table: "Appellations",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DelFlag",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "DelFlag",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "DelFlag",
                table: "Appellations");
        }
    }
}
