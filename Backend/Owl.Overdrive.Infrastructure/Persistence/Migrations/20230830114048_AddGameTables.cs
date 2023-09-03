using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Owl.Overdrive.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddGameTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameModes",
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
                    table.PrimaryKey("PK_GameModes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameModes_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameModes_Users_LastUpdatedById",
                        column: x => x.LastUpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateTable(
                name: "LanguageSupportTypes",
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
                    table.PrimaryKey("PK_LanguageSupportTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LanguageSupportTypes_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LanguageSupportTypes_Users_LastUpdatedById",
                        column: x => x.LastUpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateTable(
                name: "Themes",
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
                    table.PrimaryKey("PK_Themes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Themes_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Themes_Users_LastUpdatedById",
                        column: x => x.LastUpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AlternativeNames",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameId = table.Column<long>(type: "bigint", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2(7)", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastUpdated = table.Column<DateTime>(type: "datetime2(7)", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CreatedById = table.Column<long>(type: "bigint", nullable: true),
                    LastUpdatedById = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlternativeNames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlternativeNames_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AlternativeNames_Users_LastUpdatedById",
                        column: x => x.LastUpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GameEditions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EditionGameId = table.Column<long>(type: "bigint", nullable: false),
                    ParentGameId = table.Column<long>(type: "bigint", nullable: false),
                    EditionTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2(7)", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastUpdated = table.Column<DateTime>(type: "datetime2(7)", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CreatedById = table.Column<long>(type: "bigint", nullable: true),
                    LastUpdatedById = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameEditions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameEditions_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameEditions_Users_LastUpdatedById",
                        column: x => x.LastUpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    Story = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    UpdatedGameId = table.Column<long>(type: "bigint", nullable: true),
                    UpdateGameType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GameStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GameEditionId = table.Column<long>(type: "bigint", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2(7)", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastUpdated = table.Column<DateTime>(type: "datetime2(7)", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CreatedById = table.Column<long>(type: "bigint", nullable: true),
                    LastUpdatedById = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_GameEditions_GameEditionId",
                        column: x => x.GameEditionId,
                        principalTable: "GameEditions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Games_Games_UpdatedGameId",
                        column: x => x.UpdatedGameId,
                        principalTable: "Games",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Games_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_Users_LastUpdatedById",
                        column: x => x.LastUpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GameGenres",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<long>(type: "bigint", nullable: false),
                    GenreId = table.Column<long>(type: "bigint", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2(7)", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastUpdated = table.Column<DateTime>(type: "datetime2(7)", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CreatedById = table.Column<long>(type: "bigint", nullable: true),
                    LastUpdatedById = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameGenres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameGenres_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameGenres_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameGenres_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameGenres_Users_LastUpdatedById",
                        column: x => x.LastUpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GamePlayerPerspectives",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<long>(type: "bigint", nullable: false),
                    PlayerPerspectiveId = table.Column<long>(type: "bigint", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2(7)", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastUpdated = table.Column<DateTime>(type: "datetime2(7)", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CreatedById = table.Column<long>(type: "bigint", nullable: true),
                    LastUpdatedById = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePlayerPerspectives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GamePlayerPerspectives_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GamePlayerPerspectives_PlayerPerspectives_PlayerPerspectiveId",
                        column: x => x.PlayerPerspectiveId,
                        principalTable: "PlayerPerspectives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GamePlayerPerspectives_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GamePlayerPerspectives_Users_LastUpdatedById",
                        column: x => x.LastUpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GamesGameModes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<long>(type: "bigint", nullable: false),
                    GameModeId = table.Column<long>(type: "bigint", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2(7)", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastUpdated = table.Column<DateTime>(type: "datetime2(7)", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CreatedById = table.Column<long>(type: "bigint", nullable: true),
                    LastUpdatedById = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamesGameModes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GamesGameModes_GameModes_GameModeId",
                        column: x => x.GameModeId,
                        principalTable: "GameModes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GamesGameModes_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GamesGameModes_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GamesGameModes_Users_LastUpdatedById",
                        column: x => x.LastUpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GameThemes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<long>(type: "bigint", nullable: false),
                    ThemeId = table.Column<long>(type: "bigint", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2(7)", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastUpdated = table.Column<DateTime>(type: "datetime2(7)", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CreatedById = table.Column<long>(type: "bigint", nullable: true),
                    LastUpdatedById = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameThemes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameThemes_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameThemes_Themes_ThemeId",
                        column: x => x.ThemeId,
                        principalTable: "Themes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameThemes_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameThemes_Users_LastUpdatedById",
                        column: x => x.LastUpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InvolvedCompanys",
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
                    table.PrimaryKey("PK_InvolvedCompanys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvolvedCompanys_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvolvedCompanys_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvolvedCompanys_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvolvedCompanys_Users_LastUpdatedById",
                        column: x => x.LastUpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LanguageSupports",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<long>(type: "bigint", nullable: false),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
                    LanguageSupportTypeId = table.Column<long>(type: "bigint", nullable: false),
                    GameId1 = table.Column<long>(type: "bigint", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2(7)", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastUpdated = table.Column<DateTime>(type: "datetime2(7)", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CreatedById = table.Column<long>(type: "bigint", nullable: true),
                    LastUpdatedById = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageSupports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LanguageSupports_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LanguageSupports_Games_GameId1",
                        column: x => x.GameId1,
                        principalTable: "Games",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LanguageSupports_LanguageSupportTypes_LanguageSupportTypeId",
                        column: x => x.LanguageSupportTypeId,
                        principalTable: "LanguageSupportTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LanguageSupports_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LanguageSupports_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LanguageSupports_Users_LastUpdatedById",
                        column: x => x.LastUpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Localizations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegionId = table.Column<long>(type: "bigint", nullable: false),
                    GameId = table.Column<long>(type: "bigint", nullable: false),
                    LocalizedTitle = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2(7)", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastUpdated = table.Column<DateTime>(type: "datetime2(7)", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CreatedById = table.Column<long>(type: "bigint", nullable: true),
                    LastUpdatedById = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Localizations_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Localizations_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Localizations_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Localizations_Users_LastUpdatedById",
                        column: x => x.LastUpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MultiplayerModes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampaignCoop = table.Column<bool>(type: "bit", nullable: false),
                    DropIn = table.Column<bool>(type: "bit", nullable: false),
                    LanCoop = table.Column<bool>(type: "bit", nullable: false),
                    OfflineCoop = table.Column<bool>(type: "bit", nullable: false),
                    OfflineCoopMax = table.Column<int>(type: "int", nullable: false),
                    OfflineMax = table.Column<int>(type: "int", nullable: false),
                    OnlineCoop = table.Column<bool>(type: "bit", nullable: false),
                    OnlineCoopMax = table.Column<int>(type: "int", nullable: false),
                    OnlineMax = table.Column<int>(type: "int", nullable: false),
                    SplitScreen = table.Column<bool>(type: "bit", nullable: false),
                    SplitScreenOnline = table.Column<bool>(type: "bit", nullable: false),
                    GameId = table.Column<long>(type: "bigint", nullable: false),
                    PlatformId = table.Column<long>(type: "bigint", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2(7)", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastUpdated = table.Column<DateTime>(type: "datetime2(7)", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CreatedById = table.Column<long>(type: "bigint", nullable: true),
                    LastUpdatedById = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultiplayerModes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MultiplayerModes_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MultiplayerModes_Platforms_PlatformId",
                        column: x => x.PlatformId,
                        principalTable: "Platforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MultiplayerModes_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MultiplayerModes_Users_LastUpdatedById",
                        column: x => x.LastUpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReleaseDates",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<long>(type: "bigint", nullable: false),
                    PlatformId = table.Column<long>(type: "bigint", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2(7)", nullable: true),
                    RegionId = table.Column<long>(type: "bigint", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2(7)", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastUpdated = table.Column<DateTime>(type: "datetime2(7)", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CreatedById = table.Column<long>(type: "bigint", nullable: true),
                    LastUpdatedById = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReleaseDates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReleaseDates_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReleaseDates_Platforms_PlatformId",
                        column: x => x.PlatformId,
                        principalTable: "Platforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReleaseDates_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReleaseDates_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReleaseDates_Users_LastUpdatedById",
                        column: x => x.LastUpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Websites",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<long>(type: "bigint", nullable: false),
                    Url = table.Column<string>(type: "varchar(255)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2(7)", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastUpdated = table.Column<DateTime>(type: "datetime2(7)", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CreatedById = table.Column<long>(type: "bigint", nullable: true),
                    LastUpdatedById = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Websites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Websites_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Websites_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Websites_Users_LastUpdatedById",
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
                    InvolvedCompanyId1 = table.Column<long>(type: "bigint", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2(7)", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastUpdated = table.Column<DateTime>(type: "datetime2(7)", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CreatedById = table.Column<long>(type: "bigint", nullable: true),
                    LastUpdatedById = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvolvedCompaniesPlatforms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvolvedCompaniesPlatforms_InvolvedCompanys_InvolvedCompanyId",
                        column: x => x.InvolvedCompanyId,
                        principalTable: "InvolvedCompanys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvolvedCompaniesPlatforms_InvolvedCompanys_InvolvedCompanyId1",
                        column: x => x.InvolvedCompanyId1,
                        principalTable: "InvolvedCompanys",
                        principalColumn: "Id");
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

            migrationBuilder.InsertData(
                table: "GameModes",
                columns: new[] { "Id", "CreatedById", "LastUpdatedById", "Name" },
                values: new object[,]
                {
                    { 1L, null, null, "Battle Royale" },
                    { 2L, null, null, "Co-operative" },
                    { 3L, null, null, "Massively Multiplayer Online(MMO)" },
                    { 4L, null, null, "Multiplayer" },
                    { 5L, null, null, "Single player" },
                    { 6L, null, null, "Split screen" }
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

            migrationBuilder.InsertData(
                table: "LanguageSupportTypes",
                columns: new[] { "Id", "CreatedById", "LastUpdatedById", "Name" },
                values: new object[,]
                {
                    { 1L, null, null, "Audio" },
                    { 2L, null, null, "Subtitles" },
                    { 3L, null, null, "Interface" }
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

            migrationBuilder.InsertData(
                table: "Themes",
                columns: new[] { "Id", "CreatedById", "LastUpdatedById", "Name" },
                values: new object[,]
                {
                    { 1L, null, null, "Adventure" },
                    { 2L, null, null, "Arcade" },
                    { 3L, null, null, "Card & Board Game" },
                    { 4L, null, null, "Fighting" },
                    { 5L, null, null, "Hack and slash/ Beat 'em up" },
                    { 6L, null, null, "Indie" },
                    { 7L, null, null, "Music" },
                    { 8L, null, null, "Pinball" },
                    { 9L, null, null, "Platform" },
                    { 10L, null, null, "Point-and-click" },
                    { 11L, null, null, "Puzzle" },
                    { 12L, null, null, "Quiz/Trivia" },
                    { 13L, null, null, "Racing" },
                    { 14L, null, null, "Real Time Strategy(RTS)" },
                    { 15L, null, null, "Shooter" },
                    { 16L, null, null, "Role-playening(RPG)" },
                    { 17L, null, null, "Simulator" },
                    { 18L, null, null, "Sport" },
                    { 19L, null, null, "Strategy" },
                    { 20L, null, null, "Tactical" },
                    { 21L, null, null, "Turn-based-strategy(TBS)" },
                    { 22L, null, null, "Visual Novel" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlternativeNames_CreatedById",
                table: "AlternativeNames",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AlternativeNames_GameId",
                table: "AlternativeNames",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_AlternativeNames_LastUpdatedById",
                table: "AlternativeNames",
                column: "LastUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_GameEditions_CreatedById",
                table: "GameEditions",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_GameEditions_EditionGameId",
                table: "GameEditions",
                column: "EditionGameId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GameEditions_LastUpdatedById",
                table: "GameEditions",
                column: "LastUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_GameEditions_ParentGameId",
                table: "GameEditions",
                column: "ParentGameId");

            migrationBuilder.CreateIndex(
                name: "IX_GameGenres_CreatedById",
                table: "GameGenres",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_GameGenres_GameId",
                table: "GameGenres",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GameGenres_GenreId",
                table: "GameGenres",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_GameGenres_LastUpdatedById",
                table: "GameGenres",
                column: "LastUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_GameModes_CreatedById",
                table: "GameModes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_GameModes_LastUpdatedById",
                table: "GameModes",
                column: "LastUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_GamePlayerPerspectives_CreatedById",
                table: "GamePlayerPerspectives",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_GamePlayerPerspectives_GameId",
                table: "GamePlayerPerspectives",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GamePlayerPerspectives_LastUpdatedById",
                table: "GamePlayerPerspectives",
                column: "LastUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_GamePlayerPerspectives_PlayerPerspectiveId",
                table: "GamePlayerPerspectives",
                column: "PlayerPerspectiveId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_CreatedById",
                table: "Games",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Games_GameEditionId",
                table: "Games",
                column: "GameEditionId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_LastUpdatedById",
                table: "Games",
                column: "LastUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Games_UpdatedGameId",
                table: "Games",
                column: "UpdatedGameId",
                unique: true,
                filter: "[UpdatedGameId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_GamesGameModes_CreatedById",
                table: "GamesGameModes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_GamesGameModes_GameId",
                table: "GamesGameModes",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GamesGameModes_GameModeId",
                table: "GamesGameModes",
                column: "GameModeId");

            migrationBuilder.CreateIndex(
                name: "IX_GamesGameModes_LastUpdatedById",
                table: "GamesGameModes",
                column: "LastUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_GameThemes_CreatedById",
                table: "GameThemes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_GameThemes_GameId",
                table: "GameThemes",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GameThemes_LastUpdatedById",
                table: "GameThemes",
                column: "LastUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_GameThemes_ThemeId",
                table: "GameThemes",
                column: "ThemeId");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_CreatedById",
                table: "Genres",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_LastUpdatedById",
                table: "Genres",
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
                name: "IX_InvolvedCompaniesPlatforms_InvolvedCompanyId1",
                table: "InvolvedCompaniesPlatforms",
                column: "InvolvedCompanyId1");

            migrationBuilder.CreateIndex(
                name: "IX_InvolvedCompaniesPlatforms_LastUpdatedById",
                table: "InvolvedCompaniesPlatforms",
                column: "LastUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_InvolvedCompaniesPlatforms_PlatformId",
                table: "InvolvedCompaniesPlatforms",
                column: "PlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_InvolvedCompanys_CompanyId",
                table: "InvolvedCompanys",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_InvolvedCompanys_CreatedById",
                table: "InvolvedCompanys",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_InvolvedCompanys_GameId",
                table: "InvolvedCompanys",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_InvolvedCompanys_LastUpdatedById",
                table: "InvolvedCompanys",
                column: "LastUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_LanguageSupports_CreatedById",
                table: "LanguageSupports",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_LanguageSupports_GameId",
                table: "LanguageSupports",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_LanguageSupports_GameId1",
                table: "LanguageSupports",
                column: "GameId1");

            migrationBuilder.CreateIndex(
                name: "IX_LanguageSupports_LanguageId",
                table: "LanguageSupports",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_LanguageSupports_LanguageSupportTypeId",
                table: "LanguageSupports",
                column: "LanguageSupportTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LanguageSupports_LastUpdatedById",
                table: "LanguageSupports",
                column: "LastUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_LanguageSupportTypes_CreatedById",
                table: "LanguageSupportTypes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_LanguageSupportTypes_LastUpdatedById",
                table: "LanguageSupportTypes",
                column: "LastUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Localizations_CreatedById",
                table: "Localizations",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Localizations_GameId",
                table: "Localizations",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Localizations_LastUpdatedById",
                table: "Localizations",
                column: "LastUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Localizations_RegionId",
                table: "Localizations",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_MultiplayerModes_CreatedById",
                table: "MultiplayerModes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MultiplayerModes_GameId",
                table: "MultiplayerModes",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_MultiplayerModes_LastUpdatedById",
                table: "MultiplayerModes",
                column: "LastUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MultiplayerModes_PlatformId",
                table: "MultiplayerModes",
                column: "PlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerPerspectives_CreatedById",
                table: "PlayerPerspectives",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerPerspectives_LastUpdatedById",
                table: "PlayerPerspectives",
                column: "LastUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ReleaseDates_CreatedById",
                table: "ReleaseDates",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ReleaseDates_GameId",
                table: "ReleaseDates",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_ReleaseDates_LastUpdatedById",
                table: "ReleaseDates",
                column: "LastUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ReleaseDates_PlatformId",
                table: "ReleaseDates",
                column: "PlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_ReleaseDates_RegionId",
                table: "ReleaseDates",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Themes_CreatedById",
                table: "Themes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Themes_LastUpdatedById",
                table: "Themes",
                column: "LastUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Websites_CreatedById",
                table: "Websites",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Websites_GameId",
                table: "Websites",
                column: "GameId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Websites_LastUpdatedById",
                table: "Websites",
                column: "LastUpdatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_AlternativeNames_Games_GameId",
                table: "AlternativeNames",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GameEditions_Games_EditionGameId",
                table: "GameEditions",
                column: "EditionGameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GameEditions_Games_ParentGameId",
                table: "GameEditions",
                column: "ParentGameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameEditions_Games_EditionGameId",
                table: "GameEditions");

            migrationBuilder.DropForeignKey(
                name: "FK_GameEditions_Games_ParentGameId",
                table: "GameEditions");

            migrationBuilder.DropTable(
                name: "AlternativeNames");

            migrationBuilder.DropTable(
                name: "GameGenres");

            migrationBuilder.DropTable(
                name: "GamePlayerPerspectives");

            migrationBuilder.DropTable(
                name: "GamesGameModes");

            migrationBuilder.DropTable(
                name: "GameThemes");

            migrationBuilder.DropTable(
                name: "InvolvedCompaniesPlatforms");

            migrationBuilder.DropTable(
                name: "LanguageSupports");

            migrationBuilder.DropTable(
                name: "Localizations");

            migrationBuilder.DropTable(
                name: "MultiplayerModes");

            migrationBuilder.DropTable(
                name: "ReleaseDates");

            migrationBuilder.DropTable(
                name: "Websites");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "PlayerPerspectives");

            migrationBuilder.DropTable(
                name: "GameModes");

            migrationBuilder.DropTable(
                name: "Themes");

            migrationBuilder.DropTable(
                name: "InvolvedCompanys");

            migrationBuilder.DropTable(
                name: "LanguageSupportTypes");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "GameEditions");
        }
    }
}
