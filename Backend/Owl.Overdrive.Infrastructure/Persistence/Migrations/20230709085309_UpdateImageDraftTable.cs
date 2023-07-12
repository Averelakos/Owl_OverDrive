using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Owl.Overdrive.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateImageDraftTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GuiId",
                table: "ImageDrafts",
                newName: "GuidId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GuidId",
                table: "ImageDrafts",
                newName: "GuiId");
        }
    }
}
