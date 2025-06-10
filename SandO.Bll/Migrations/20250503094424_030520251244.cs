using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SandO.Bll.Migrations
{
    /// <inheritdoc />
    public partial class _030520251244 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NewJson",
                table: "RecordLogs");

            migrationBuilder.RenameColumn(
                name: "OldJson",
                table: "RecordLogs",
                newName: "DifferenceJson");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DifferenceJson",
                table: "RecordLogs",
                newName: "OldJson");

            migrationBuilder.AddColumn<string>(
                name: "NewJson",
                table: "RecordLogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
