using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Owl.Overdrive.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableGameLocalization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "GameId",
                table: "GameLocalizations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_GameLocalizations_GameId",
                table: "GameLocalizations",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameLocalizations_Games_GameId",
                table: "GameLocalizations",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameLocalizations_Games_GameId",
                table: "GameLocalizations");

            migrationBuilder.DropIndex(
                name: "IX_GameLocalizations_GameId",
                table: "GameLocalizations");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "GameLocalizations");
        }
    }
}
