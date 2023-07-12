using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Owl.Overdrive.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCompanyLogoTableAndCompanyTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyLogos_Companies_CompanyId",
                table: "CompanyLogos");

            migrationBuilder.DropIndex(
                name: "IX_CompanyLogos_CompanyId",
                table: "CompanyLogos");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "CompanyLogos");

            migrationBuilder.AddColumn<long>(
                name: "CompanyLogoId",
                table: "Companies",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CompanyLogoId",
                table: "Companies",
                column: "CompanyLogoId",
                unique: true,
                filter: "[CompanyLogoId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_CompanyLogos_CompanyLogoId",
                table: "Companies",
                column: "CompanyLogoId",
                principalTable: "CompanyLogos",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_CompanyLogos_CompanyLogoId",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_CompanyLogoId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "CompanyLogoId",
                table: "Companies");

            migrationBuilder.AddColumn<long>(
                name: "CompanyId",
                table: "CompanyLogos",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_CompanyLogos_CompanyId",
                table: "CompanyLogos",
                column: "CompanyId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyLogos_Companies_CompanyId",
                table: "CompanyLogos",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
