using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SandO.Bll.Migrations
{
    /// <inheritdoc />
    public partial class _2143 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupPermissions_Users_CreatedById",
                table: "GroupPermissions");

            migrationBuilder.DropIndex(
                name: "IX_GroupPermissions_CreatedById",
                table: "GroupPermissions");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GroupPermissions");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "GroupPermissions");

            migrationBuilder.AddColumn<string>(
                name: "Guid",
                table: "UserGroups",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Guid",
                table: "GroupPermissions",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Guid",
                table: "UserGroups");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "GroupPermissions");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GroupPermissions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "GroupPermissions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_GroupPermissions_CreatedById",
                table: "GroupPermissions",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupPermissions_Users_CreatedById",
                table: "GroupPermissions",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
