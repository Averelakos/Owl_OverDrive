using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Owl.Overdrive.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAlternativeGameTitle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlternativeGameTitles_Games_GameId",
                table: "AlternativeGameTitles");

            migrationBuilder.AddForeignKey(
                name: "FK_AlternativeGameTitles_Games_GameId",
                table: "AlternativeGameTitles",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlternativeGameTitles_Games_GameId",
                table: "AlternativeGameTitles");

            migrationBuilder.AddForeignKey(
                name: "FK_AlternativeGameTitles_Games_GameId",
                table: "AlternativeGameTitles",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
