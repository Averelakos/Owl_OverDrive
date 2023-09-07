using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Owl.Overdrive.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddTableGamePlayerPerspectives : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GamePlayerPerspectives",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<long>(type: "bigint", nullable: false),
                    PlayerPerspectiveId = table.Column<long>(type: "bigint", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2(7)", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastUpdated = table.Column<DateTime>(type: "datetime2(7)", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CreatedById = table.Column<long>(type: "bigint", nullable: true),
                    LastUpdatedById = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePlayerPerspectives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GamePlayerPerspectives_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GamePlayerPerspectives_PlayerPerspectives_PlayerPerspectiveId",
                        column: x => x.PlayerPerspectiveId,
                        principalTable: "PlayerPerspectives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GamePlayerPerspectives_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GamePlayerPerspectives_Users_LastUpdatedById",
                        column: x => x.LastUpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GamePlayerPerspectives_CreatedById",
                table: "GamePlayerPerspectives",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_GamePlayerPerspectives_GameId",
                table: "GamePlayerPerspectives",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GamePlayerPerspectives_LastUpdatedById",
                table: "GamePlayerPerspectives",
                column: "LastUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_GamePlayerPerspectives_PlayerPerspectiveId",
                table: "GamePlayerPerspectives",
                column: "PlayerPerspectiveId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GamePlayerPerspectives");
        }
    }
}
