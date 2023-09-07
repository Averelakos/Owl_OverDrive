using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Owl.Overdrive.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddTablePlayerPerspectives : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlayerPerspectives",
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
                    table.PrimaryKey("PK_PlayerPerspectives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerPerspectives_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayerPerspectives_Users_LastUpdatedById",
                        column: x => x.LastUpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "PlayerPerspectives",
                columns: new[] { "Id", "CreatedById", "LastUpdatedById", "Name" },
                values: new object[,]
                {
                    { 1L, null, null, "Auditory" },
                    { 2L, null, null, "Bird view / Isometric" },
                    { 3L, null, null, "First person" },
                    { 4L, null, null, "Side view" },
                    { 5L, null, null, "Text" },
                    { 6L, null, null, "Third person" },
                    { 7L, null, null, "Virtual Reality" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerPerspectives_CreatedById",
                table: "PlayerPerspectives",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerPerspectives_LastUpdatedById",
                table: "PlayerPerspectives",
                column: "LastUpdatedById");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerPerspectives");
        }
    }
}
