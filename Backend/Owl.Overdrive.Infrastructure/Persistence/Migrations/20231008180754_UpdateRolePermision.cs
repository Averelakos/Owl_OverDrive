using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Owl.Overdrive.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRolePermision : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "CreatedById", "LastUpdatedById", "Permission", "RoleId" },
                values: new object[,]
                {
                    { 25L, null, null, "Display_User", 1L },
                    { 26L, null, null, "Update_User", 1L }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 25L);

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 26L);
        }
    }
}
