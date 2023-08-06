using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Owl.Overdrive.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddGameStatusesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RegionCode",
                table: "Regions",
                type: "varchar(4)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(4)",
                oldMaxLength: 4);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Regions",
                type: "varchar(MAX)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.CreateTable(
                name: "GameStatuses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(MAX)", nullable: false),
                    Description = table.Column<string>(type: "varchar(MAx)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2(7)", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastUpdated = table.Column<DateTime>(type: "datetime2(7)", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CreatedById = table.Column<long>(type: "bigint", nullable: true),
                    LastUpdatedById = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameStatuses_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameStatuses_Users_LastUpdatedById",
                        column: x => x.LastUpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "GameStatuses",
                columns: new[] { "Id", "CreatedById", "Description", "LastUpdatedById", "Name" },
                values: new object[,]
                {
                    { 1L, null, null, null, "Alpha" },
                    { 2L, null, null, null, "Beta" },
                    { 3L, null, null, null, "Cancelled" },
                    { 4L, null, null, null, "Early Access" },
                    { 5L, null, null, null, "Full Release" },
                    { 6L, null, null, null, "Offline" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameStatuses_CreatedById",
                table: "GameStatuses",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_GameStatuses_LastUpdatedById",
                table: "GameStatuses",
                column: "LastUpdatedById");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameStatuses");

            migrationBuilder.AlterColumn<string>(
                name: "RegionCode",
                table: "Regions",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(4)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Regions",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(MAX)");
        }
    }
}
