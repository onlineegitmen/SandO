using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SandO.Bll.Migrations
{
    /// <inheritdoc />
    public partial class _19032307 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GroupClass",
                table: "Groups",
                newName: "GroupModule");

            migrationBuilder.CreateTable(
                name: "PermissionFails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AuthenticationClass = table.Column<int>(type: "int", nullable: false),
                    AuthenticationEvent = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionFails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PermissionFails_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PermissionFails_UserId",
                table: "PermissionFails",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PermissionFails");

            migrationBuilder.RenameColumn(
                name: "GroupModule",
                table: "Groups",
                newName: "GroupClass");
        }
    }
}
