using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Owl.Overdrive.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixCompanyProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ChangeDate",
                table: "Companies",
                newName: "ChangedDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ChangedDate",
                table: "Companies",
                newName: "ChangeDate");
        }
    }
}
