using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameLogAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddPlatformEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Platform",
                table: "Games",
                newName: "IdPlatform");

            migrationBuilder.CreateTable(
                name: "Platforms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platforms", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_IdPlatform",
                table: "Games",
                column: "IdPlatform");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Platforms_IdPlatform",
                table: "Games",
                column: "IdPlatform",
                principalTable: "Platforms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Platforms_IdPlatform",
                table: "Games");

            migrationBuilder.DropTable(
                name: "Platforms");

            migrationBuilder.DropIndex(
                name: "IX_Games_IdPlatform",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "IdPlatform",
                table: "Games",
                newName: "Platform");
        }
    }
}
