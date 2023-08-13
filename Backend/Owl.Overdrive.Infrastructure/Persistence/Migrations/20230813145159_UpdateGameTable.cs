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
                name: "FK_AlternativeGameTitles_Games_GameId1",
                table: "AlternativeGameTitles");

            migrationBuilder.DropIndex(
                name: "IX_AlternativeGameTitles_GameId1",
                table: "AlternativeGameTitles");

            migrationBuilder.DropColumn(
                name: "GameId1",
                table: "AlternativeGameTitles");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "GameId1",
                table: "AlternativeGameTitles",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AlternativeGameTitles_GameId1",
                table: "AlternativeGameTitles",
                column: "GameId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AlternativeGameTitles_Games_GameId1",
                table: "AlternativeGameTitles",
                column: "GameId1",
                principalTable: "Games",
                principalColumn: "Id");
        }
    }
}
