using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Owl.Overdrive.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Lastname = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Birthdate = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PhotoId = table.Column<long>(type: "bigint", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2(7)", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastUpdated = table.Column<DateTime>(type: "datetime2(7)", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CreatedById = table.Column<long>(type: "bigint", nullable: true),
                    LastUpdatedById = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Users_LastUpdatedById",
                        column: x => x.LastUpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompaniesStatus",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2(7)", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastUpdated = table.Column<DateTime>(type: "datetime2(7)", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CreatedById = table.Column<long>(type: "bigint", nullable: true),
                    LastUpdatedById = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompaniesStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompaniesStatus_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompaniesStatus_Users_LastUpdatedById",
                        column: x => x.LastUpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CountriesCodes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    OfficialStateName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Sovereignty = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Alpha2Code = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Alpha3Code = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NumericCode = table.Column<long>(type: "bigint", nullable: false),
                    SubdivisionCodeLinks = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    InternetccTLD = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2(7)", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastUpdated = table.Column<DateTime>(type: "datetime2(7)", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CreatedById = table.Column<long>(type: "bigint", nullable: true),
                    LastUpdatedById = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountriesCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CountriesCodes_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CountriesCodes_Users_LastUpdatedById",
                        column: x => x.LastUpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ParentCompanyId = table.Column<long>(type: "bigint", nullable: true),
                    FoundedIn = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    CountryId = table.Column<long>(type: "bigint", nullable: true),
                    StatusId = table.Column<long>(type: "bigint", nullable: true),
                    ChangeDate = table.Column<DateTime>(type: "datetime2(7)", nullable: true),
                    OfficialWebsite = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Twitter = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2(7)", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastUpdated = table.Column<DateTime>(type: "datetime2(7)", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CreatedById = table.Column<long>(type: "bigint", nullable: true),
                    LastUpdatedById = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companies_CompaniesStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "CompaniesStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Companies_Companies_ParentCompanyId",
                        column: x => x.ParentCompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Companies_CountriesCodes_CountryId",
                        column: x => x.CountryId,
                        principalTable: "CountriesCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Companies_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Companies_Users_LastUpdatedById",
                        column: x => x.LastUpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "CompaniesStatus",
                columns: new[] { "Id", "CreatedById", "Description", "LastUpdatedById", "Name" },
                values: new object[,]
                {
                    { 1L, null, "The company exists.", null, "Active" },
                    { 2L, null, "No longer existing or functioning.", null, "Defuct" },
                    { 3L, null, "Independent companies combine to form a new, singular legal entity.", null, "Merged" },
                    { 4L, null, "The process of changing the corporate image of an organisation.", null, "Renamed" }
                });

            migrationBuilder.InsertData(
                table: "CountriesCodes",
                columns: new[] { "Id", "Alpha2Code", "Alpha3Code", "CountryName", "CreatedById", "InternetccTLD", "LastUpdatedById", "NumericCode", "OfficialStateName", "Sovereignty", "SubdivisionCodeLinks" },
                values: new object[,]
                {
                    { 1L, "AL", "ALB", "Albania", null, ".al", null, 8L, "The Republic of Albania", "UN member state", "ISO 3166-2:AL" },
                    { 2L, "DZ", "DZA", "Algeria", null, ".dz", null, 12L, "The People's Democratic Republic of Algeria", "UN member state", "ISO 3166-2:DZ" },
                    { 3L, "AS", "ASM", "American Samoa", null, ".as", null, 16L, "The Territory of American Samoa", "United States", "ISO 3166-2:AS" },
                    { 4L, "AD", "AND", "Andorra", null, ".ad", null, 20L, "The Principality of Andorra", "UN member state", "ISO 3166-2:AD" },
                    { 5L, "AO", "A", "Anla", null, ".ao", null, 24L, "The Republic of Anla", "UN member state", "ISO 3166-2:AO" },
                    { 6L, "AI", "AIA", "Anguilla", null, ".ai", null, 660L, "Anguilla", "United Kingdom", "ISO 3166-2:AI" },
                    { 7L, "AQ", "ATA", "Antarctica", null, ".aq", null, 10L, "All land and ice shelves south of the 60th parallel south", "Antarctic Treaty", "ISO 3166-2:AQ" },
                    { 8L, "AG", "ATG", "Antigua and Barbuda", null, ".ag", null, 28L, "Antigua and Barbuda", "UN member state", "ISO 3166-2:AG" },
                    { 9L, "AR", "ARG", "Argentina", null, ".ar", null, 32L, "The Argentine Republic", "UN member state", "ISO 3166-2:AR" },
                    { 10L, "AM", "ARM", "Armenia", null, ".am", null, 51L, "The Republic of Armenia", "UN member state", "ISO 3166-2:AM" },
                    { 11L, "AW", "ABW", "Aruba", null, ".aw", null, 533L, "Aruba", "Netherlands", "ISO 3166-2:AW" },
                    { 12L, "AU", "AUS", "Australia", null, ".au", null, 36L, "The Commonwealth of Australia", "UN member state", "ISO 3166-2:AU" },
                    { 13L, "AT", "AUT", "Austria", null, ".at", null, 40L, "The Republic of Austria", "UN member state", "ISO 3166-2:AT" },
                    { 14L, "AZ", "AZE", "Azerbaijan", null, ".az", null, 31L, "The Republic of Azerbaijan", "UN member state", "ISO 3166-2:AZ" },
                    { 15L, "BS", "BHS", "Bahamas (the),", null, ".bs", null, 44L, "The Commonwealth of The Bahamas", "UN member state", "ISO 3166-2:BS" },
                    { 16L, "BH", "BHR", "Bahrain", null, ".bh", null, 48L, "The Kingdom of Bahrain", "UN member state", "ISO 3166-2:BH" },
                    { 17L, "BD", "BGD", "Bangladesh", null, ".bd", null, 50L, "The People's Republic of Bangladesh", "UN member state", "ISO 3166-2:BD" },
                    { 18L, "BB", "BRB", "Barbados", null, ".bb", null, 52L, "Barbados", "UN member state", "ISO 3166-2:BB" },
                    { 19L, "BY", "BLR", "Belarus", null, ".by", null, 112L, "The Republic of Belarus", "UN member state", "ISO 3166-2:BY" },
                    { 20L, "BE", "BEL", "Belgium", null, ".be", null, 56L, "The Kingdom of Belgium", "UN member state", "ISO 3166-2:BE" },
                    { 21L, "BZ", "BLZ", "Belize", null, ".bz", null, 84L, "Belize", "UN member state", "ISO 3166-2:BZ" },
                    { 22L, "BJ", "BEN", "Benin", null, ".bj", null, 204L, "The Republic of Benin", "UN member state", "ISO 3166-2:BJ" },
                    { 23L, "BM", "BMU", "Bermuda", null, ".bm", null, 60L, "Bermuda", "United Kingdom", "ISO 3166-2:BM" },
                    { 24L, "BT", "BTN", "Bhutan", null, ".bt", null, 64L, "The Kingdom of Bhutan", "UN member state", "ISO 3166-2:BT" },
                    { 25L, "BO", "BOL", "Bolivia (Plurinational State of)", null, ".bo", null, 68L, "The Plurinational State of Bolivia", "UN member state", "ISO 3166-2:BO" },
                    { 26L, "BQ", "BES", "Bonaire", null, ".bq .nl ", null, 535L, "Bonaire, Sint Eustatius and Saba", "Netherlands", "ISO 3166-2:BQ" },
                    { 29L, "BA", "BIH", "Bosnia and Herzevina", null, ".ba", null, 70L, "Bosnia and Herzevina", "UN member state", "ISO 3166-2:BA" },
                    { 30L, "BW", "BWA", "Botswana", null, ".bw", null, 72L, "The Republic of Botswana", "UN member state", "ISO 3166-2:BW" },
                    { 31L, "BV", "BVT", "Bouvet Island", null, "", null, 74L, "Bouvet Island", "Norway", "ISO 3166-2:BV" },
                    { 32L, "BR", "BRA", "Brazil", null, ".br", null, 76L, "The Federative Republic of Brazil", "UN member state", "ISO 3166-2:BR" },
                    { 33L, "IO", "IOT", "British Indian Ocean Territory (the)", null, ".io", null, 86L, "The British Indian Ocean Territory", "United Kingdom", "ISO 3166-2:IO" },
                    { 35L, "BN", "BRN", "Brunei Darussalam", null, ".bn", null, 96L, "The Nation of Brunei, the Abode of Peace", "UN member state", "ISO 3166-2:BN" },
                    { 36L, "BG", "BGR", "Bulgaria", null, ".bg", null, 100L, "The Republic of Bulgaria", "UN member state", "ISO 3166-2:BG" },
                    { 37L, "BF", "BFA", "Burkina Faso", null, ".bf", null, 854L, "Burkina Faso", "UN member state", "ISO 3166-2:BF" },
                    { 39L, "BI", "BDI", "Burundi", null, ".bi", null, 108L, "The Republic of Burundi", "UN member state", "ISO 3166-2:BI" },
                    { 40L, "CV", "CPV", "Cabo Verde ", null, ".cv", null, 132L, "The Republic of Cabo Verde", "UN member state", "ISO 3166-2:CV" },
                    { 41L, "KH", "KHM", "Cambodia", null, ".kh", null, 116L, "The Kingdom of Cambodia", "UN member state", "ISO 3166-2:KH" },
                    { 42L, "CM", "CMR", "Cameroon", null, ".cm", null, 120L, "The Republic of Cameroon", "UN member state", "ISO 3166-2:CM" },
                    { 43L, "CA", "CAN", "Canada", null, ".ca", null, 124L, "Canada", "UN member state", "ISO 3166-2:CA" },
                    { 46L, "KY", "CYM", "Cayman Islands (the)", null, ".ky", null, 136L, "The Cayman Islands", "United Kingdom", "ISO 3166-2:KY" },
                    { 47L, "CF", "CAF", "Central African Republic (the)", null, ".cf", null, 140L, "The Central African Republic", "UN member state", "ISO 3166-2:CF" },
                    { 48L, "TD", "TCD", "Chad", null, ".td", null, 148L, "The Republic of Chad", "UN member state", "ISO 3166-2:TD" },
                    { 49L, "CL", "CHL", "Chile", null, ".cl", null, 152L, "The Republic of Chile", "UN member state", "ISO 3166-2:CL" },
                    { 50L, "CN", "CHN", "China", null, ".cn", null, 156L, "The People's Republic of China", "UN member state", "ISO 3166-2:CN" },
                    { 52L, "CX", "CXR", "Christmas Island", null, ".cx", null, 162L, "The Territory of Christmas Island", "Australia", "ISO 3166-2:CX" },
                    { 53L, "CC", "CCK", "Cocos (Keeling) Islands (the)", null, ".cc", null, 166L, "The Territory of Cocos (Keeling) Islands", "Australia", "ISO 3166-2:CC" },
                    { 54L, "CO", "COL", "Colombia", null, ".co", null, 170L, "The Republic of Colombia", "UN member state", "ISO 3166-2:CO" },
                    { 55L, "KM", "COM", "Comoros (the)", null, ".km", null, 174L, "The Union of the Comoros", "UN member state", "ISO 3166-2:KM" },
                    { 56L, "CD", "COD", "Con (the Democratic Republic of the)", null, ".cd", null, 180L, "The Democratic Republic of the Con", "UN member state", "ISO 3166-2:CD" },
                    { 57L, "CG", "COG", "Con (the)", null, ".cg", null, 178L, "The Republic of the Con", "UN member state", "ISO 3166-2:CG" },
                    { 58L, "CK", "COK", "Cook Islands (the)", null, ".ck", null, 184L, "The Cook Islands", "New Zealand", "ISO 3166-2:CK" },
                    { 59L, "CR", "CRI", "Costa Rica", null, ".cr", null, 188L, "The Republic of Costa Rica", "UN member state", "ISO 3166-2:CR" },
                    { 60L, "CI", "CIV", "Côte d'Ivoire", null, ".ci", null, 384L, "The Republic of Côte d'Ivoire", "UN member state", "ISO 3166-2:CI" },
                    { 61L, "HR", "HRV", "Croatia", null, ".hr", null, 191L, "The Republic of Croatia", "UN member state", "ISO 3166-2:HR" },
                    { 62L, "CU", "CUB", "Cuba", null, ".cu", null, 192L, "The Republic of Cuba", "UN member state", "ISO 3166-2:CU" },
                    { 63L, "CW", "CUW", "Curaçao", null, ".cw", null, 531L, "The Country of Curaçao", "Netherlands", "ISO 3166-2:CW" },
                    { 64L, "CY", "CYP", "Cyprus", null, ".cy", null, 196L, "The Republic of Cyprus", "UN member state", "ISO 3166-2:CY" },
                    { 65L, "CZ", "CZE", "Czechia [i]", null, ".cz", null, 203L, "The Czech Republic", "UN member state", "ISO 3166-2:CZ" },
                    { 68L, "DK", "DNK", "Denmark", null, ".dk", null, 208L, "The Kingdom of Denmark", "UN member state", "ISO 3166-2:DK" },
                    { 69L, "DJ", "DJI", "Djibouti", null, ".dj", null, 262L, "The Republic of Djibouti", "UN member state", "ISO 3166-2:DJ" },
                    { 70L, "DM", "DMA", "Dominica", null, ".dm", null, 212L, "The Commonwealth of Dominica", "UN member state", "ISO 3166-2:DM" },
                    { 71L, "DO", "DOM", "Dominican Republic (the)", null, ".do", null, 214L, "The Dominican Republic", "UN member state", "ISO 3166-2:DO" },
                    { 73L, "EC", "ECU", "Ecuador", null, ".ec", null, 218L, "The Republic of Ecuador", "UN member state", "ISO 3166-2:EC" },
                    { 74L, "EG", "EGY", "Egypt", null, ".eg", null, 818L, "The Arab Republic of Egypt", "UN member state", "ISO 3166-2:EG" },
                    { 75L, "SV", "SLV", "El Salvador", null, ".sv", null, 222L, "The Republic of El Salvador", "UN member state", "ISO 3166-2:SV" },
                    { 76L, "GQ", "GNQ", "Equatorial Guinea", null, ".gq", null, 226L, "The Republic of Equatorial Guinea", "UN member state", "ISO 3166-2:GQ" },
                    { 77L, "ER", "ERI", "Eritrea", null, ".er", null, 232L, "The State of Eritrea", "UN member state", "ISO 3166-2:ER" },
                    { 78L, "EE", "EST", "Estonia", null, ".ee", null, 233L, "The Republic of Estonia", "UN member state", "ISO 3166-2:EE" },
                    { 79L, "SZ", "SWZ", "Eswatini ", null, ".sz", null, 748L, "The Kingdom of Eswatini", "UN member state", "ISO 3166-2:SZ" },
                    { 80L, "ET", "ETH", "Ethiopia", null, ".et", null, 231L, "The Federal Democratic Republic of Ethiopia", "UN member state", "ISO 3166-2:ET" },
                    { 81L, "FK", "FLK", "Falkland Islands (the) [Malvinas] [k]", null, ".fk", null, 238L, "The Falkland Islands", "United Kingdom", "ISO 3166-2:FK" },
                    { 82L, "FO", "FRO", "Faroe Islands (the)", null, ".fo", null, 234L, "The Faroe Islands", "Denmark", "ISO 3166-2:FO" },
                    { 83L, "FJ", "FJI", "Fiji", null, ".fj", null, 242L, "The Republic of Fiji", "UN member state", "ISO 3166-2:FJ" },
                    { 84L, "FI", "FIN", "Finland", null, ".fi", null, 246L, "The Republic of Finland", "UN member state", "ISO 3166-2:FI" },
                    { 85L, "FR", "FRA", "France ", null, ".fr", null, 250L, "The French Republic", "UN member state", "ISO 3166-2:FR" },
                    { 86L, "GF", "GUF", "French Guiana", null, ".gf", null, 254L, "Guyane", "France", "ISO 3166-2:GF" },
                    { 87L, "PF", "PYF", "French Polynesia", null, ".pf", null, 258L, "French Polynesia", "France", "ISO 3166-2:PF" },
                    { 88L, "TF", "ATF", "French Southern Territories (the) [m]", null, ".tf", null, 260L, "The French Southern and Antarctic Lands", "France", "ISO 3166-2:TF" },
                    { 89L, "GA", "GAB", "Gabon", null, ".ga", null, 266L, "The Gabonese Republic", "UN member state", "ISO 3166-2:GA" },
                    { 90L, "GM", "GMB", "Gambia (the)", null, ".gm", null, 270L, "The Republic of The Gambia", "UN member state", "ISO 3166-2:GM" },
                    { 91L, "GE", "GEO", "Georgia", null, ".ge", null, 268L, "Georgia", "UN member state", "ISO 3166-2:GE" },
                    { 92L, "DE", "DEU", "Germany", null, ".de", null, 276L, "The Federal Republic of Germany", "UN member state", "ISO 3166-2:DE" },
                    { 93L, "GH", "GHA", "Ghana", null, ".gh", null, 288L, "The Republic of Ghana", "UN member state", "ISO 3166-2:GH" },
                    { 94L, "GI", "GIB", "Gibraltar", null, ".gi", null, 292L, "Gibraltar", "United Kingdom", "ISO 3166-2:GI" },
                    { 96L, "GR", "GRC", "Greece", null, ".gr", null, 300L, "The Hellenic Republic", "UN member state", "ISO 3166-2:GR" },
                    { 97L, "GL", "GRL", "Greenland", null, ".gl", null, 304L, "Kalaallit Nunaat", "Denmark", "ISO 3166-2:GL" },
                    { 98L, "GD", "GRD", "Grenada", null, ".gd", null, 308L, "Grenada", "UN member state", "ISO 3166-2:GD" },
                    { 99L, "GP", "GLP", "Guadeloupe", null, ".gp", null, 312L, "Guadeloupe", "France", "ISO 3166-2:GP" },
                    { 100L, "GU", "GUM", "Guam", null, ".gu", null, 316L, "The Territory of Guam", "United States", "ISO 3166-2:GU" },
                    { 101L, "GT", "GTM", "Guatemala", null, ".gt", null, 320L, "The Republic of Guatemala", "UN member state", "ISO 3166-2:GT" },
                    { 102L, "GG", "GGY", "Guernsey", null, ".gg", null, 831L, "The Bailiwick of Guernsey", "British Crown", "ISO 3166-2:GG" },
                    { 103L, "GN", "GIN", "Guinea", null, ".gn", null, 324L, "The Republic of Guinea", "UN member state", "ISO 3166-2:GN" },
                    { 104L, "GW", "GNB", "Guinea-Bissau", null, ".gw", null, 624L, "The Republic of Guinea-Bissau", "UN member state", "ISO 3166-2:GW" },
                    { 105L, "GY", "GUY", "Guyana", null, ".gy", null, 328L, "The Co-operative Republic of Guyana", "UN member state", "ISO 3166-2:GY" },
                    { 106L, "HT", "HTI", "Haiti", null, ".ht", null, 332L, "The Republic of Haiti", "UN member state", "ISO 3166-2:HT" },
                    { 107L, "HM", "HMD", "Heard Island and McDonald Islands", null, ".hm", null, 334L, "The Territory of Heard Island and McDonald Islands", "Australia", "ISO 3166-2:HM" },
                    { 108L, "VA", "VAT", "Holy See (the) [n]", null, ".va", null, 336L, "The Holy See", "UN observer state", "ISO 3166-2:VA" },
                    { 109L, "HN", "HND", "Honduras", null, ".hn", null, 340L, "The Republic of Honduras", "UN member state", "ISO 3166-2:HN" },
                    { 110L, "HK", "HKG", "Hong Kong", null, ".hk", null, 344L, "The Hong Kong Special Administrative Region of China[10]", "China", "ISO 3166-2:HK" },
                    { 111L, "HU", "HUN", "Hungary", null, ".hu", null, 348L, "Hungary", "UN member state", "ISO 3166-2:HU" },
                    { 112L, "IS", "ISL", "Iceland", null, ".is", null, 352L, "Iceland", "UN member state", "ISO 3166-2:IS" },
                    { 113L, "IN", "IND", "India", null, ".in", null, 356L, "The Republic of India", "UN member state", "ISO 3166-2:IN" },
                    { 114L, "ID", "IDN", "Indonesia", null, ".id", null, 360L, "The Republic of Indonesia", "UN member state", "ISO 3166-2:ID" },
                    { 115L, "IR", "IRN", "Iran (Islamic Republic of)", null, ".ir", null, 364L, "The Islamic Republic of Iran", "UN member state", "ISO 3166-2:IR" },
                    { 116L, "IQ", "IRQ", "Iraq", null, ".iq", null, 368L, "The Republic of Iraq", "UN member state", "ISO 3166-2:IQ" },
                    { 117L, "IE", "IRL", "Ireland", null, ".ie", null, 372L, "Ireland", "UN member state", "ISO 3166-2:IE" },
                    { 118L, "IM", "IMN", "Isle of Man", null, ".im", null, 833L, "The Isle of Man", "British Crown", "ISO 3166-2:IM" },
                    { 119L, "IL", "ISR", "Israel", null, ".il", null, 376L, "The State of Israel", "UN member state", "ISO 3166-2:IL" },
                    { 120L, "IT", "ITA", "Italy", null, ".it", null, 380L, "The Italian Republic", "UN member state", "ISO 3166-2:IT" },
                    { 122L, "JM", "JAM", "Jamaica", null, ".jm", null, 388L, "Jamaica", "UN member state", "ISO 3166-2:JM" },
                    { 124L, "JP", "JPN", "Japan", null, ".jp", null, 392L, "Japan", "UN member state", "ISO 3166-2:JP" },
                    { 125L, "JE", "JEY", "Jersey", null, ".je", null, 832L, "The Bailiwick of Jersey", "British Crown", "ISO 3166-2:JE" },
                    { 126L, "JO", "JOR", "Jordan", null, ".jo", null, 400L, "The Hashemite Kingdom of Jordan", "UN member state", "ISO 3166-2:JO" },
                    { 127L, "KZ", "KAZ", "Kazakhstan", null, ".kz", null, 398L, "The Republic of Kazakhstan", "UN member state", "ISO 3166-2:KZ" },
                    { 128L, "KE", "KEN", "Kenya", null, ".ke", null, 404L, "The Republic of Kenya", "UN member state", "ISO 3166-2:KE" },
                    { 129L, "KI", "KIR", "Kiribati", null, ".ki", null, 296L, "The Republic of Kiribati", "UN member state", "ISO 3166-2:KI" },
                    { 130L, "KP", "PRK", "Korea (the Democratic People's Republic of)", null, ".kp", null, 408L, "The Democratic People's Republic of Korea", "UN member state", "ISO 3166-2:KP" },
                    { 131L, "KR", "KOR", "Korea (the Republic of) [p]", null, ".kr", null, 410L, "The Republic of Korea", "UN member state", "ISO 3166-2:KR" },
                    { 132L, "KW", "KWT", "Kuwait", null, ".kw", null, 414L, "The State of Kuwait", "UN member state", "ISO 3166-2:KW" },
                    { 133L, "KG", "KGZ", "Kyrgyzstan", null, ".kg", null, 417L, "The Kyrgyz Republic", "UN member state", "ISO 3166-2:KG" },
                    { 134L, "LA", "LAO", "Lao People's Democratic Republic (the)", null, ".la", null, 418L, "The Lao People's Democratic Republic", "UN member state", "ISO 3166-2:LA" },
                    { 135L, "LV", "LVA", "Latvia", null, ".lv", null, 428L, "The Republic of Latvia", "UN member state", "ISO 3166-2:LV" },
                    { 136L, "LB", "LBN", "Lebanon", null, ".lb", null, 422L, "The Lebanese Republic", "UN member state", "ISO 3166-2:LB" },
                    { 137L, "LS", "LSO", "Lesotho", null, ".ls", null, 426L, "The Kingdom of Lesotho", "UN member state", "ISO 3166-2:LS" },
                    { 138L, "LR", "LBR", "Liberia", null, ".lr", null, 430L, "The Republic of Liberia", "UN member state", "ISO 3166-2:LR" },
                    { 139L, "LY", "LBY", "Libya", null, ".ly", null, 434L, "The State of Libya", "UN member state", "ISO 3166-2:LY" },
                    { 140L, "LI", "LIE", "Liechtenstein", null, ".li", null, 438L, "The Principality of Liechtenstein", "UN member state", "ISO 3166-2:LI" },
                    { 141L, "LT", "LTU", "Lithuania", null, ".lt", null, 440L, "The Republic of Lithuania", "UN member state", "ISO 3166-2:LT" },
                    { 142L, "LU", "LUX", "Luxembourg", null, ".lu", null, 442L, "The Grand Duchy of Luxembourg", "UN member state", "ISO 3166-2:LU" },
                    { 143L, "MO", "MAC", "Macao ", null, ".mo", null, 446L, "The Macao Special Administrative Region of China[11]", "China", "ISO 3166-2:MO" },
                    { 144L, "MK", "MKD", "North Macedonia [s]", null, ".mk", null, 807L, "The Republic of North Macedonia[12]", "UN member state", "ISO 3166-2:MK" },
                    { 145L, "MG", "MDG", "Madagascar", null, ".mg", null, 450L, "The Republic of Madagascar", "UN member state", "ISO 3166-2:MG" },
                    { 146L, "MW", "MWI", "Malawi", null, ".mw", null, 454L, "The Republic of Malawi", "UN member state", "ISO 3166-2:MW" },
                    { 147L, "MY", "MYS", "Malaysia", null, ".my", null, 458L, "Malaysia", "UN member state", "ISO 3166-2:MY" },
                    { 148L, "MV", "MDV", "Maldives", null, ".mv", null, 462L, "The Republic of Maldives", "UN member state", "ISO 3166-2:MV" },
                    { 149L, "ML", "MLI", "Mali", null, ".ml", null, 466L, "The Republic of Mali", "UN member state", "ISO 3166-2:ML" },
                    { 150L, "MT", "MLT", "Malta", null, ".mt", null, 470L, "The Republic of Malta", "UN member state", "ISO 3166-2:MT" },
                    { 151L, "MH", "MHL", "Marshall Islands (the)", null, ".mh", null, 584L, "The Republic of the Marshall Islands", "UN member state", "ISO 3166-2:MH" },
                    { 152L, "MQ", "MTQ", "Martinique", null, ".mq", null, 474L, "Martinique", "France", "ISO 3166-2:MQ" },
                    { 153L, "MR", "MRT", "Mauritania", null, ".mr", null, 478L, "The Islamic Republic of Mauritania", "UN member state", "ISO 3166-2:MR" },
                    { 154L, "MU", "MUS", "Mauritius", null, ".mu", null, 480L, "The Republic of Mauritius", "UN member state", "ISO 3166-2:MU" },
                    { 155L, "YT", "MYT", "Mayotte", null, ".yt", null, 175L, "The Department of Mayotte", "France", "ISO 3166-2:YT" },
                    { 156L, "MX", "MEX", "Mexico", null, ".mx", null, 484L, "The United Mexican States", "UN member state", "ISO 3166-2:MX" },
                    { 157L, "FM", "FSM", "Micronesia (Federated States of)", null, ".fm", null, 583L, "The Federated States of Micronesia", "UN member state", "ISO 3166-2:FM" },
                    { 158L, "MD", "MDA", "Moldova (the Republic of)", null, ".md", null, 498L, "The Republic of Moldova", "UN member state", "ISO 3166-2:MD" },
                    { 159L, "MC", "MCO", "Monaco", null, ".mc", null, 492L, "The Principality of Monaco", "UN member state", "ISO 3166-2:MC" },
                    { 160L, "MN", "MNG", "Monlia", null, ".mn", null, 496L, "Monlia", "UN member state", "ISO 3166-2:MN" },
                    { 161L, "ME", "MNE", "Montenegro", null, ".me", null, 499L, "Montenegro", "UN member state", "ISO 3166-2:ME" },
                    { 162L, "MS", "MSR", "Montserrat", null, ".ms", null, 500L, "Montserrat", "United Kingdom", "ISO 3166-2:MS" },
                    { 163L, "MA", "MAR", "Morocco", null, ".ma", null, 504L, "The Kingdom of Morocco", "UN member state", "ISO 3166-2:MA" },
                    { 164L, "MZ", "MOZ", "Mozambique", null, ".mz", null, 508L, "The Republic of Mozambique", "UN member state", "ISO 3166-2:MZ" },
                    { 165L, "MM", "MMR", "Myanmar ", null, ".mm", null, 104L, "The Republic of the Union of Myanmar", "UN member state", "ISO 3166-2:MM" },
                    { 166L, "NA", "NAM", "Namibia", null, ".na", null, 516L, "The Republic of Namibia", "UN member state", "ISO 3166-2:NA" },
                    { 167L, "NR", "NRU", "Nauru", null, ".nr", null, 520L, "The Republic of Nauru", "UN member state", "ISO 3166-2:NR" },
                    { 168L, "NP", "NPL", "Nepal", null, ".np", null, 524L, "The Federal Democratic Republic of Nepal", "UN member state", "ISO 3166-2:NP" },
                    { 169L, "NL", "NLD", "Netherlands (the)", null, ".nl", null, 528L, "The Kingdom of the Netherlands", "UN member state", "ISO 3166-2:NL" },
                    { 170L, "NC", "NCL", "New Caledonia", null, ".nc", null, 540L, "New Caledonia", "France", "ISO 3166-2:NC" },
                    { 171L, "NZ", "NZL", "New Zealand", null, ".nz", null, 554L, "New Zealand", "UN member state", "ISO 3166-2:NZ" },
                    { 172L, "NI", "NIC", "Nicaragua", null, ".ni", null, 558L, "The Republic of Nicaragua", "UN member state", "ISO 3166-2:NI" },
                    { 173L, "NE", "NER", "Niger (the)", null, ".ne", null, 562L, "The Republic of the Niger", "UN member state", "ISO 3166-2:NE" },
                    { 174L, "NG", "NGA", "Nigeria", null, ".ng", null, 566L, "The Federal Republic of Nigeria", "UN member state", "ISO 3166-2:NG" },
                    { 175L, "NU", "NIU", "Niue", null, ".nu", null, 570L, "Niue", "New Zealand", "ISO 3166-2:NU" },
                    { 176L, "NF", "NFK", "Norfolk Island", null, ".nf", null, 574L, "The Territory of Norfolk Island", "Australia", "ISO 3166-2:NF" },
                    { 178L, "MP", "MNP", "Northern Mariana Islands (the)", null, ".mp", null, 580L, "The Commonwealth of the Northern Mariana Islands", "United States", "ISO 3166-2:MP" },
                    { 179L, "NO", "NOR", "Norway", null, ".no", null, 578L, "The Kingdom of Norway", "UN member state", "ISO 3166-2:NO" },
                    { 180L, "OM", "OMN", "Oman", null, ".om", null, 512L, "The Sultanate of Oman", "UN member state", "ISO 3166-2:OM" },
                    { 181L, "PK", "PAK", "Pakistan", null, ".pk", null, 586L, "The Islamic Republic of Pakistan", "UN member state", "ISO 3166-2:PK" },
                    { 182L, "PW", "PLW", "Palau", null, ".pw", null, 585L, "The Republic of Palau", "UN member state", "ISO 3166-2:PW" },
                    { 183L, "PS", "PSE", "Palestine, State of", null, ".ps", null, 275L, "The State of Palestine", "UN observer state", "ISO 3166-2:PS" },
                    { 184L, "PA", "PAN", "Panama", null, ".pa", null, 591L, "The Republic of Panamá", "UN member state", "ISO 3166-2:PA" },
                    { 185L, "PG", "PNG", "Papua New Guinea", null, ".pg", null, 598L, "The Independent State of Papua New Guinea", "UN member state", "ISO 3166-2:PG" },
                    { 186L, "PY", "PRY", "Paraguay", null, ".py", null, 600L, "The Republic of Paraguay", "UN member state", "ISO 3166-2:PY" },
                    { 188L, "PE", "PER", "Peru", null, ".pe", null, 604L, "The Republic of Perú", "UN member state", "ISO 3166-2:PE" },
                    { 189L, "PH", "PHL", "Philippines (the)", null, ".ph", null, 608L, "The Republic of the Philippines", "UN member state", "ISO 3166-2:PH" },
                    { 190L, "PN", "PCN", "Pitcairn [u]", null, ".pn", null, 612L, "The Pitcairn, Henderson, Ducie and Oeno Islands", "United Kingdom", "ISO 3166-2:PN" },
                    { 191L, "PL", "POL", "Poland", null, ".pl", null, 616L, "The Republic of Poland", "UN member state", "ISO 3166-2:PL" },
                    { 192L, "PT", "PRT", "Portugal", null, ".pt", null, 620L, "The Portuguese Republic", "UN member state", "ISO 3166-2:PT" },
                    { 193L, "PR", "PRI", "Puerto Rico", null, ".pr", null, 630L, "The Commonwealth of Puerto Rico", "United States", "ISO 3166-2:PR" },
                    { 194L, "QA", "QAT", "Qatar", null, ".qa", null, 634L, "The State of Qatar", "UN member state", "ISO 3166-2:QA" },
                    { 198L, "RE", "REU", "Réunion", null, ".re", null, 638L, "Réunion", "France", "ISO 3166-2:RE" },
                    { 199L, "RO", "ROU", "Romania", null, ".ro", null, 642L, "Romania", "UN member state", "ISO 3166-2:RO" },
                    { 200L, "RU", "RUS", "Russian Federation (the)", null, ".ru", null, 643L, "The Russian Federation", "UN member state", "ISO 3166-2:RU" },
                    { 201L, "RW", "RWA", "Rwanda", null, ".rw", null, 646L, "The Republic of Rwanda", "UN member state", "ISO 3166-2:RW" },
                    { 204L, "BL", "BLM", "Saint Barthélemy", null, ".bl", null, 652L, "The Collectivity of Saint-Barthélemy", "France", "ISO 3166-2:BL" },
                    { 205L, "SH", "SHN", "Saint Helena", null, ".sh", null, 654L, "Saint Helena, Ascension and Tristan da Cunha", "United Kingdom", "ISO 3166-2:SH" },
                    { 208L, "KN", "KNA", "Saint Kitts and Nevis", null, ".kn", null, 659L, "Saint Kitts and Nevis", "UN member state", "ISO 3166-2:KN" },
                    { 209L, "LC", "LCA", "Saint Lucia", null, ".lc", null, 662L, "Saint Lucia", "UN member state", "ISO 3166-2:LC" },
                    { 210L, "MF", "MAF", "Saint Martin (French part)", null, ".mf", null, 663L, "The Collectivity of Saint-Martin", "France", "ISO 3166-2:MF" },
                    { 211L, "PM", "SPM", "Saint Pierre and Miquelon", null, ".pm", null, 666L, "The Overseas Collectivity of Saint-Pierre and Miquelon", "France", "ISO 3166-2:PM" },
                    { 212L, "VC", "VCT", "Saint Vincent and the Grenadines", null, ".vc", null, 670L, "Saint Vincent and the Grenadines", "UN member state", "ISO 3166-2:VC" },
                    { 213L, "WS", "WSM", "Samoa", null, ".ws", null, 882L, "The Independent State of Samoa", "UN member state", "ISO 3166-2:WS" },
                    { 214L, "SM", "SMR", "San Marino", null, ".sm", null, 674L, "The Republic of San Marino", "UN member state", "ISO 3166-2:SM" },
                    { 215L, "ST", "STP", "Sao Tome and Principe", null, ".st", null, 678L, "The Democratic Republic of São Tomé and Príncipe", "UN member state", "ISO 3166-2:ST" },
                    { 216L, "SA", "SAU", "Saudi Arabia", null, ".sa", null, 682L, "The Kingdom of Saudi Arabia", "UN member state", "ISO 3166-2:SA" },
                    { 217L, "SN", "SEN", "Senegal", null, ".sn", null, 686L, "The Republic of Senegal", "UN member state", "ISO 3166-2:SN" },
                    { 218L, "RS", "SRB", "Serbia", null, ".rs", null, 688L, "The Republic of Serbia", "UN member state", "ISO 3166-2:RS" },
                    { 219L, "SC", "SYC", "Seychelles", null, ".sc", null, 690L, "The Republic of Seychelles", "UN member state", "ISO 3166-2:SC" },
                    { 220L, "SL", "SLE", "Sierra Leone", null, ".sl", null, 694L, "The Republic of Sierra Leone", "UN member state", "ISO 3166-2:SL" },
                    { 221L, "SG", "SGP", "Singapore", null, ".sg", null, 702L, "The Republic of Singapore", "UN member state", "ISO 3166-2:SG" },
                    { 223L, "SX", "SXM", "Sint Maarten (Dutch part)", null, ".sx", null, 534L, "Sint Maarten", "Netherlands", "ISO 3166-2:SX" },
                    { 224L, "SK", "SVK", "Slovakia", null, ".sk", null, 703L, "The Slovak Republic", "UN member state", "ISO 3166-2:SK" },
                    { 225L, "SI", "SVN", "Slovenia", null, ".si", null, 705L, "The Republic of Slovenia", "UN member state", "ISO 3166-2:SI" },
                    { 226L, "SB", "SLB", "Solomon Islands", null, ".sb", null, 90L, "The Solomon Islands", "UN member state", "ISO 3166-2:SB" },
                    { 227L, "SO", "SOM", "Somalia", null, ".so", null, 706L, "The Federal Republic of Somalia", "UN member state", "ISO 3166-2:SO" },
                    { 228L, "ZA", "ZAF", "South Africa", null, ".za", null, 710L, "The Republic of South Africa", "UN member state", "ISO 3166-2:ZA" },
                    { 229L, "GS", "SGS", "South Georgia and the South Sandwich Islands", null, ".gs", null, 239L, "South Georgia and the South Sandwich Islands", "United Kingdom", "ISO 3166-2:GS" },
                    { 231L, "SS", "SSD", "South Sudan", null, ".ss", null, 728L, "The Republic of South Sudan", "UN member state", "ISO 3166-2:SS" },
                    { 232L, "ES", "ESP", "Spain", null, ".es", null, 724L, "The Kingdom of Spain", "UN member state", "ISO 3166-2:ES" },
                    { 233L, "LK", "LKA", "Sri Lanka", null, ".lk", null, 144L, "The Democratic Socialist Republic of Sri Lanka", "UN member state", "ISO 3166-2:LK" },
                    { 234L, "SD", "SDN", "Sudan (the)", null, ".sd", null, 729L, "The Republic of the Sudan", "UN member state", "ISO 3166-2:SD" },
                    { 235L, "SR", "SUR", "Suriname", null, ".sr", null, 740L, "The Republic of Suriname", "UN member state", "ISO 3166-2:SR" },
                    { 236L, "SJ", "SJM", "Svalbard", null, "", null, 744L, "Svalbard and Jan Mayen", "Norway", "ISO 3166-2:SJ" },
                    { 238L, "SE", "SWE", "Sweden", null, ".se", null, 752L, "The Kingdom of Sweden", "UN member state", "ISO 3166-2:SE" },
                    { 239L, "CH", "CHE", "Switzerland", null, ".ch", null, 756L, "The Swiss Confederation", "UN member state", "ISO 3166-2:CH" },
                    { 240L, "SY", "SYR", "Syrian Arab Republic (the) [x]", null, ".sy", null, 760L, "The Syrian Arab Republic", "UN member state", "ISO 3166-2:SY" },
                    { 241L, "TW", "TWN", "Taiwan (Province of China) [y]", null, ".tw", null, 158L, "The Republic of China", "Disputed [z]", "ISO 3166-2:TW" },
                    { 242L, "TJ", "TJK", "Tajikistan", null, ".tj", null, 762L, "The Republic of Tajikistan", "UN member state", "ISO 3166-2:TJ" },
                    { 243L, "TZ", "TZA", "Tanzania, the United Republic of", null, ".tz", null, 834L, "The United Republic of Tanzania", "UN member state", "ISO 3166-2:TZ" },
                    { 244L, "TH", "THA", "Thailand", null, ".th", null, 764L, "The Kingdom of Thailand", "UN member state", "ISO 3166-2:TH" },
                    { 245L, "TL", "TLS", "Timor-Leste ", null, ".tl", null, 626L, "The Democratic Republic of Timor-Leste", "UN member state", "ISO 3166-2:TL" },
                    { 246L, "TG", "T", "To", null, ".tg", null, 768L, "The Tolese Republic", "UN member state", "ISO 3166-2:TG" },
                    { 247L, "TK", "TKL", "Tokelau", null, ".tk", null, 772L, "Tokelau", "New Zealand", "ISO 3166-2:TK" },
                    { 248L, "TO", "TON", "Tonga", null, ".to", null, 776L, "The Kingdom of Tonga", "UN member state", "ISO 3166-2:TO" },
                    { 249L, "TT", "TTO", "Trinidad and Toba", null, ".tt", null, 780L, "The Republic of Trinidad and Toba", "UN member state", "ISO 3166-2:TT" },
                    { 250L, "TN", "TUN", "Tunisia", null, ".tn", null, 788L, "The Republic of Tunisia", "UN member state", "ISO 3166-2:TN" },
                    { 251L, "TR", "TUR", "Türkiye [ab]", null, ".tr", null, 792L, "The Republic of Türkiye", "UN member state", "ISO 3166-2:TR" },
                    { 252L, "TM", "TKM", "Turkmenistan", null, ".tm", null, 795L, "Turkmenistan", "UN member state", "ISO 3166-2:TM" },
                    { 253L, "TC", "TCA", "Turks and Caicos Islands (the)", null, ".tc", null, 796L, "The Turks and Caicos Islands", "United Kingdom", "ISO 3166-2:TC" },
                    { 254L, "TV", "TUV", "Tuvalu", null, ".tv", null, 798L, "Tuvalu", "UN member state", "ISO 3166-2:TV" },
                    { 255L, "UG", "UGA", "Uganda", null, ".ug", null, 800L, "The Republic of Uganda", "UN member state", "ISO 3166-2:UG" },
                    { 256L, "UA", "UKR", "Ukraine", null, ".ua", null, 804L, "Ukraine", "UN member state", "ISO 3166-2:UA" },
                    { 257L, "AE", "ARE", "United Arab Emirates (the)", null, ".ae", null, 784L, "The United Arab Emirates", "UN member state", "ISO 3166-2:AE" },
                    { 258L, "GB", "GBR", "United Kingdom of Great Britain and Northern Ireland (the)", null, ".gb .uk ", null, 826L, "The United Kingdom of Great Britain and Northern Ireland", "UN member state", "ISO 3166-2:GB" },
                    { 259L, "UM", "UMI", "United States Minor Outlying Islands (the) [ad]", null, "", null, 581L, "Baker Island, Howland Island, Jarvis Island, Johnston Atoll, Kingman Reef, Midway Atoll, Navassa Island, Palmyra Atoll, and Wake Island", "United States", "ISO 3166-2:UM" },
                    { 260L, "US", "USA", "United States of America (the)", null, ".us", null, 840L, "The United States of America", "UN member state", "ISO 3166-2:US" },
                    { 262L, "UY", "URY", "Uruguay", null, ".uy", null, 858L, "The Oriental Republic of Uruguay", "UN member state", "ISO 3166-2:UY" },
                    { 263L, "UZ", "UZB", "Uzbekistan", null, ".uz", null, 860L, "The Republic of Uzbekistan", "UN member state", "ISO 3166-2:UZ" },
                    { 264L, "VU", "VUT", "Vanuatu", null, ".vu", null, 548L, "The Republic of Vanuatu", "UN member state", "ISO 3166-2:VU" },
                    { 266L, "VE", "VEN", "Venezuela (Bolivarian Republic of)", null, ".ve", null, 862L, "The Bolivarian Republic of Venezuela", "UN member state", "ISO 3166-2:VE" },
                    { 267L, "VN", "VNM", "Viet Nam ", null, ".vn", null, 704L, "The Socialist Republic of Viet Nam", "UN member state", "ISO 3166-2:VN" },
                    { 268L, "VG", "VGB", "Virgin Islands (British) [ag]", null, ".vg", null, 92L, "The Virgin Islands", "United Kingdom", "ISO 3166-2:VG" },
                    { 269L, "VI", "VIR", "Virgin Islands (U.S.) [ah]", null, ".vi", null, 850L, "The Virgin Islands of the United States", "United States", "ISO 3166-2:VI" },
                    { 270L, "WF", "WLF", "Wallis and Futuna", null, ".wf", null, 876L, "The Territory of the Wallis and Futuna Islands", "France", "ISO 3166-2:WF" },
                    { 271L, "EH", "ESH", "Western Sahara [ai]", null, "", null, 732L, "The Sahrawi Arab Democratic Republic", "Disputed [aj]", "ISO 3166-2:EH" },
                    { 272L, "YE", "YEM", "Yemen", null, ".ye", null, 887L, "The Republic of Yemen", "UN member state", "ISO 3166-2:YE" },
                    { 273L, "ZM", "ZMB", "Zambia", null, ".zm", null, 894L, "The Republic of Zambia", "UN member state", "ISO 3166-2:ZM" },
                    { 274L, "ZW", "ZWE", "Zimbabwe", null, ".zw", null, 716L, "The Republic of Zimbabwe", "UN member state", "ISO 3166-2:ZW" },
                    { 275L, "BQ", "BES", "Sint Eustatius", null, ".bq .nl ", null, 535L, "Bonaire, Sint Eustatius and Saba", "Netherlands", "ISO 3166-2:BQ" },
                    { 280L, "BN", "BRN", "Brunei Darussalam [e]", null, ".bn", null, 96L, "The Nation of Brunei, the Abode of Peace", "UN member state", "ISO 3166-2:BN" },
                    { 281L, "CV", "CPV", "Cabo Verde ", null, ".cv", null, 132L, "The Republic of Cabo Verde", "UN member state", "ISO 3166-2:CV" },
                    { 282L, "CR", "CRI", "Costa Rica", null, ".cr", null, 188L, "The Republic of Costa Rica", "UN member state", "ISO 3166-2:CR" },
                    { 283L, "CW", "CUW", "Curaçao", null, ".cw", null, 531L, "The Country of Curaçao", "Netherlands", "ISO 3166-2:CW" },
                    { 286L, "SH", "SHN", "Tristan da Cunha", null, ".sh", null, 654L, "Saint Helena, Ascension and Tristan da Cunha", "United Kingdom", "ISO 3166-2:SH" },
                    { 287L, "SJ", "SJM", "Svalbard", null, "", null, 744L, "Svalbard and Jan Mayen", "Norway", "ISO 3166-2:SJ" },
                    { 288L, "AF", "AFG", "Afghanistan", null, ".af", null, 4L, "The Islamic Republic of Afghanistan", "UN member state", "ISO 3166-2:AF" },
                    { 289L, "AX", "ALA", "Åland Islands", null, ".ax", null, 248L, "Åland", "Finland", "ISO 3166-2:AX" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CountryId",
                table: "Companies",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CreatedById",
                table: "Companies",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_LastUpdatedById",
                table: "Companies",
                column: "LastUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_ParentCompanyId",
                table: "Companies",
                column: "ParentCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_StatusId",
                table: "Companies",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_CompaniesStatus_CreatedById",
                table: "CompaniesStatus",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CompaniesStatus_LastUpdatedById",
                table: "CompaniesStatus",
                column: "LastUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CountriesCodes_CreatedById",
                table: "CountriesCodes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CountriesCodes_LastUpdatedById",
                table: "CountriesCodes",
                column: "LastUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CreatedById",
                table: "Users",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Users_LastUpdatedById",
                table: "Users",
                column: "LastUpdatedById");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "CompaniesStatus");

            migrationBuilder.DropTable(
                name: "CountriesCodes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
