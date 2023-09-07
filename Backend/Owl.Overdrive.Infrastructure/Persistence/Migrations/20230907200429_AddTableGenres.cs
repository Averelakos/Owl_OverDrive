using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Owl.Overdrive.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddTableGenres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
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
                    table.PrimaryKey("PK_Genres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Genres_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Genres_Users_LastUpdatedById",
                        column: x => x.LastUpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "CreatedById", "LastUpdatedById", "Name" },
                values: new object[,]
                {
                    { 1L, null, null, "4X(explore, expand, exploit and exterminate)" },
                    { 2L, null, null, "Action" },
                    { 3L, null, null, "Bussiness" },
                    { 4L, null, null, "Comedy" },
                    { 5L, null, null, "Drama" },
                    { 6L, null, null, "Educational" },
                    { 7L, null, null, "Erotic" },
                    { 8L, null, null, "Fantasy" },
                    { 9L, null, null, "Historical" },
                    { 10L, null, null, "Horror" },
                    { 11L, null, null, "Kids" },
                    { 12L, null, null, "Mystery" },
                    { 13L, null, null, "Non-fiction" },
                    { 14L, null, null, "Open world" },
                    { 15L, null, null, "Party" },
                    { 16L, null, null, "Romance" },
                    { 17L, null, null, "Sandbox" },
                    { 18L, null, null, "Science fiction" },
                    { 19L, null, null, "Stealth" },
                    { 20L, null, null, "Survival" },
                    { 21L, null, null, "Thriller" },
                    { 22L, null, null, "Warfare" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Genres_CreatedById",
                table: "Genres",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_LastUpdatedById",
                table: "Genres",
                column: "LastUpdatedById");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
