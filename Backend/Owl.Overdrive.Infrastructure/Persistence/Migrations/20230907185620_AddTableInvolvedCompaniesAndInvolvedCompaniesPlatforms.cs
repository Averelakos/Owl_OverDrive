using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Owl.Overdrive.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddTableInvolvedCompaniesAndInvolvedCompaniesPlatforms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InvolvedCompanies",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    GameId = table.Column<long>(type: "bigint", nullable: false),
                    Developer = table.Column<bool>(type: "bit", nullable: false),
                    Porting = table.Column<bool>(type: "bit", nullable: false),
                    Publisher = table.Column<bool>(type: "bit", nullable: false),
                    Supporting = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2(7)", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastUpdated = table.Column<DateTime>(type: "datetime2(7)", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CreatedById = table.Column<long>(type: "bigint", nullable: true),
                    LastUpdatedById = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvolvedCompanies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvolvedCompanies_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvolvedCompanies_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvolvedCompanies_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvolvedCompanies_Users_LastUpdatedById",
                        column: x => x.LastUpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InvolvedCompaniesPlatforms",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvolvedCompanyId = table.Column<long>(type: "bigint", nullable: false),
                    PlatformId = table.Column<long>(type: "bigint", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2(7)", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastUpdated = table.Column<DateTime>(type: "datetime2(7)", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CreatedById = table.Column<long>(type: "bigint", nullable: true),
                    LastUpdatedById = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvolvedCompaniesPlatforms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvolvedCompaniesPlatforms_InvolvedCompanies_InvolvedCompanyId",
                        column: x => x.InvolvedCompanyId,
                        principalTable: "InvolvedCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvolvedCompaniesPlatforms_Platforms_PlatformId",
                        column: x => x.PlatformId,
                        principalTable: "Platforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvolvedCompaniesPlatforms_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvolvedCompaniesPlatforms_Users_LastUpdatedById",
                        column: x => x.LastUpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvolvedCompanies_CompanyId",
                table: "InvolvedCompanies",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_InvolvedCompanies_CreatedById",
                table: "InvolvedCompanies",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_InvolvedCompanies_GameId",
                table: "InvolvedCompanies",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_InvolvedCompanies_LastUpdatedById",
                table: "InvolvedCompanies",
                column: "LastUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_InvolvedCompaniesPlatforms_CreatedById",
                table: "InvolvedCompaniesPlatforms",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_InvolvedCompaniesPlatforms_InvolvedCompanyId",
                table: "InvolvedCompaniesPlatforms",
                column: "InvolvedCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_InvolvedCompaniesPlatforms_LastUpdatedById",
                table: "InvolvedCompaniesPlatforms",
                column: "LastUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_InvolvedCompaniesPlatforms_PlatformId",
                table: "InvolvedCompaniesPlatforms",
                column: "PlatformId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvolvedCompaniesPlatforms");

            migrationBuilder.DropTable(
                name: "InvolvedCompanies");
        }
    }
}
