using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Owl.Overdrive.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddLanguageTableAndSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Languages",
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
                    table.PrimaryKey("PK_Languages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Languages_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Languages_Users_LastUpdatedById",
                        column: x => x.LastUpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "CreatedById", "LastUpdatedById", "Name" },
                values: new object[,]
                {
                    { 1L, null, null, "German" },
                    { 2L, null, null, "Ukrainian" },
                    { 3L, null, null, "Arabic" },
                    { 4L, null, null, "Chinese (Simplified)" },
                    { 5L, null, null, "Chinese (Traditional)" },
                    { 6L, null, null, "Czech" },
                    { 7L, null, null, "Danish" },
                    { 8L, null, null, "Dutch" },
                    { 9L, null, null, "English" },
                    { 10L, null, null, "English (UK)" },
                    { 11L, null, null, "Spanish (Spain)" },
                    { 12L, null, null, "Spanish (Mexico)" },
                    { 13L, null, null, "French" },
                    { 14L, null, null, "Finnish" },
                    { 15L, null, null, "Hungarian" },
                    { 16L, null, null, "Italian" },
                    { 17L, null, null, "Hebrew" },
                    { 18L, null, null, "Japanese" },
                    { 19L, null, null, "Korean" },
                    { 20L, null, null, "Norwegian" },
                    { 21L, null, null, "Portuguese (Portugal)" },
                    { 22L, null, null, "Polish" },
                    { 23L, null, null, "Portuguese (Brazil)" },
                    { 24L, null, null, "Russian" },
                    { 25L, null, null, "Thai" },
                    { 26L, null, null, "Turkish" },
                    { 27L, null, null, "Vietnamese" },
                    { 28L, null, null, "Swedish" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Languages_CreatedById",
                table: "Languages",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_LastUpdatedById",
                table: "Languages",
                column: "LastUpdatedById");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Languages");
        }
    }
}
