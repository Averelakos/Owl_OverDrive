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

            migrationBuilder.DropColumn(
                name: "UpdateGameType",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "UpdatedGameId",
                table: "Games",
                newName: "ParentGameId");

            migrationBuilder.AddColumn<string>(
                name: "GameType",
                table: "Games",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.DropColumn(
                name: "GameType",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "ParentGameId",
                table: "Games",
                newName: "UpdatedGameId");

            migrationBuilder.AddColumn<string>(
                name: "UpdateGameType",
                table: "Games",
                type: "nvarchar(max)",
                nullable: true);

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
