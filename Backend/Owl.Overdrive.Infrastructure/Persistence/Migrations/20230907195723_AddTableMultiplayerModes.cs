using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Owl.Overdrive.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddTableMultiplayerModes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MultiplayerModes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampaignCoop = table.Column<bool>(type: "bit", nullable: false),
                    DropIn = table.Column<bool>(type: "bit", nullable: false),
                    LanCoop = table.Column<bool>(type: "bit", nullable: false),
                    OfflineCoop = table.Column<bool>(type: "bit", nullable: false),
                    OfflineCoopMax = table.Column<int>(type: "int", nullable: false),
                    OfflineMax = table.Column<int>(type: "int", nullable: false),
                    OnlineCoop = table.Column<bool>(type: "bit", nullable: false),
                    OnlineCoopMax = table.Column<int>(type: "int", nullable: false),
                    OnlineMax = table.Column<int>(type: "int", nullable: false),
                    SplitScreen = table.Column<bool>(type: "bit", nullable: false),
                    SplitScreenOnline = table.Column<bool>(type: "bit", nullable: false),
                    GameId = table.Column<long>(type: "bigint", nullable: false),
                    PlatformId = table.Column<long>(type: "bigint", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2(7)", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastUpdated = table.Column<DateTime>(type: "datetime2(7)", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CreatedById = table.Column<long>(type: "bigint", nullable: true),
                    LastUpdatedById = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultiplayerModes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MultiplayerModes_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MultiplayerModes_Platforms_PlatformId",
                        column: x => x.PlatformId,
                        principalTable: "Platforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MultiplayerModes_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MultiplayerModes_Users_LastUpdatedById",
                        column: x => x.LastUpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MultiplayerModes_CreatedById",
                table: "MultiplayerModes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MultiplayerModes_GameId",
                table: "MultiplayerModes",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_MultiplayerModes_LastUpdatedById",
                table: "MultiplayerModes",
                column: "LastUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MultiplayerModes_PlatformId",
                table: "MultiplayerModes",
                column: "PlatformId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MultiplayerModes");
        }
    }
}
