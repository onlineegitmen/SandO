using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SandO.Bll.Migrations
{
    /// <inheritdoc />
    public partial class _130520251319 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "UserDepartments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Default",
                table: "UserDepartments",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "UserDepartments");

            migrationBuilder.DropColumn(
                name: "Default",
                table: "UserDepartments");
        }
    }
}
