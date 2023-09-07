using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Owl.Overdrive.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddTableThemes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Themes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(MAX)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2(7)", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastUpdated = table.Column<DateTime>(type: "datetime2(7)", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CreatedById = table.Column<long>(type: "bigint", nullable: true),
                    LastUpdatedById = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Themes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Themes_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Themes_Users_LastUpdatedById",
                        column: x => x.LastUpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Themes",
                columns: new[] { "Id", "CreatedById", "LastUpdatedById", "Name" },
                values: new object[,]
                {
                    { 1L, null, null, "Adventure" },
                    { 2L, null, null, "Arcade" },
                    { 3L, null, null, "Card & Board Game" },
                    { 4L, null, null, "Fighting" },
                    { 5L, null, null, "Hack and slash/ Beat 'em up" },
                    { 6L, null, null, "Indie" },
                    { 7L, null, null, "Music" },
                    { 8L, null, null, "Pinball" },
                    { 9L, null, null, "Platform" },
                    { 10L, null, null, "Point-and-click" },
                    { 11L, null, null, "Puzzle" },
                    { 12L, null, null, "Quiz/Trivia" },
                    { 13L, null, null, "Racing" },
                    { 14L, null, null, "Real Time Strategy(RTS)" },
                    { 15L, null, null, "Shooter" },
                    { 16L, null, null, "Role-playening(RPG)" },
                    { 17L, null, null, "Simulator" },
                    { 18L, null, null, "Sport" },
                    { 19L, null, null, "Strategy" },
                    { 20L, null, null, "Tactical" },
                    { 21L, null, null, "Turn-based-strategy(TBS)" },
                    { 22L, null, null, "Visual Novel" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Themes_CreatedById",
                table: "Themes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Themes_LastUpdatedById",
                table: "Themes",
                column: "LastUpdatedById");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Themes");
        }
    }
}
