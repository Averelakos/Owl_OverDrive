using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Owl.Overdrive.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddRolePermisions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RolePermissions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    Permission = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2(7)", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastUpdated = table.Column<DateTime>(type: "datetime2(7)", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CreatedById = table.Column<long>(type: "bigint", nullable: true),
                    LastUpdatedById = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolePermissions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePermissions_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RolePermissions_Users_LastUpdatedById",
                        column: x => x.LastUpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "CreatedById", "LastUpdatedById", "Permission", "RoleId" },
                values: new object[,]
                {
                    { -8L, null, null, "Display_Company", -1L },
                    { -7L, null, null, "Details_Company", -1L },
                    { -6L, null, null, "Create_Company", -1L },
                    { -5L, null, null, "Update_Company", -1L },
                    { -4L, null, null, "Display_Game", -1L },
                    { -3L, null, null, "Details_Game", -1L },
                    { -2L, null, null, "Create_Game", -1L },
                    { -1L, null, null, "Update_Game", -1L },
                    { 1L, null, null, "Display_Company", 1L },
                    { 2L, null, null, "Details_Company", 1L },
                    { 3L, null, null, "Create_Company", 1L },
                    { 4L, null, null, "Update_Company", 1L },
                    { 5L, null, null, "Display_Game", 1L },
                    { 6L, null, null, "Details_Game", 1L },
                    { 7L, null, null, "Create_Game", 1L },
                    { 8L, null, null, "Update_Game", 1L },
                    { 9L, null, null, "Display_Company", 2L },
                    { 10L, null, null, "Details_Company", 2L },
                    { 11L, null, null, "Create_Company", 2L },
                    { 12L, null, null, "Update_Company", 2L },
                    { 13L, null, null, "Display_Game", 2L },
                    { 14L, null, null, "Details_Game", 2L },
                    { 15L, null, null, "Create_Game", 2L },
                    { 16L, null, null, "Update_Game", 2L },
                    { 17L, null, null, "Display_Company", 3L },
                    { 18L, null, null, "Details_Company", 3L },
                    { 19L, null, null, "Display_Game", 3L },
                    { 20L, null, null, "Details_Game", 3L },
                    { 21L, null, null, "Display_Company", 4L },
                    { 22L, null, null, "Details_Company", 4L },
                    { 23L, null, null, "Display_Game", 4L },
                    { 24L, null, null, "Details_Game", 4L }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Name",
                value: "Default");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_CreatedById",
                table: "RolePermissions",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_LastUpdatedById",
                table: "RolePermissions",
                column: "LastUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_RoleId",
                table: "RolePermissions",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RolePermissions");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Name",
                value: "Defauls");
        }
    }
}
