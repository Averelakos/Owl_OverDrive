using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Owl.Overdrive.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddTablesGameGameEditionAndAlternativeGameTitle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AlternativeGameTitles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlternativeName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AlternativeTitleType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameId = table.Column<long>(type: "bigint", nullable: false),
                    GameId1 = table.Column<long>(type: "bigint", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2(7)", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastUpdated = table.Column<DateTime>(type: "datetime2(7)", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CreatedById = table.Column<long>(type: "bigint", nullable: true),
                    LastUpdatedById = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlternativeGameTitles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlternativeGameTitles_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AlternativeGameTitles_Users_LastUpdatedById",
                        column: x => x.LastUpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GameEditions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EditionGameId = table.Column<long>(type: "bigint", nullable: false),
                    ParentGameId = table.Column<long>(type: "bigint", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2(7)", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastUpdated = table.Column<DateTime>(type: "datetime2(7)", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CreatedById = table.Column<long>(type: "bigint", nullable: true),
                    LastUpdatedById = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameEditions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameEditions_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameEditions_Users_LastUpdatedById",
                        column: x => x.LastUpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    Story = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    UpdatedGameId = table.Column<long>(type: "bigint", nullable: true),
                    UpdateGameType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GameStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GameEditionId = table.Column<long>(type: "bigint", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2(7)", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastUpdated = table.Column<DateTime>(type: "datetime2(7)", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CreatedById = table.Column<long>(type: "bigint", nullable: true),
                    LastUpdatedById = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_GameEditions_GameEditionId",
                        column: x => x.GameEditionId,
                        principalTable: "GameEditions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Games_Games_UpdatedGameId",
                        column: x => x.UpdatedGameId,
                        principalTable: "Games",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Games_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_Users_LastUpdatedById",
                        column: x => x.LastUpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlternativeGameTitles_CreatedById",
                table: "AlternativeGameTitles",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AlternativeGameTitles_GameId",
                table: "AlternativeGameTitles",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_AlternativeGameTitles_GameId1",
                table: "AlternativeGameTitles",
                column: "GameId1");

            migrationBuilder.CreateIndex(
                name: "IX_AlternativeGameTitles_LastUpdatedById",
                table: "AlternativeGameTitles",
                column: "LastUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_GameEditions_CreatedById",
                table: "GameEditions",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_GameEditions_EditionGameId",
                table: "GameEditions",
                column: "EditionGameId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GameEditions_LastUpdatedById",
                table: "GameEditions",
                column: "LastUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_GameEditions_ParentGameId",
                table: "GameEditions",
                column: "ParentGameId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_CreatedById",
                table: "Games",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Games_GameEditionId",
                table: "Games",
                column: "GameEditionId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_LastUpdatedById",
                table: "Games",
                column: "LastUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Games_UpdatedGameId",
                table: "Games",
                column: "UpdatedGameId",
                unique: true,
                filter: "[UpdatedGameId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AlternativeGameTitles_Games_GameId",
                table: "AlternativeGameTitles",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AlternativeGameTitles_Games_GameId1",
                table: "AlternativeGameTitles",
                column: "GameId1",
                principalTable: "Games",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GameEditions_Games_EditionGameId",
                table: "GameEditions",
                column: "EditionGameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GameEditions_Games_ParentGameId",
                table: "GameEditions",
                column: "ParentGameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameEditions_Games_EditionGameId",
                table: "GameEditions");

            migrationBuilder.DropForeignKey(
                name: "FK_GameEditions_Games_ParentGameId",
                table: "GameEditions");

            migrationBuilder.DropTable(
                name: "AlternativeGameTitles");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "GameEditions");
        }
    }
}
