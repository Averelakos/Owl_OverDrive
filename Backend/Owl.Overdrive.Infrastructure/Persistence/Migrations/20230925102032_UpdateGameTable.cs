using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Owl.Overdrive.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateGameTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Games_UpdatedGameId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_UpdatedGameId",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "UpdatedGameId",
                table: "Games",
                newName: "ParentGameId");

            migrationBuilder.RenameColumn(
                name: "UpdateGameType",
                table: "Games",
                newName: "GameType");

            migrationBuilder.CreateIndex(
                name: "IX_Games_ParentGameId",
                table: "Games",
                column: "ParentGameId",
                unique: true,
                filter: "[ParentGameId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Games_ParentGameId",
                table: "Games",
                column: "ParentGameId",
                principalTable: "Games",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Games_ParentGameId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_ParentGameId",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "ParentGameId",
                table: "Games",
                newName: "UpdatedGameId");

            migrationBuilder.RenameColumn(
                name: "GameType",
                table: "Games",
                newName: "UpdateGameType");

            migrationBuilder.CreateIndex(
                name: "IX_Games_UpdatedGameId",
                table: "Games",
                column: "UpdatedGameId",
                unique: true,
                filter: "[UpdatedGameId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Games_UpdatedGameId",
                table: "Games",
                column: "UpdatedGameId",
                principalTable: "Games",
                principalColumn: "Id");
        }
    }
}
