using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EuphoriaCommerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class movegendertoprofile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiration",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "Users",
                newName: "UserProfile_Gender");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserProfile_Gender",
                table: "Users",
                newName: "Gender");

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiration",
                table: "Users",
                type: "datetime2",
                nullable: true);
        }
    }
}
