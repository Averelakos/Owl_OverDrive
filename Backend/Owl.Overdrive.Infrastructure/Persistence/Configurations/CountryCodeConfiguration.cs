using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Owl.Overdrive.Domain.Entities;

namespace Owl.Overdrive.Infrastructure.Persistence.Configurations
{
    public class CountryCodeConfiguration :BaseEntityConfiguration, IEntityTypeConfiguration<CountryCode>
    {
        public CountryCodeConfiguration() : base()
        {
            
        }

        public void Configure(EntityTypeBuilder<CountryCode> builder)
        {
            ApplyConfiguration(builder);
            ConfigurationBase(builder);
        }

        public static void ApplyConfiguration(EntityTypeBuilder<CountryCode> builder)
        {
            // Table Name
            builder.ToTable("CountriesCodes");

            // Properties parameters
            builder.Property(p => p.CountryName).HasMaxLength(255);
            builder.Property(p => p.OfficialStateName).HasMaxLength(255);
            builder.Property(p => p.Sovereignty).HasMaxLength(255);
            builder.Property(p => p.Alpha2Code).HasMaxLength(255);
            builder.Property(p => p.Alpha3Code).HasMaxLength(255);
            builder.Property(p => p.SubdivisionCodeLinks).HasMaxLength(255);
            builder.Property(p => p.InternetccTLD).HasMaxLength(255);

            Seed(builder);

        }

        private static void Seed(EntityTypeBuilder<CountryCode> builder)
        {
            builder.HasData(new CountryCode()
            {
                Id = 1,
                CountryName = "Albania",
                OfficialStateName = "The Republic of Albania",
                Sovereignty = "UN member state",
                Alpha2Code = "AL",
                Alpha3Code = "ALB",
                NumericCode = 8,
                SubdivisionCodeLinks = "ISO 3166-2:AL",
                InternetccTLD = ".al"
            });

            builder.HasData(new CountryCode()
            {
                Id = 2,
                CountryName = "Algeria",
                OfficialStateName = "The People's Democratic Republic of Algeria",
                Sovereignty = "UN member state",
                Alpha2Code = "DZ",
                Alpha3Code = "DZA",
                NumericCode = 12,
                SubdivisionCodeLinks = "ISO 3166-2:DZ",
                InternetccTLD = ".dz"
            });

            builder.HasData(new CountryCode()
            {
                Id = 3,
                CountryName = "American Samoa",
                OfficialStateName = "The Territory of American Samoa",
                Sovereignty = "United States",
                Alpha2Code = "AS",
                Alpha3Code = "ASM",
                NumericCode = 16,
                SubdivisionCodeLinks = "ISO 3166-2:AS",
                InternetccTLD = ".as"
            });

            builder.HasData(new CountryCode()
            {
                Id = 4,
                CountryName = "Andorra",
                OfficialStateName = "The Principality of Andorra",
                Sovereignty = "UN member state",
                Alpha2Code = "AD",
                Alpha3Code = "AND",
                NumericCode = 20,
                SubdivisionCodeLinks = "ISO 3166-2:AD",
                InternetccTLD = ".ad"
            });

            builder.HasData(new CountryCode()
            {
                Id = 5,
                CountryName = "Anla",
                OfficialStateName = "The Republic of Anla",
                Sovereignty = "UN member state",
                Alpha2Code = "AO",
                Alpha3Code = "A",
                NumericCode = 24,
                SubdivisionCodeLinks = "ISO 3166-2:AO",
                InternetccTLD = ".ao"
            });

            builder.HasData(new CountryCode()
            {
                Id = 6,
                CountryName = "Anguilla",
                OfficialStateName = "Anguilla",
                Sovereignty = "United Kingdom",
                Alpha2Code = "AI",
                Alpha3Code = "AIA",
                NumericCode = 660,
                SubdivisionCodeLinks = "ISO 3166-2:AI",
                InternetccTLD = ".ai"
            });

            builder.HasData(new CountryCode()
            {
                Id = 7,
                CountryName = "Antarctica",
                OfficialStateName = "All land and ice shelves south of the 60th parallel south",
                Sovereignty = "Antarctic Treaty",
                Alpha2Code = "AQ",
                Alpha3Code = "ATA",
                NumericCode = 10,
                SubdivisionCodeLinks = "ISO 3166-2:AQ",
                InternetccTLD = ".aq"
            });

            builder.HasData(new CountryCode()
            {
                Id = 8,
                CountryName = "Antigua and Barbuda",
                OfficialStateName = "Antigua and Barbuda",
                Sovereignty = "UN member state",
                Alpha2Code = "AG",
                Alpha3Code = "ATG",
                NumericCode = 28,
                SubdivisionCodeLinks = "ISO 3166-2:AG",
                InternetccTLD = ".ag"
            });

            builder.HasData(new CountryCode()
            {
                Id = 9,
                CountryName = "Argentina",
                OfficialStateName = "The Argentine Republic",
                Sovereignty = "UN member state",
                Alpha2Code = "AR",
                Alpha3Code = "ARG",
                NumericCode = 32,
                SubdivisionCodeLinks = "ISO 3166-2:AR",
                InternetccTLD = ".ar"
            });

            builder.HasData(new CountryCode()
            {
                Id = 10,
                CountryName = "Armenia",
                OfficialStateName = "The Republic of Armenia",
                Sovereignty = "UN member state",
                Alpha2Code = "AM",
                Alpha3Code = "ARM",
                NumericCode = 51,
                SubdivisionCodeLinks = "ISO 3166-2:AM",
                InternetccTLD = ".am"
            });

            builder.HasData(new CountryCode()
            {
                Id = 11,
                CountryName = "Aruba",
                OfficialStateName = "Aruba",
                Sovereignty = "Netherlands",
                Alpha2Code = "AW",
                Alpha3Code = "ABW",
                NumericCode = 533,
                SubdivisionCodeLinks = "ISO 3166-2:AW",
                InternetccTLD = ".aw"
            });

            builder.HasData(new CountryCode()
            {
                Id = 12,
                CountryName = "Australia",
                OfficialStateName = "The Commonwealth of Australia",
                Sovereignty = "UN member state",
                Alpha2Code = "AU",
                Alpha3Code = "AUS",
                NumericCode = 36,
                SubdivisionCodeLinks = "ISO 3166-2:AU",
                InternetccTLD = ".au"
            });

            builder.HasData(new CountryCode()
            {
                Id = 13,
                CountryName = "Austria",
                OfficialStateName = "The Republic of Austria",
                Sovereignty = "UN member state",
                Alpha2Code = "AT",
                Alpha3Code = "AUT",
                NumericCode = 40,
                SubdivisionCodeLinks = "ISO 3166-2:AT",
                InternetccTLD = ".at"
            });

            builder.HasData(new CountryCode()
            {
                Id = 14,
                CountryName = "Azerbaijan",
                OfficialStateName = "The Republic of Azerbaijan",
                Sovereignty = "UN member state",
                Alpha2Code = "AZ",
                Alpha3Code = "AZE",
                NumericCode = 31,
                SubdivisionCodeLinks = "ISO 3166-2:AZ",
                InternetccTLD = ".az"
            });

            builder.HasData(new CountryCode()
            {
                Id = 15,
                CountryName = "Bahamas (the),",
                OfficialStateName = "The Commonwealth of The Bahamas",
                Sovereignty = "UN member state",
                Alpha2Code = "BS",
                Alpha3Code = "BHS",
                NumericCode = 44,
                SubdivisionCodeLinks = "ISO 3166-2:BS",
                InternetccTLD = ".bs"
            });

            builder.HasData(new CountryCode()
            {
                Id = 16,
                CountryName = "Bahrain",
                OfficialStateName = "The Kingdom of Bahrain",
                Sovereignty = "UN member state",
                Alpha2Code = "BH",
                Alpha3Code = "BHR",
                NumericCode = 48,
                SubdivisionCodeLinks = "ISO 3166-2:BH",
                InternetccTLD = ".bh"
            });

            builder.HasData(new CountryCode()
            {
                Id = 17,
                CountryName = "Bangladesh",
                OfficialStateName = "The People's Republic of Bangladesh",
                Sovereignty = "UN member state",
                Alpha2Code = "BD",
                Alpha3Code = "BGD",
                NumericCode = 50,
                SubdivisionCodeLinks = "ISO 3166-2:BD",
                InternetccTLD = ".bd"
            });

            builder.HasData(new CountryCode()
            {
                Id = 18,
                CountryName = "Barbados",
                OfficialStateName = "Barbados",
                Sovereignty = "UN member state",
                Alpha2Code = "BB",
                Alpha3Code = "BRB",
                NumericCode = 52,
                SubdivisionCodeLinks = "ISO 3166-2:BB",
                InternetccTLD = ".bb"
            });

            builder.HasData(new CountryCode()
            {
                Id = 19,
                CountryName = "Belarus",
                OfficialStateName = "The Republic of Belarus",
                Sovereignty = "UN member state",
                Alpha2Code = "BY",
                Alpha3Code = "BLR",
                NumericCode = 112,
                SubdivisionCodeLinks = "ISO 3166-2:BY",
                InternetccTLD = ".by"
            });

            builder.HasData(new CountryCode()
            {
                Id = 20,
                CountryName = "Belgium",
                OfficialStateName = "The Kingdom of Belgium",
                Sovereignty = "UN member state",
                Alpha2Code = "BE",
                Alpha3Code = "BEL",
                NumericCode = 56,
                SubdivisionCodeLinks = "ISO 3166-2:BE",
                InternetccTLD = ".be"
            });

            builder.HasData(new CountryCode()
            {
                Id = 21,
                CountryName = "Belize",
                OfficialStateName = "Belize",
                Sovereignty = "UN member state",
                Alpha2Code = "BZ",
                Alpha3Code = "BLZ",
                NumericCode = 84,
                SubdivisionCodeLinks = "ISO 3166-2:BZ",
                InternetccTLD = ".bz"
            });

            builder.HasData(new CountryCode()
            {
                Id = 22,
                CountryName = "Benin",
                OfficialStateName = "The Republic of Benin",
                Sovereignty = "UN member state",
                Alpha2Code = "BJ",
                Alpha3Code = "BEN",
                NumericCode = 204,
                SubdivisionCodeLinks = "ISO 3166-2:BJ",
                InternetccTLD = ".bj"
            });

            builder.HasData(new CountryCode()
            {
                Id = 23,
                CountryName = "Bermuda",
                OfficialStateName = "Bermuda",
                Sovereignty = "United Kingdom",
                Alpha2Code = "BM",
                Alpha3Code = "BMU",
                NumericCode = 60,
                SubdivisionCodeLinks = "ISO 3166-2:BM",
                InternetccTLD = ".bm"
            });

            builder.HasData(new CountryCode()
            {
                Id = 24,
                CountryName = "Bhutan",
                OfficialStateName = "The Kingdom of Bhutan",
                Sovereignty = "UN member state",
                Alpha2Code = "BT",
                Alpha3Code = "BTN",
                NumericCode = 64,
                SubdivisionCodeLinks = "ISO 3166-2:BT",
                InternetccTLD = ".bt"
            });

            builder.HasData(new CountryCode()
            {
                Id = 25,
                CountryName = "Bolivia (Plurinational State of)",
                OfficialStateName = "The Plurinational State of Bolivia",
                Sovereignty = "UN member state",
                Alpha2Code = "BO",
                Alpha3Code = "BOL",
                NumericCode = 68,
                SubdivisionCodeLinks = "ISO 3166-2:BO",
                InternetccTLD = ".bo"
            });

            builder.HasData(new CountryCode()
            {
                Id = 26,
                CountryName = "Bonaire",
                OfficialStateName = "Bonaire, Sint Eustatius and Saba",
                Sovereignty = "Netherlands",
                Alpha2Code = "BQ",
                Alpha3Code = "BES",
                NumericCode = 535,
                SubdivisionCodeLinks = "ISO 3166-2:BQ",
                InternetccTLD = ".bq .nl "
            });

            builder.HasData(new CountryCode()
            {
                Id = 29,
                CountryName = "Bosnia and Herzevina",
                OfficialStateName = "Bosnia and Herzevina",
                Sovereignty = "UN member state",
                Alpha2Code = "BA",
                Alpha3Code = "BIH",
                NumericCode = 70,
                SubdivisionCodeLinks = "ISO 3166-2:BA",
                InternetccTLD = ".ba"
            });

            builder.HasData(new CountryCode()
            {
                Id = 30,
                CountryName = "Botswana",
                OfficialStateName = "The Republic of Botswana",
                Sovereignty = "UN member state",
                Alpha2Code = "BW",
                Alpha3Code = "BWA",
                NumericCode = 72,
                SubdivisionCodeLinks = "ISO 3166-2:BW",
                InternetccTLD = ".bw"
            });

            builder.HasData(new CountryCode()
            {
                Id = 31,
                CountryName = "Bouvet Island",
                OfficialStateName = "Bouvet Island",
                Sovereignty = "Norway",
                Alpha2Code = "BV",
                Alpha3Code = "BVT",
                NumericCode = 74,
                SubdivisionCodeLinks = "ISO 3166-2:BV",
                InternetccTLD = ""
            });

            builder.HasData(new CountryCode()
            {
                Id = 32,
                CountryName = "Brazil",
                OfficialStateName = "The Federative Republic of Brazil",
                Sovereignty = "UN member state",
                Alpha2Code = "BR",
                Alpha3Code = "BRA",
                NumericCode = 76,
                SubdivisionCodeLinks = "ISO 3166-2:BR",
                InternetccTLD = ".br"
            });

            builder.HasData(new CountryCode()
            {
                Id = 33,
                CountryName = "British Indian Ocean Territory (the)",
                OfficialStateName = "The British Indian Ocean Territory",
                Sovereignty = "United Kingdom",
                Alpha2Code = "IO",
                Alpha3Code = "IOT",
                NumericCode = 86,
                SubdivisionCodeLinks = "ISO 3166-2:IO",
                InternetccTLD = ".io"
            });

            builder.HasData(new CountryCode()
            {
                Id = 35,
                CountryName = "Brunei Darussalam",
                OfficialStateName = "The Nation of Brunei, the Abode of Peace",
                Sovereignty = "UN member state",
                Alpha2Code = "BN",
                Alpha3Code = "BRN",
                NumericCode = 96,
                SubdivisionCodeLinks = "ISO 3166-2:BN",
                InternetccTLD = ".bn"
            });

            builder.HasData(new CountryCode()
            {
                Id = 36,
                CountryName = "Bulgaria",
                OfficialStateName = "The Republic of Bulgaria",
                Sovereignty = "UN member state",
                Alpha2Code = "BG",
                Alpha3Code = "BGR",
                NumericCode = 100,
                SubdivisionCodeLinks = "ISO 3166-2:BG",
                InternetccTLD = ".bg"
            });

            builder.HasData(new CountryCode()
            {
                Id = 37,
                CountryName = "Burkina Faso",
                OfficialStateName = "Burkina Faso",
                Sovereignty = "UN member state",
                Alpha2Code = "BF",
                Alpha3Code = "BFA",
                NumericCode = 854,
                SubdivisionCodeLinks = "ISO 3166-2:BF",
                InternetccTLD = ".bf"
            });

            builder.HasData(new CountryCode()
            {
                Id = 39,
                CountryName = "Burundi",
                OfficialStateName = "The Republic of Burundi",
                Sovereignty = "UN member state",
                Alpha2Code = "BI",
                Alpha3Code = "BDI",
                NumericCode = 108,
                SubdivisionCodeLinks = "ISO 3166-2:BI",
                InternetccTLD = ".bi"
            });

            builder.HasData(new CountryCode()
            {
                Id = 40,
                CountryName = "Cabo Verde ",
                OfficialStateName = "The Republic of Cabo Verde",
                Sovereignty = "UN member state",
                Alpha2Code = "CV",
                Alpha3Code = "CPV",
                NumericCode = 132,
                SubdivisionCodeLinks = "ISO 3166-2:CV",
                InternetccTLD = ".cv"
            });

            builder.HasData(new CountryCode()
            {
                Id = 41,
                CountryName = "Cambodia",
                OfficialStateName = "The Kingdom of Cambodia",
                Sovereignty = "UN member state",
                Alpha2Code = "KH",
                Alpha3Code = "KHM",
                NumericCode = 116,
                SubdivisionCodeLinks = "ISO 3166-2:KH",
                InternetccTLD = ".kh"
            });

            builder.HasData(new CountryCode()
            {
                Id = 42,
                CountryName = "Cameroon",
                OfficialStateName = "The Republic of Cameroon",
                Sovereignty = "UN member state",
                Alpha2Code = "CM",
                Alpha3Code = "CMR",
                NumericCode = 120,
                SubdivisionCodeLinks = "ISO 3166-2:CM",
                InternetccTLD = ".cm"
            });

            builder.HasData(new CountryCode()
            {
                Id = 43,
                CountryName = "Canada",
                OfficialStateName = "Canada",
                Sovereignty = "UN member state",
                Alpha2Code = "CA",
                Alpha3Code = "CAN",
                NumericCode = 124,
                SubdivisionCodeLinks = "ISO 3166-2:CA",
                InternetccTLD = ".ca"
            });

            builder.HasData(new CountryCode()
            {
                Id = 46,
                CountryName = "Cayman Islands (the)",
                OfficialStateName = "The Cayman Islands",
                Sovereignty = "United Kingdom",
                Alpha2Code = "KY",
                Alpha3Code = "CYM",
                NumericCode = 136,
                SubdivisionCodeLinks = "ISO 3166-2:KY",
                InternetccTLD = ".ky"
            });

            builder.HasData(new CountryCode()
            {
                Id = 47,
                CountryName = "Central African Republic (the)",
                OfficialStateName = "The Central African Republic",
                Sovereignty = "UN member state",
                Alpha2Code = "CF",
                Alpha3Code = "CAF",
                NumericCode = 140,
                SubdivisionCodeLinks = "ISO 3166-2:CF",
                InternetccTLD = ".cf"
            });

            builder.HasData(new CountryCode()
            {
                Id = 48,
                CountryName = "Chad",
                OfficialStateName = "The Republic of Chad",
                Sovereignty = "UN member state",
                Alpha2Code = "TD",
                Alpha3Code = "TCD",
                NumericCode = 148,
                SubdivisionCodeLinks = "ISO 3166-2:TD",
                InternetccTLD = ".td"
            });

            builder.HasData(new CountryCode()
            {
                Id = 49,
                CountryName = "Chile",
                OfficialStateName = "The Republic of Chile",
                Sovereignty = "UN member state",
                Alpha2Code = "CL",
                Alpha3Code = "CHL",
                NumericCode = 152,
                SubdivisionCodeLinks = "ISO 3166-2:CL",
                InternetccTLD = ".cl"
            });

            builder.HasData(new CountryCode()
            {
                Id = 50,
                CountryName = "China",
                OfficialStateName = "The People's Republic of China",
                Sovereignty = "UN member state",
                Alpha2Code = "CN",
                Alpha3Code = "CHN",
                NumericCode = 156,
                SubdivisionCodeLinks = "ISO 3166-2:CN",
                InternetccTLD = ".cn"
            });

            builder.HasData(new CountryCode()
            {
                Id = 52,
                CountryName = "Christmas Island",
                OfficialStateName = "The Territory of Christmas Island",
                Sovereignty = "Australia",
                Alpha2Code = "CX",
                Alpha3Code = "CXR",
                NumericCode = 162,
                SubdivisionCodeLinks = "ISO 3166-2:CX",
                InternetccTLD = ".cx"
            });

            builder.HasData(new CountryCode()
            {
                Id = 53,
                CountryName = "Cocos (Keeling) Islands (the)",
                OfficialStateName = "The Territory of Cocos (Keeling) Islands",
                Sovereignty = "Australia",
                Alpha2Code = "CC",
                Alpha3Code = "CCK",
                NumericCode = 166,
                SubdivisionCodeLinks = "ISO 3166-2:CC",
                InternetccTLD = ".cc"
            });

            builder.HasData(new CountryCode()
            {
                Id = 54,
                CountryName = "Colombia",
                OfficialStateName = "The Republic of Colombia",
                Sovereignty = "UN member state",
                Alpha2Code = "CO",
                Alpha3Code = "COL",
                NumericCode = 170,
                SubdivisionCodeLinks = "ISO 3166-2:CO",
                InternetccTLD = ".co"
            });

            builder.HasData(new CountryCode()
            {
                Id = 55,
                CountryName = "Comoros (the)",
                OfficialStateName = "The Union of the Comoros",
                Sovereignty = "UN member state",
                Alpha2Code = "KM",
                Alpha3Code = "COM",
                NumericCode = 174,
                SubdivisionCodeLinks = "ISO 3166-2:KM",
                InternetccTLD = ".km"
            });

            builder.HasData(new CountryCode()
            {
                Id = 56,
                CountryName = "Con (the Democratic Republic of the)",
                OfficialStateName = "The Democratic Republic of the Con",
                Sovereignty = "UN member state",
                Alpha2Code = "CD",
                Alpha3Code = "COD",
                NumericCode = 180,
                SubdivisionCodeLinks = "ISO 3166-2:CD",
                InternetccTLD = ".cd"
            });

            builder.HasData(new CountryCode()
            {
                Id = 57,
                CountryName = "Con (the)",
                OfficialStateName = "The Republic of the Con",
                Sovereignty = "UN member state",
                Alpha2Code = "CG",
                Alpha3Code = "COG",
                NumericCode = 178,
                SubdivisionCodeLinks = "ISO 3166-2:CG",
                InternetccTLD = ".cg"
            });

            builder.HasData(new CountryCode()
            {
                Id = 58,
                CountryName = "Cook Islands (the)",
                OfficialStateName = "The Cook Islands",
                Sovereignty = "New Zealand",
                Alpha2Code = "CK",
                Alpha3Code = "COK",
                NumericCode = 184,
                SubdivisionCodeLinks = "ISO 3166-2:CK",
                InternetccTLD = ".ck"
            });

            builder.HasData(new CountryCode()
            {
                Id = 59,
                CountryName = "Costa Rica",
                OfficialStateName = "The Republic of Costa Rica",
                Sovereignty = "UN member state",
                Alpha2Code = "CR",
                Alpha3Code = "CRI",
                NumericCode = 188,
                SubdivisionCodeLinks = "ISO 3166-2:CR",
                InternetccTLD = ".cr"
            });

            builder.HasData(new CountryCode()
            {
                Id = 60,
                CountryName = "Côte d'Ivoire",
                OfficialStateName = "The Republic of Côte d'Ivoire",
                Sovereignty = "UN member state",
                Alpha2Code = "CI",
                Alpha3Code = "CIV",
                NumericCode = 384,
                SubdivisionCodeLinks = "ISO 3166-2:CI",
                InternetccTLD = ".ci"
            });

            builder.HasData(new CountryCode()
            {
                Id = 61,
                CountryName = "Croatia",
                OfficialStateName = "The Republic of Croatia",
                Sovereignty = "UN member state",
                Alpha2Code = "HR",
                Alpha3Code = "HRV",
                NumericCode = 191,
                SubdivisionCodeLinks = "ISO 3166-2:HR",
                InternetccTLD = ".hr"
            });

            builder.HasData(new CountryCode()
            {
                Id = 62,
                CountryName = "Cuba",
                OfficialStateName = "The Republic of Cuba",
                Sovereignty = "UN member state",
                Alpha2Code = "CU",
                Alpha3Code = "CUB",
                NumericCode = 192,
                SubdivisionCodeLinks = "ISO 3166-2:CU",
                InternetccTLD = ".cu"
            });

            builder.HasData(new CountryCode()
            {
                Id = 63,
                CountryName = "Curaçao",
                OfficialStateName = "The Country of Curaçao",
                Sovereignty = "Netherlands",
                Alpha2Code = "CW",
                Alpha3Code = "CUW",
                NumericCode = 531,
                SubdivisionCodeLinks = "ISO 3166-2:CW",
                InternetccTLD = ".cw"
            });

            builder.HasData(new CountryCode()
            {
                Id = 64,
                CountryName = "Cyprus",
                OfficialStateName = "The Republic of Cyprus",
                Sovereignty = "UN member state",
                Alpha2Code = "CY",
                Alpha3Code = "CYP",
                NumericCode = 196,
                SubdivisionCodeLinks = "ISO 3166-2:CY",
                InternetccTLD = ".cy"
            });

            builder.HasData(new CountryCode()
            {
                Id = 65,
                CountryName = "Czechia [i]",
                OfficialStateName = "The Czech Republic",
                Sovereignty = "UN member state",
                Alpha2Code = "CZ",
                Alpha3Code = "CZE",
                NumericCode = 203,
                SubdivisionCodeLinks = "ISO 3166-2:CZ",
                InternetccTLD = ".cz"
            });

            builder.HasData(new CountryCode()
            {
                Id = 68,
                CountryName = "Denmark",
                OfficialStateName = "The Kingdom of Denmark",
                Sovereignty = "UN member state",
                Alpha2Code = "DK",
                Alpha3Code = "DNK",
                NumericCode = 208,
                SubdivisionCodeLinks = "ISO 3166-2:DK",
                InternetccTLD = ".dk"
            });

            builder.HasData(new CountryCode()
            {
                Id = 69,
                CountryName = "Djibouti",
                OfficialStateName = "The Republic of Djibouti",
                Sovereignty = "UN member state",
                Alpha2Code = "DJ",
                Alpha3Code = "DJI",
                NumericCode = 262,
                SubdivisionCodeLinks = "ISO 3166-2:DJ",
                InternetccTLD = ".dj"
            });

            builder.HasData(new CountryCode()
            {
                Id = 70,
                CountryName = "Dominica",
                OfficialStateName = "The Commonwealth of Dominica",
                Sovereignty = "UN member state",
                Alpha2Code = "DM",
                Alpha3Code = "DMA",
                NumericCode = 212,
                SubdivisionCodeLinks = "ISO 3166-2:DM",
                InternetccTLD = ".dm"
            });

            builder.HasData(new CountryCode()
            {
                Id = 71,
                CountryName = "Dominican Republic (the)",
                OfficialStateName = "The Dominican Republic",
                Sovereignty = "UN member state",
                Alpha2Code = "DO",
                Alpha3Code = "DOM",
                NumericCode = 214,
                SubdivisionCodeLinks = "ISO 3166-2:DO",
                InternetccTLD = ".do"
            });

            builder.HasData(new CountryCode()
            {
                Id = 73,
                CountryName = "Ecuador",
                OfficialStateName = "The Republic of Ecuador",
                Sovereignty = "UN member state",
                Alpha2Code = "EC",
                Alpha3Code = "ECU",
                NumericCode = 218,
                SubdivisionCodeLinks = "ISO 3166-2:EC",
                InternetccTLD = ".ec"
            });

            builder.HasData(new CountryCode()
            {
                Id = 74,
                CountryName = "Egypt",
                OfficialStateName = "The Arab Republic of Egypt",
                Sovereignty = "UN member state",
                Alpha2Code = "EG",
                Alpha3Code = "EGY",
                NumericCode = 818,
                SubdivisionCodeLinks = "ISO 3166-2:EG",
                InternetccTLD = ".eg"
            });

            builder.HasData(new CountryCode()
            {
                Id = 75,
                CountryName = "El Salvador",
                OfficialStateName = "The Republic of El Salvador",
                Sovereignty = "UN member state",
                Alpha2Code = "SV",
                Alpha3Code = "SLV",
                NumericCode = 222,
                SubdivisionCodeLinks = "ISO 3166-2:SV",
                InternetccTLD = ".sv"
            });

            builder.HasData(new CountryCode()
            {
                Id = 76,
                CountryName = "Equatorial Guinea",
                OfficialStateName = "The Republic of Equatorial Guinea",
                Sovereignty = "UN member state",
                Alpha2Code = "GQ",
                Alpha3Code = "GNQ",
                NumericCode = 226,
                SubdivisionCodeLinks = "ISO 3166-2:GQ",
                InternetccTLD = ".gq"
            });

            builder.HasData(new CountryCode()
            {
                Id = 77,
                CountryName = "Eritrea",
                OfficialStateName = "The State of Eritrea",
                Sovereignty = "UN member state",
                Alpha2Code = "ER",
                Alpha3Code = "ERI",
                NumericCode = 232,
                SubdivisionCodeLinks = "ISO 3166-2:ER",
                InternetccTLD = ".er"
            });

            builder.HasData(new CountryCode()
            {
                Id = 78,
                CountryName = "Estonia",
                OfficialStateName = "The Republic of Estonia",
                Sovereignty = "UN member state",
                Alpha2Code = "EE",
                Alpha3Code = "EST",
                NumericCode = 233,
                SubdivisionCodeLinks = "ISO 3166-2:EE",
                InternetccTLD = ".ee"
            });

            builder.HasData(new CountryCode()
            {
                Id = 79,
                CountryName = "Eswatini ",
                OfficialStateName = "The Kingdom of Eswatini",
                Sovereignty = "UN member state",
                Alpha2Code = "SZ",
                Alpha3Code = "SWZ",
                NumericCode = 748,
                SubdivisionCodeLinks = "ISO 3166-2:SZ",
                InternetccTLD = ".sz"
            });

            builder.HasData(new CountryCode()
            {
                Id = 80,
                CountryName = "Ethiopia",
                OfficialStateName = "The Federal Democratic Republic of Ethiopia",
                Sovereignty = "UN member state",
                Alpha2Code = "ET",
                Alpha3Code = "ETH",
                NumericCode = 231,
                SubdivisionCodeLinks = "ISO 3166-2:ET",
                InternetccTLD = ".et"
            });

            builder.HasData(new CountryCode()
            {
                Id = 81,
                CountryName = "Falkland Islands (the) [Malvinas] [k]",
                OfficialStateName = "The Falkland Islands",
                Sovereignty = "United Kingdom",
                Alpha2Code = "FK",
                Alpha3Code = "FLK",
                NumericCode = 238,
                SubdivisionCodeLinks = "ISO 3166-2:FK",
                InternetccTLD = ".fk"
            });

            builder.HasData(new CountryCode()
            {
                Id = 82,
                CountryName = "Faroe Islands (the)",
                OfficialStateName = "The Faroe Islands",
                Sovereignty = "Denmark",
                Alpha2Code = "FO",
                Alpha3Code = "FRO",
                NumericCode = 234,
                SubdivisionCodeLinks = "ISO 3166-2:FO",
                InternetccTLD = ".fo"
            });

            builder.HasData(new CountryCode()
            {
                Id = 83,
                CountryName = "Fiji",
                OfficialStateName = "The Republic of Fiji",
                Sovereignty = "UN member state",
                Alpha2Code = "FJ",
                Alpha3Code = "FJI",
                NumericCode = 242,
                SubdivisionCodeLinks = "ISO 3166-2:FJ",
                InternetccTLD = ".fj"
            });

            builder.HasData(new CountryCode()
            {
                Id = 84,
                CountryName = "Finland",
                OfficialStateName = "The Republic of Finland",
                Sovereignty = "UN member state",
                Alpha2Code = "FI",
                Alpha3Code = "FIN",
                NumericCode = 246,
                SubdivisionCodeLinks = "ISO 3166-2:FI",
                InternetccTLD = ".fi"
            });

            builder.HasData(new CountryCode()
            {
                Id = 85,
                CountryName = "France ",
                OfficialStateName = "The French Republic",
                Sovereignty = "UN member state",
                Alpha2Code = "FR",
                Alpha3Code = "FRA",
                NumericCode = 250,
                SubdivisionCodeLinks = "ISO 3166-2:FR",
                InternetccTLD = ".fr"
            });

            builder.HasData(new CountryCode()
            {
                Id = 86,
                CountryName = "French Guiana",
                OfficialStateName = "Guyane",
                Sovereignty = "France",
                Alpha2Code = "GF",
                Alpha3Code = "GUF",
                NumericCode = 254,
                SubdivisionCodeLinks = "ISO 3166-2:GF",
                InternetccTLD = ".gf"
            });

            builder.HasData(new CountryCode()
            {
                Id = 87,
                CountryName = "French Polynesia",
                OfficialStateName = "French Polynesia",
                Sovereignty = "France",
                Alpha2Code = "PF",
                Alpha3Code = "PYF",
                NumericCode = 258,
                SubdivisionCodeLinks = "ISO 3166-2:PF",
                InternetccTLD = ".pf"
            });

            builder.HasData(new CountryCode()
            {
                Id = 88,
                CountryName = "French Southern Territories (the) [m]",
                OfficialStateName = "The French Southern and Antarctic Lands",
                Sovereignty = "France",
                Alpha2Code = "TF",
                Alpha3Code = "ATF",
                NumericCode = 260,
                SubdivisionCodeLinks = "ISO 3166-2:TF",
                InternetccTLD = ".tf"
            });

            builder.HasData(new CountryCode()
            {
                Id = 89,
                CountryName = "Gabon",
                OfficialStateName = "The Gabonese Republic",
                Sovereignty = "UN member state",
                Alpha2Code = "GA",
                Alpha3Code = "GAB",
                NumericCode = 266,
                SubdivisionCodeLinks = "ISO 3166-2:GA",
                InternetccTLD = ".ga"
            });

            builder.HasData(new CountryCode()
            {
                Id = 90,
                CountryName = "Gambia (the)",
                OfficialStateName = "The Republic of The Gambia",
                Sovereignty = "UN member state",
                Alpha2Code = "GM",
                Alpha3Code = "GMB",
                NumericCode = 270,
                SubdivisionCodeLinks = "ISO 3166-2:GM",
                InternetccTLD = ".gm"
            });

            builder.HasData(new CountryCode()
            {
                Id = 91,
                CountryName = "Georgia",
                OfficialStateName = "Georgia",
                Sovereignty = "UN member state",
                Alpha2Code = "GE",
                Alpha3Code = "GEO",
                NumericCode = 268,
                SubdivisionCodeLinks = "ISO 3166-2:GE",
                InternetccTLD = ".ge"
            });

            builder.HasData(new CountryCode()
            {
                Id = 92,
                CountryName = "Germany",
                OfficialStateName = "The Federal Republic of Germany",
                Sovereignty = "UN member state",
                Alpha2Code = "DE",
                Alpha3Code = "DEU",
                NumericCode = 276,
                SubdivisionCodeLinks = "ISO 3166-2:DE",
                InternetccTLD = ".de"
            });

            builder.HasData(new CountryCode()
            {
                Id = 93,
                CountryName = "Ghana",
                OfficialStateName = "The Republic of Ghana",
                Sovereignty = "UN member state",
                Alpha2Code = "GH",
                Alpha3Code = "GHA",
                NumericCode = 288,
                SubdivisionCodeLinks = "ISO 3166-2:GH",
                InternetccTLD = ".gh"
            });

            builder.HasData(new CountryCode()
            {
                Id = 94,
                CountryName = "Gibraltar",
                OfficialStateName = "Gibraltar",
                Sovereignty = "United Kingdom",
                Alpha2Code = "GI",
                Alpha3Code = "GIB",
                NumericCode = 292,
                SubdivisionCodeLinks = "ISO 3166-2:GI",
                InternetccTLD = ".gi"
            });

            builder.HasData(new CountryCode()
            {
                Id = 96,
                CountryName = "Greece",
                OfficialStateName = "The Hellenic Republic",
                Sovereignty = "UN member state",
                Alpha2Code = "GR",
                Alpha3Code = "GRC",
                NumericCode = 300,
                SubdivisionCodeLinks = "ISO 3166-2:GR",
                InternetccTLD = ".gr"
            });

            builder.HasData(new CountryCode()
            {
                Id = 97,
                CountryName = "Greenland",
                OfficialStateName = "Kalaallit Nunaat",
                Sovereignty = "Denmark",
                Alpha2Code = "GL",
                Alpha3Code = "GRL",
                NumericCode = 304,
                SubdivisionCodeLinks = "ISO 3166-2:GL",
                InternetccTLD = ".gl"
            });

            builder.HasData(new CountryCode()
            {
                Id = 98,
                CountryName = "Grenada",
                OfficialStateName = "Grenada",
                Sovereignty = "UN member state",
                Alpha2Code = "GD",
                Alpha3Code = "GRD",
                NumericCode = 308,
                SubdivisionCodeLinks = "ISO 3166-2:GD",
                InternetccTLD = ".gd"
            });

            builder.HasData(new CountryCode()
            {
                Id = 99,
                CountryName = "Guadeloupe",
                OfficialStateName = "Guadeloupe",
                Sovereignty = "France",
                Alpha2Code = "GP",
                Alpha3Code = "GLP",
                NumericCode = 312,
                SubdivisionCodeLinks = "ISO 3166-2:GP",
                InternetccTLD = ".gp"
            });

            builder.HasData(new CountryCode()
            {
                Id = 100,
                CountryName = "Guam",
                OfficialStateName = "The Territory of Guam",
                Sovereignty = "United States",
                Alpha2Code = "GU",
                Alpha3Code = "GUM",
                NumericCode = 316,
                SubdivisionCodeLinks = "ISO 3166-2:GU",
                InternetccTLD = ".gu"
            });

            builder.HasData(new CountryCode()
            {
                Id = 101,
                CountryName = "Guatemala",
                OfficialStateName = "The Republic of Guatemala",
                Sovereignty = "UN member state",
                Alpha2Code = "GT",
                Alpha3Code = "GTM",
                NumericCode = 320,
                SubdivisionCodeLinks = "ISO 3166-2:GT",
                InternetccTLD = ".gt"
            });

            builder.HasData(new CountryCode()
            {
                Id = 102,
                CountryName = "Guernsey",
                OfficialStateName = "The Bailiwick of Guernsey",
                Sovereignty = "British Crown",
                Alpha2Code = "GG",
                Alpha3Code = "GGY",
                NumericCode = 831,
                SubdivisionCodeLinks = "ISO 3166-2:GG",
                InternetccTLD = ".gg"
            });

            builder.HasData(new CountryCode()
            {
                Id = 103,
                CountryName = "Guinea",
                OfficialStateName = "The Republic of Guinea",
                Sovereignty = "UN member state",
                Alpha2Code = "GN",
                Alpha3Code = "GIN",
                NumericCode = 324,
                SubdivisionCodeLinks = "ISO 3166-2:GN",
                InternetccTLD = ".gn"
            });

            builder.HasData(new CountryCode()
            {
                Id = 104,
                CountryName = "Guinea-Bissau",
                OfficialStateName = "The Republic of Guinea-Bissau",
                Sovereignty = "UN member state",
                Alpha2Code = "GW",
                Alpha3Code = "GNB",
                NumericCode = 624,
                SubdivisionCodeLinks = "ISO 3166-2:GW",
                InternetccTLD = ".gw"
            });

            builder.HasData(new CountryCode()
            {
                Id = 105,
                CountryName = "Guyana",
                OfficialStateName = "The Co-operative Republic of Guyana",
                Sovereignty = "UN member state",
                Alpha2Code = "GY",
                Alpha3Code = "GUY",
                NumericCode = 328,
                SubdivisionCodeLinks = "ISO 3166-2:GY",
                InternetccTLD = ".gy"
            });

            builder.HasData(new CountryCode()
            {
                Id = 106,
                CountryName = "Haiti",
                OfficialStateName = "The Republic of Haiti",
                Sovereignty = "UN member state",
                Alpha2Code = "HT",
                Alpha3Code = "HTI",
                NumericCode = 332,
                SubdivisionCodeLinks = "ISO 3166-2:HT",
                InternetccTLD = ".ht"
            });

            builder.HasData(new CountryCode()
            {
                Id = 107,
                CountryName = "Heard Island and McDonald Islands",
                OfficialStateName = "The Territory of Heard Island and McDonald Islands",
                Sovereignty = "Australia",
                Alpha2Code = "HM",
                Alpha3Code = "HMD",
                NumericCode = 334,
                SubdivisionCodeLinks = "ISO 3166-2:HM",
                InternetccTLD = ".hm"
            });

            builder.HasData(new CountryCode()
            {
                Id = 108,
                CountryName = "Holy See (the) [n]",
                OfficialStateName = "The Holy See",
                Sovereignty = "UN observer state",
                Alpha2Code = "VA",
                Alpha3Code = "VAT",
                NumericCode = 336,
                SubdivisionCodeLinks = "ISO 3166-2:VA",
                InternetccTLD = ".va"
            });

            builder.HasData(new CountryCode()
            {
                Id = 109,
                CountryName = "Honduras",
                OfficialStateName = "The Republic of Honduras",
                Sovereignty = "UN member state",
                Alpha2Code = "HN",
                Alpha3Code = "HND",
                NumericCode = 340,
                SubdivisionCodeLinks = "ISO 3166-2:HN",
                InternetccTLD = ".hn"
            });

            builder.HasData(new CountryCode()
            {
                Id = 110,
                CountryName = "Hong Kong",
                OfficialStateName = "The Hong Kong Special Administrative Region of China[10]",
                Sovereignty = "China",
                Alpha2Code = "HK",
                Alpha3Code = "HKG",
                NumericCode = 344,
                SubdivisionCodeLinks = "ISO 3166-2:HK",
                InternetccTLD = ".hk"
            });

            builder.HasData(new CountryCode()
            {
                Id = 111,
                CountryName = "Hungary",
                OfficialStateName = "Hungary",
                Sovereignty = "UN member state",
                Alpha2Code = "HU",
                Alpha3Code = "HUN",
                NumericCode = 348,
                SubdivisionCodeLinks = "ISO 3166-2:HU",
                InternetccTLD = ".hu"
            });

            builder.HasData(new CountryCode()
            {
                Id = 112,
                CountryName = "Iceland",
                OfficialStateName = "Iceland",
                Sovereignty = "UN member state",
                Alpha2Code = "IS",
                Alpha3Code = "ISL",
                NumericCode = 352,
                SubdivisionCodeLinks = "ISO 3166-2:IS",
                InternetccTLD = ".is"
            });

            builder.HasData(new CountryCode()
            {
                Id = 113,
                CountryName = "India",
                OfficialStateName = "The Republic of India",
                Sovereignty = "UN member state",
                Alpha2Code = "IN",
                Alpha3Code = "IND",
                NumericCode = 356,
                SubdivisionCodeLinks = "ISO 3166-2:IN",
                InternetccTLD = ".in"
            });

            builder.HasData(new CountryCode()
            {
                Id = 114,
                CountryName = "Indonesia",
                OfficialStateName = "The Republic of Indonesia",
                Sovereignty = "UN member state",
                Alpha2Code = "ID",
                Alpha3Code = "IDN",
                NumericCode = 360,
                SubdivisionCodeLinks = "ISO 3166-2:ID",
                InternetccTLD = ".id"
            });

            builder.HasData(new CountryCode()
            {
                Id = 115,
                CountryName = "Iran (Islamic Republic of)",
                OfficialStateName = "The Islamic Republic of Iran",
                Sovereignty = "UN member state",
                Alpha2Code = "IR",
                Alpha3Code = "IRN",
                NumericCode = 364,
                SubdivisionCodeLinks = "ISO 3166-2:IR",
                InternetccTLD = ".ir"
            });

            builder.HasData(new CountryCode()
            {
                Id = 116,
                CountryName = "Iraq",
                OfficialStateName = "The Republic of Iraq",
                Sovereignty = "UN member state",
                Alpha2Code = "IQ",
                Alpha3Code = "IRQ",
                NumericCode = 368,
                SubdivisionCodeLinks = "ISO 3166-2:IQ",
                InternetccTLD = ".iq"
            });

            builder.HasData(new CountryCode()
            {
                Id = 117,
                CountryName = "Ireland",
                OfficialStateName = "Ireland",
                Sovereignty = "UN member state",
                Alpha2Code = "IE",
                Alpha3Code = "IRL",
                NumericCode = 372,
                SubdivisionCodeLinks = "ISO 3166-2:IE",
                InternetccTLD = ".ie"
            });

            builder.HasData(new CountryCode()
            {
                Id = 118,
                CountryName = "Isle of Man",
                OfficialStateName = "The Isle of Man",
                Sovereignty = "British Crown",
                Alpha2Code = "IM",
                Alpha3Code = "IMN",
                NumericCode = 833,
                SubdivisionCodeLinks = "ISO 3166-2:IM",
                InternetccTLD = ".im"
            });

            builder.HasData(new CountryCode()
            {
                Id = 119,
                CountryName = "Israel",
                OfficialStateName = "The State of Israel",
                Sovereignty = "UN member state",
                Alpha2Code = "IL",
                Alpha3Code = "ISR",
                NumericCode = 376,
                SubdivisionCodeLinks = "ISO 3166-2:IL",
                InternetccTLD = ".il"
            });

            builder.HasData(new CountryCode()
            {
                Id = 120,
                CountryName = "Italy",
                OfficialStateName = "The Italian Republic",
                Sovereignty = "UN member state",
                Alpha2Code = "IT",
                Alpha3Code = "ITA",
                NumericCode = 380,
                SubdivisionCodeLinks = "ISO 3166-2:IT",
                InternetccTLD = ".it"
            });

            builder.HasData(new CountryCode()
            {
                Id = 122,
                CountryName = "Jamaica",
                OfficialStateName = "Jamaica",
                Sovereignty = "UN member state",
                Alpha2Code = "JM",
                Alpha3Code = "JAM",
                NumericCode = 388,
                SubdivisionCodeLinks = "ISO 3166-2:JM",
                InternetccTLD = ".jm"
            });

            builder.HasData(new CountryCode()
            {
                Id = 124,
                CountryName = "Japan",
                OfficialStateName = "Japan",
                Sovereignty = "UN member state",
                Alpha2Code = "JP",
                Alpha3Code = "JPN",
                NumericCode = 392,
                SubdivisionCodeLinks = "ISO 3166-2:JP",
                InternetccTLD = ".jp"
            });

            builder.HasData(new CountryCode()
            {
                Id = 125,
                CountryName = "Jersey",
                OfficialStateName = "The Bailiwick of Jersey",
                Sovereignty = "British Crown",
                Alpha2Code = "JE",
                Alpha3Code = "JEY",
                NumericCode = 832,
                SubdivisionCodeLinks = "ISO 3166-2:JE",
                InternetccTLD = ".je"
            });

            builder.HasData(new CountryCode()
            {
                Id = 126,
                CountryName = "Jordan",
                OfficialStateName = "The Hashemite Kingdom of Jordan",
                Sovereignty = "UN member state",
                Alpha2Code = "JO",
                Alpha3Code = "JOR",
                NumericCode = 400,
                SubdivisionCodeLinks = "ISO 3166-2:JO",
                InternetccTLD = ".jo"
            });

            builder.HasData(new CountryCode()
            {
                Id = 127,
                CountryName = "Kazakhstan",
                OfficialStateName = "The Republic of Kazakhstan",
                Sovereignty = "UN member state",
                Alpha2Code = "KZ",
                Alpha3Code = "KAZ",
                NumericCode = 398,
                SubdivisionCodeLinks = "ISO 3166-2:KZ",
                InternetccTLD = ".kz"
            });

            builder.HasData(new CountryCode()
            {
                Id = 128,
                CountryName = "Kenya",
                OfficialStateName = "The Republic of Kenya",
                Sovereignty = "UN member state",
                Alpha2Code = "KE",
                Alpha3Code = "KEN",
                NumericCode = 404,
                SubdivisionCodeLinks = "ISO 3166-2:KE",
                InternetccTLD = ".ke"
            });

            builder.HasData(new CountryCode()
            {
                Id = 129,
                CountryName = "Kiribati",
                OfficialStateName = "The Republic of Kiribati",
                Sovereignty = "UN member state",
                Alpha2Code = "KI",
                Alpha3Code = "KIR",
                NumericCode = 296,
                SubdivisionCodeLinks = "ISO 3166-2:KI",
                InternetccTLD = ".ki"
            });

            builder.HasData(new CountryCode()
            {
                Id = 130,
                CountryName = "Korea (the Democratic People's Republic of)",
                OfficialStateName = "The Democratic People's Republic of Korea",
                Sovereignty = "UN member state",
                Alpha2Code = "KP",
                Alpha3Code = "PRK",
                NumericCode = 408,
                SubdivisionCodeLinks = "ISO 3166-2:KP",
                InternetccTLD = ".kp"
            });

            builder.HasData(new CountryCode()
            {
                Id = 131,
                CountryName = "Korea (the Republic of) [p]",
                OfficialStateName = "The Republic of Korea",
                Sovereignty = "UN member state",
                Alpha2Code = "KR",
                Alpha3Code = "KOR",
                NumericCode = 410,
                SubdivisionCodeLinks = "ISO 3166-2:KR",
                InternetccTLD = ".kr"
            });

            builder.HasData(new CountryCode()
            {
                Id = 132,
                CountryName = "Kuwait",
                OfficialStateName = "The State of Kuwait",
                Sovereignty = "UN member state",
                Alpha2Code = "KW",
                Alpha3Code = "KWT",
                NumericCode = 414,
                SubdivisionCodeLinks = "ISO 3166-2:KW",
                InternetccTLD = ".kw"
            });

            builder.HasData(new CountryCode()
            {
                Id = 133,
                CountryName = "Kyrgyzstan",
                OfficialStateName = "The Kyrgyz Republic",
                Sovereignty = "UN member state",
                Alpha2Code = "KG",
                Alpha3Code = "KGZ",
                NumericCode = 417,
                SubdivisionCodeLinks = "ISO 3166-2:KG",
                InternetccTLD = ".kg"
            });

            builder.HasData(new CountryCode()
            {
                Id = 134,
                CountryName = "Lao People's Democratic Republic (the)",
                OfficialStateName = "The Lao People's Democratic Republic",
                Sovereignty = "UN member state",
                Alpha2Code = "LA",
                Alpha3Code = "LAO",
                NumericCode = 418,
                SubdivisionCodeLinks = "ISO 3166-2:LA",
                InternetccTLD = ".la"
            });

            builder.HasData(new CountryCode()
            {
                Id = 135,
                CountryName = "Latvia",
                OfficialStateName = "The Republic of Latvia",
                Sovereignty = "UN member state",
                Alpha2Code = "LV",
                Alpha3Code = "LVA",
                NumericCode = 428,
                SubdivisionCodeLinks = "ISO 3166-2:LV",
                InternetccTLD = ".lv"
            });

            builder.HasData(new CountryCode()
            {
                Id = 136,
                CountryName = "Lebanon",
                OfficialStateName = "The Lebanese Republic",
                Sovereignty = "UN member state",
                Alpha2Code = "LB",
                Alpha3Code = "LBN",
                NumericCode = 422,
                SubdivisionCodeLinks = "ISO 3166-2:LB",
                InternetccTLD = ".lb"
            });

            builder.HasData(new CountryCode()
            {
                Id = 137,
                CountryName = "Lesotho",
                OfficialStateName = "The Kingdom of Lesotho",
                Sovereignty = "UN member state",
                Alpha2Code = "LS",
                Alpha3Code = "LSO",
                NumericCode = 426,
                SubdivisionCodeLinks = "ISO 3166-2:LS",
                InternetccTLD = ".ls"
            });

            builder.HasData(new CountryCode()
            {
                Id = 138,
                CountryName = "Liberia",
                OfficialStateName = "The Republic of Liberia",
                Sovereignty = "UN member state",
                Alpha2Code = "LR",
                Alpha3Code = "LBR",
                NumericCode = 430,
                SubdivisionCodeLinks = "ISO 3166-2:LR",
                InternetccTLD = ".lr"
            });

            builder.HasData(new CountryCode()
            {
                Id = 139,
                CountryName = "Libya",
                OfficialStateName = "The State of Libya",
                Sovereignty = "UN member state",
                Alpha2Code = "LY",
                Alpha3Code = "LBY",
                NumericCode = 434,
                SubdivisionCodeLinks = "ISO 3166-2:LY",
                InternetccTLD = ".ly"
            });

            builder.HasData(new CountryCode()
            {
                Id = 140,
                CountryName = "Liechtenstein",
                OfficialStateName = "The Principality of Liechtenstein",
                Sovereignty = "UN member state",
                Alpha2Code = "LI",
                Alpha3Code = "LIE",
                NumericCode = 438,
                SubdivisionCodeLinks = "ISO 3166-2:LI",
                InternetccTLD = ".li"
            });

            builder.HasData(new CountryCode()
            {
                Id = 141,
                CountryName = "Lithuania",
                OfficialStateName = "The Republic of Lithuania",
                Sovereignty = "UN member state",
                Alpha2Code = "LT",
                Alpha3Code = "LTU",
                NumericCode = 440,
                SubdivisionCodeLinks = "ISO 3166-2:LT",
                InternetccTLD = ".lt"
            });

            builder.HasData(new CountryCode()
            {
                Id = 142,
                CountryName = "Luxembourg",
                OfficialStateName = "The Grand Duchy of Luxembourg",
                Sovereignty = "UN member state",
                Alpha2Code = "LU",
                Alpha3Code = "LUX",
                NumericCode = 442,
                SubdivisionCodeLinks = "ISO 3166-2:LU",
                InternetccTLD = ".lu"
            });

            builder.HasData(new CountryCode()
            {
                Id = 143,
                CountryName = "Macao ",
                OfficialStateName = "The Macao Special Administrative Region of China[11]",
                Sovereignty = "China",
                Alpha2Code = "MO",
                Alpha3Code = "MAC",
                NumericCode = 446,
                SubdivisionCodeLinks = "ISO 3166-2:MO",
                InternetccTLD = ".mo"
            });

            builder.HasData(new CountryCode()
            {
                Id = 144,
                CountryName = "North Macedonia [s]",
                OfficialStateName = "The Republic of North Macedonia[12]",
                Sovereignty = "UN member state",
                Alpha2Code = "MK",
                Alpha3Code = "MKD",
                NumericCode = 807,
                SubdivisionCodeLinks = "ISO 3166-2:MK",
                InternetccTLD = ".mk"
            });

            builder.HasData(new CountryCode()
            {
                Id = 145,
                CountryName = "Madagascar",
                OfficialStateName = "The Republic of Madagascar",
                Sovereignty = "UN member state",
                Alpha2Code = "MG",
                Alpha3Code = "MDG",
                NumericCode = 450,
                SubdivisionCodeLinks = "ISO 3166-2:MG",
                InternetccTLD = ".mg"
            });

            builder.HasData(new CountryCode()
            {
                Id = 146,
                CountryName = "Malawi",
                OfficialStateName = "The Republic of Malawi",
                Sovereignty = "UN member state",
                Alpha2Code = "MW",
                Alpha3Code = "MWI",
                NumericCode = 454,
                SubdivisionCodeLinks = "ISO 3166-2:MW",
                InternetccTLD = ".mw"
            });

            builder.HasData(new CountryCode()
            {
                Id = 147,
                CountryName = "Malaysia",
                OfficialStateName = "Malaysia",
                Sovereignty = "UN member state",
                Alpha2Code = "MY",
                Alpha3Code = "MYS",
                NumericCode = 458,
                SubdivisionCodeLinks = "ISO 3166-2:MY",
                InternetccTLD = ".my"
            });

            builder.HasData(new CountryCode()
            {
                Id = 148,
                CountryName = "Maldives",
                OfficialStateName = "The Republic of Maldives",
                Sovereignty = "UN member state",
                Alpha2Code = "MV",
                Alpha3Code = "MDV",
                NumericCode = 462,
                SubdivisionCodeLinks = "ISO 3166-2:MV",
                InternetccTLD = ".mv"
            });

            builder.HasData(new CountryCode()
            {
                Id = 149,
                CountryName = "Mali",
                OfficialStateName = "The Republic of Mali",
                Sovereignty = "UN member state",
                Alpha2Code = "ML",
                Alpha3Code = "MLI",
                NumericCode = 466,
                SubdivisionCodeLinks = "ISO 3166-2:ML",
                InternetccTLD = ".ml"
            });

            builder.HasData(new CountryCode()
            {
                Id = 150,
                CountryName = "Malta",
                OfficialStateName = "The Republic of Malta",
                Sovereignty = "UN member state",
                Alpha2Code = "MT",
                Alpha3Code = "MLT",
                NumericCode = 470,
                SubdivisionCodeLinks = "ISO 3166-2:MT",
                InternetccTLD = ".mt"
            });

            builder.HasData(new CountryCode()
            {
                Id = 151,
                CountryName = "Marshall Islands (the)",
                OfficialStateName = "The Republic of the Marshall Islands",
                Sovereignty = "UN member state",
                Alpha2Code = "MH",
                Alpha3Code = "MHL",
                NumericCode = 584,
                SubdivisionCodeLinks = "ISO 3166-2:MH",
                InternetccTLD = ".mh"
            });

            builder.HasData(new CountryCode()
            {
                Id = 152,
                CountryName = "Martinique",
                OfficialStateName = "Martinique",
                Sovereignty = "France",
                Alpha2Code = "MQ",
                Alpha3Code = "MTQ",
                NumericCode = 474,
                SubdivisionCodeLinks = "ISO 3166-2:MQ",
                InternetccTLD = ".mq"
            });

            builder.HasData(new CountryCode()
            {
                Id = 153,
                CountryName = "Mauritania",
                OfficialStateName = "The Islamic Republic of Mauritania",
                Sovereignty = "UN member state",
                Alpha2Code = "MR",
                Alpha3Code = "MRT",
                NumericCode = 478,
                SubdivisionCodeLinks = "ISO 3166-2:MR",
                InternetccTLD = ".mr"
            });

            builder.HasData(new CountryCode()
            {
                Id = 154,
                CountryName = "Mauritius",
                OfficialStateName = "The Republic of Mauritius",
                Sovereignty = "UN member state",
                Alpha2Code = "MU",
                Alpha3Code = "MUS",
                NumericCode = 480,
                SubdivisionCodeLinks = "ISO 3166-2:MU",
                InternetccTLD = ".mu"
            });

            builder.HasData(new CountryCode()
            {
                Id = 155,
                CountryName = "Mayotte",
                OfficialStateName = "The Department of Mayotte",
                Sovereignty = "France",
                Alpha2Code = "YT",
                Alpha3Code = "MYT",
                NumericCode = 175,
                SubdivisionCodeLinks = "ISO 3166-2:YT",
                InternetccTLD = ".yt"
            });

            builder.HasData(new CountryCode()
            {
                Id = 156,
                CountryName = "Mexico",
                OfficialStateName = "The United Mexican States",
                Sovereignty = "UN member state",
                Alpha2Code = "MX",
                Alpha3Code = "MEX",
                NumericCode = 484,
                SubdivisionCodeLinks = "ISO 3166-2:MX",
                InternetccTLD = ".mx"
            });

            builder.HasData(new CountryCode()
            {
                Id = 157,
                CountryName = "Micronesia (Federated States of)",
                OfficialStateName = "The Federated States of Micronesia",
                Sovereignty = "UN member state",
                Alpha2Code = "FM",
                Alpha3Code = "FSM",
                NumericCode = 583,
                SubdivisionCodeLinks = "ISO 3166-2:FM",
                InternetccTLD = ".fm"
            });

            builder.HasData(new CountryCode()
            {
                Id = 158,
                CountryName = "Moldova (the Republic of)",
                OfficialStateName = "The Republic of Moldova",
                Sovereignty = "UN member state",
                Alpha2Code = "MD",
                Alpha3Code = "MDA",
                NumericCode = 498,
                SubdivisionCodeLinks = "ISO 3166-2:MD",
                InternetccTLD = ".md"
            });

            builder.HasData(new CountryCode()
            {
                Id = 159,
                CountryName = "Monaco",
                OfficialStateName = "The Principality of Monaco",
                Sovereignty = "UN member state",
                Alpha2Code = "MC",
                Alpha3Code = "MCO",
                NumericCode = 492,
                SubdivisionCodeLinks = "ISO 3166-2:MC",
                InternetccTLD = ".mc"
            });

            builder.HasData(new CountryCode()
            {
                Id = 160,
                CountryName = "Monlia",
                OfficialStateName = "Monlia",
                Sovereignty = "UN member state",
                Alpha2Code = "MN",
                Alpha3Code = "MNG",
                NumericCode = 496,
                SubdivisionCodeLinks = "ISO 3166-2:MN",
                InternetccTLD = ".mn"
            });

            builder.HasData(new CountryCode()
            {
                Id = 161,
                CountryName = "Montenegro",
                OfficialStateName = "Montenegro",
                Sovereignty = "UN member state",
                Alpha2Code = "ME",
                Alpha3Code = "MNE",
                NumericCode = 499,
                SubdivisionCodeLinks = "ISO 3166-2:ME",
                InternetccTLD = ".me"
            });

            builder.HasData(new CountryCode()
            {
                Id = 162,
                CountryName = "Montserrat",
                OfficialStateName = "Montserrat",
                Sovereignty = "United Kingdom",
                Alpha2Code = "MS",
                Alpha3Code = "MSR",
                NumericCode = 500,
                SubdivisionCodeLinks = "ISO 3166-2:MS",
                InternetccTLD = ".ms"
            });

            builder.HasData(new CountryCode()
            {
                Id = 163,
                CountryName = "Morocco",
                OfficialStateName = "The Kingdom of Morocco",
                Sovereignty = "UN member state",
                Alpha2Code = "MA",
                Alpha3Code = "MAR",
                NumericCode = 504,
                SubdivisionCodeLinks = "ISO 3166-2:MA",
                InternetccTLD = ".ma"
            });

            builder.HasData(new CountryCode()
            {
                Id = 164,
                CountryName = "Mozambique",
                OfficialStateName = "The Republic of Mozambique",
                Sovereignty = "UN member state",
                Alpha2Code = "MZ",
                Alpha3Code = "MOZ",
                NumericCode = 508,
                SubdivisionCodeLinks = "ISO 3166-2:MZ",
                InternetccTLD = ".mz"
            });

            builder.HasData(new CountryCode()
            {
                Id = 165,
                CountryName = "Myanmar ",
                OfficialStateName = "The Republic of the Union of Myanmar",
                Sovereignty = "UN member state",
                Alpha2Code = "MM",
                Alpha3Code = "MMR",
                NumericCode = 104,
                SubdivisionCodeLinks = "ISO 3166-2:MM",
                InternetccTLD = ".mm"
            });

            builder.HasData(new CountryCode()
            {
                Id = 166,
                CountryName = "Namibia",
                OfficialStateName = "The Republic of Namibia",
                Sovereignty = "UN member state",
                Alpha2Code = "NA",
                Alpha3Code = "NAM",
                NumericCode = 516,
                SubdivisionCodeLinks = "ISO 3166-2:NA",
                InternetccTLD = ".na"
            });

            builder.HasData(new CountryCode()
            {
                Id = 167,
                CountryName = "Nauru",
                OfficialStateName = "The Republic of Nauru",
                Sovereignty = "UN member state",
                Alpha2Code = "NR",
                Alpha3Code = "NRU",
                NumericCode = 520,
                SubdivisionCodeLinks = "ISO 3166-2:NR",
                InternetccTLD = ".nr"
            });

            builder.HasData(new CountryCode()
            {
                Id = 168,
                CountryName = "Nepal",
                OfficialStateName = "The Federal Democratic Republic of Nepal",
                Sovereignty = "UN member state",
                Alpha2Code = "NP",
                Alpha3Code = "NPL",
                NumericCode = 524,
                SubdivisionCodeLinks = "ISO 3166-2:NP",
                InternetccTLD = ".np"
            });

            builder.HasData(new CountryCode()
            {
                Id = 169,
                CountryName = "Netherlands (the)",
                OfficialStateName = "The Kingdom of the Netherlands",
                Sovereignty = "UN member state",
                Alpha2Code = "NL",
                Alpha3Code = "NLD",
                NumericCode = 528,
                SubdivisionCodeLinks = "ISO 3166-2:NL",
                InternetccTLD = ".nl"
            });

            builder.HasData(new CountryCode()
            {
                Id = 170,
                CountryName = "New Caledonia",
                OfficialStateName = "New Caledonia",
                Sovereignty = "France",
                Alpha2Code = "NC",
                Alpha3Code = "NCL",
                NumericCode = 540,
                SubdivisionCodeLinks = "ISO 3166-2:NC",
                InternetccTLD = ".nc"
            });

            builder.HasData(new CountryCode()
            {
                Id = 171,
                CountryName = "New Zealand",
                OfficialStateName = "New Zealand",
                Sovereignty = "UN member state",
                Alpha2Code = "NZ",
                Alpha3Code = "NZL",
                NumericCode = 554,
                SubdivisionCodeLinks = "ISO 3166-2:NZ",
                InternetccTLD = ".nz"
            });

            builder.HasData(new CountryCode()
            {
                Id = 172,
                CountryName = "Nicaragua",
                OfficialStateName = "The Republic of Nicaragua",
                Sovereignty = "UN member state",
                Alpha2Code = "NI",
                Alpha3Code = "NIC",
                NumericCode = 558,
                SubdivisionCodeLinks = "ISO 3166-2:NI",
                InternetccTLD = ".ni"
            });

            builder.HasData(new CountryCode()
            {
                Id = 173,
                CountryName = "Niger (the)",
                OfficialStateName = "The Republic of the Niger",
                Sovereignty = "UN member state",
                Alpha2Code = "NE",
                Alpha3Code = "NER",
                NumericCode = 562,
                SubdivisionCodeLinks = "ISO 3166-2:NE",
                InternetccTLD = ".ne"
            });

            builder.HasData(new CountryCode()
            {
                Id = 174,
                CountryName = "Nigeria",
                OfficialStateName = "The Federal Republic of Nigeria",
                Sovereignty = "UN member state",
                Alpha2Code = "NG",
                Alpha3Code = "NGA",
                NumericCode = 566,
                SubdivisionCodeLinks = "ISO 3166-2:NG",
                InternetccTLD = ".ng"
            });

            builder.HasData(new CountryCode()
            {
                Id = 175,
                CountryName = "Niue",
                OfficialStateName = "Niue",
                Sovereignty = "New Zealand",
                Alpha2Code = "NU",
                Alpha3Code = "NIU",
                NumericCode = 570,
                SubdivisionCodeLinks = "ISO 3166-2:NU",
                InternetccTLD = ".nu"
            });

            builder.HasData(new CountryCode()
            {
                Id = 176,
                CountryName = "Norfolk Island",
                OfficialStateName = "The Territory of Norfolk Island",
                Sovereignty = "Australia",
                Alpha2Code = "NF",
                Alpha3Code = "NFK",
                NumericCode = 574,
                SubdivisionCodeLinks = "ISO 3166-2:NF",
                InternetccTLD = ".nf"
            });

            builder.HasData(new CountryCode()
            {
                Id = 178,
                CountryName = "Northern Mariana Islands (the)",
                OfficialStateName = "The Commonwealth of the Northern Mariana Islands",
                Sovereignty = "United States",
                Alpha2Code = "MP",
                Alpha3Code = "MNP",
                NumericCode = 580,
                SubdivisionCodeLinks = "ISO 3166-2:MP",
                InternetccTLD = ".mp"
            });

            builder.HasData(new CountryCode()
            {
                Id = 179,
                CountryName = "Norway",
                OfficialStateName = "The Kingdom of Norway",
                Sovereignty = "UN member state",
                Alpha2Code = "NO",
                Alpha3Code = "NOR",
                NumericCode = 578,
                SubdivisionCodeLinks = "ISO 3166-2:NO",
                InternetccTLD = ".no"
            });

            builder.HasData(new CountryCode()
            {
                Id = 180,
                CountryName = "Oman",
                OfficialStateName = "The Sultanate of Oman",
                Sovereignty = "UN member state",
                Alpha2Code = "OM",
                Alpha3Code = "OMN",
                NumericCode = 512,
                SubdivisionCodeLinks = "ISO 3166-2:OM",
                InternetccTLD = ".om"
            });

            builder.HasData(new CountryCode()
            {
                Id = 181,
                CountryName = "Pakistan",
                OfficialStateName = "The Islamic Republic of Pakistan",
                Sovereignty = "UN member state",
                Alpha2Code = "PK",
                Alpha3Code = "PAK",
                NumericCode = 586,
                SubdivisionCodeLinks = "ISO 3166-2:PK",
                InternetccTLD = ".pk"
            });

            builder.HasData(new CountryCode()
            {
                Id = 182,
                CountryName = "Palau",
                OfficialStateName = "The Republic of Palau",
                Sovereignty = "UN member state",
                Alpha2Code = "PW",
                Alpha3Code = "PLW",
                NumericCode = 585,
                SubdivisionCodeLinks = "ISO 3166-2:PW",
                InternetccTLD = ".pw"
            });

            builder.HasData(new CountryCode()
            {
                Id = 183,
                CountryName = "Palestine, State of",
                OfficialStateName = "The State of Palestine",
                Sovereignty = "UN observer state",
                Alpha2Code = "PS",
                Alpha3Code = "PSE",
                NumericCode = 275,
                SubdivisionCodeLinks = "ISO 3166-2:PS",
                InternetccTLD = ".ps"
            });

            builder.HasData(new CountryCode()
            {
                Id = 184,
                CountryName = "Panama",
                OfficialStateName = "The Republic of Panamá",
                Sovereignty = "UN member state",
                Alpha2Code = "PA",
                Alpha3Code = "PAN",
                NumericCode = 591,
                SubdivisionCodeLinks = "ISO 3166-2:PA",
                InternetccTLD = ".pa"
            });

            builder.HasData(new CountryCode()
            {
                Id = 185,
                CountryName = "Papua New Guinea",
                OfficialStateName = "The Independent State of Papua New Guinea",
                Sovereignty = "UN member state",
                Alpha2Code = "PG",
                Alpha3Code = "PNG",
                NumericCode = 598,
                SubdivisionCodeLinks = "ISO 3166-2:PG",
                InternetccTLD = ".pg"
            });

            builder.HasData(new CountryCode()
            {
                Id = 186,
                CountryName = "Paraguay",
                OfficialStateName = "The Republic of Paraguay",
                Sovereignty = "UN member state",
                Alpha2Code = "PY",
                Alpha3Code = "PRY",
                NumericCode = 600,
                SubdivisionCodeLinks = "ISO 3166-2:PY",
                InternetccTLD = ".py"
            });

            builder.HasData(new CountryCode()
            {
                Id = 188,
                CountryName = "Peru",
                OfficialStateName = "The Republic of Perú",
                Sovereignty = "UN member state",
                Alpha2Code = "PE",
                Alpha3Code = "PER",
                NumericCode = 604,
                SubdivisionCodeLinks = "ISO 3166-2:PE",
                InternetccTLD = ".pe"
            });

            builder.HasData(new CountryCode()
            {
                Id = 189,
                CountryName = "Philippines (the)",
                OfficialStateName = "The Republic of the Philippines",
                Sovereignty = "UN member state",
                Alpha2Code = "PH",
                Alpha3Code = "PHL",
                NumericCode = 608,
                SubdivisionCodeLinks = "ISO 3166-2:PH",
                InternetccTLD = ".ph"
            });

            builder.HasData(new CountryCode()
            {
                Id = 190,
                CountryName = "Pitcairn [u]",
                OfficialStateName = "The Pitcairn, Henderson, Ducie and Oeno Islands",
                Sovereignty = "United Kingdom",
                Alpha2Code = "PN",
                Alpha3Code = "PCN",
                NumericCode = 612,
                SubdivisionCodeLinks = "ISO 3166-2:PN",
                InternetccTLD = ".pn"
            });

            builder.HasData(new CountryCode()
            {
                Id = 191,
                CountryName = "Poland",
                OfficialStateName = "The Republic of Poland",
                Sovereignty = "UN member state",
                Alpha2Code = "PL",
                Alpha3Code = "POL",
                NumericCode = 616,
                SubdivisionCodeLinks = "ISO 3166-2:PL",
                InternetccTLD = ".pl"
            });

            builder.HasData(new CountryCode()
            {
                Id = 192,
                CountryName = "Portugal",
                OfficialStateName = "The Portuguese Republic",
                Sovereignty = "UN member state",
                Alpha2Code = "PT",
                Alpha3Code = "PRT",
                NumericCode = 620,
                SubdivisionCodeLinks = "ISO 3166-2:PT",
                InternetccTLD = ".pt"
            });

            builder.HasData(new CountryCode()
            {
                Id = 193,
                CountryName = "Puerto Rico",
                OfficialStateName = "The Commonwealth of Puerto Rico",
                Sovereignty = "United States",
                Alpha2Code = "PR",
                Alpha3Code = "PRI",
                NumericCode = 630,
                SubdivisionCodeLinks = "ISO 3166-2:PR",
                InternetccTLD = ".pr"
            });

            builder.HasData(new CountryCode()
            {
                Id = 194,
                CountryName = "Qatar",
                OfficialStateName = "The State of Qatar",
                Sovereignty = "UN member state",
                Alpha2Code = "QA",
                Alpha3Code = "QAT",
                NumericCode = 634,
                SubdivisionCodeLinks = "ISO 3166-2:QA",
                InternetccTLD = ".qa"
            });

            builder.HasData(new CountryCode()
            {
                Id = 198,
                CountryName = "Réunion",
                OfficialStateName = "Réunion",
                Sovereignty = "France",
                Alpha2Code = "RE",
                Alpha3Code = "REU",
                NumericCode = 638,
                SubdivisionCodeLinks = "ISO 3166-2:RE",
                InternetccTLD = ".re"
            });

            builder.HasData(new CountryCode()
            {
                Id = 199,
                CountryName = "Romania",
                OfficialStateName = "Romania",
                Sovereignty = "UN member state",
                Alpha2Code = "RO",
                Alpha3Code = "ROU",
                NumericCode = 642,
                SubdivisionCodeLinks = "ISO 3166-2:RO",
                InternetccTLD = ".ro"
            });

            builder.HasData(new CountryCode()
            {
                Id = 200,
                CountryName = "Russian Federation (the)",
                OfficialStateName = "The Russian Federation",
                Sovereignty = "UN member state",
                Alpha2Code = "RU",
                Alpha3Code = "RUS",
                NumericCode = 643,
                SubdivisionCodeLinks = "ISO 3166-2:RU",
                InternetccTLD = ".ru"
            });

            builder.HasData(new CountryCode()
            {
                Id = 201,
                CountryName = "Rwanda",
                OfficialStateName = "The Republic of Rwanda",
                Sovereignty = "UN member state",
                Alpha2Code = "RW",
                Alpha3Code = "RWA",
                NumericCode = 646,
                SubdivisionCodeLinks = "ISO 3166-2:RW",
                InternetccTLD = ".rw"
            });

            builder.HasData(new CountryCode()
            {
                Id = 204,
                CountryName = "Saint Barthélemy",
                OfficialStateName = "The Collectivity of Saint-Barthélemy",
                Sovereignty = "France",
                Alpha2Code = "BL",
                Alpha3Code = "BLM",
                NumericCode = 652,
                SubdivisionCodeLinks = "ISO 3166-2:BL",
                InternetccTLD = ".bl"
            });

            builder.HasData(new CountryCode()
            {
                Id = 205,
                CountryName = "Saint Helena",
                OfficialStateName = "Saint Helena, Ascension and Tristan da Cunha",
                Sovereignty = "United Kingdom",
                Alpha2Code = "SH",
                Alpha3Code = "SHN",
                NumericCode = 654,
                SubdivisionCodeLinks = "ISO 3166-2:SH",
                InternetccTLD = ".sh"
            });

            builder.HasData(new CountryCode()
            {
                Id = 208,
                CountryName = "Saint Kitts and Nevis",
                OfficialStateName = "Saint Kitts and Nevis",
                Sovereignty = "UN member state",
                Alpha2Code = "KN",
                Alpha3Code = "KNA",
                NumericCode = 659,
                SubdivisionCodeLinks = "ISO 3166-2:KN",
                InternetccTLD = ".kn"
            });

            builder.HasData(new CountryCode()
            {
                Id = 209,
                CountryName = "Saint Lucia",
                OfficialStateName = "Saint Lucia",
                Sovereignty = "UN member state",
                Alpha2Code = "LC",
                Alpha3Code = "LCA",
                NumericCode = 662,
                SubdivisionCodeLinks = "ISO 3166-2:LC",
                InternetccTLD = ".lc"
            });

            builder.HasData(new CountryCode()
            {
                Id = 210,
                CountryName = "Saint Martin (French part)",
                OfficialStateName = "The Collectivity of Saint-Martin",
                Sovereignty = "France",
                Alpha2Code = "MF",
                Alpha3Code = "MAF",
                NumericCode = 663,
                SubdivisionCodeLinks = "ISO 3166-2:MF",
                InternetccTLD = ".mf"
            });

            builder.HasData(new CountryCode()
            {
                Id = 211,
                CountryName = "Saint Pierre and Miquelon",
                OfficialStateName = "The Overseas Collectivity of Saint-Pierre and Miquelon",
                Sovereignty = "France",
                Alpha2Code = "PM",
                Alpha3Code = "SPM",
                NumericCode = 666,
                SubdivisionCodeLinks = "ISO 3166-2:PM",
                InternetccTLD = ".pm"
            });

            builder.HasData(new CountryCode()
            {
                Id = 212,
                CountryName = "Saint Vincent and the Grenadines",
                OfficialStateName = "Saint Vincent and the Grenadines",
                Sovereignty = "UN member state",
                Alpha2Code = "VC",
                Alpha3Code = "VCT",
                NumericCode = 670,
                SubdivisionCodeLinks = "ISO 3166-2:VC",
                InternetccTLD = ".vc"
            });

            builder.HasData(new CountryCode()
            {
                Id = 213,
                CountryName = "Samoa",
                OfficialStateName = "The Independent State of Samoa",
                Sovereignty = "UN member state",
                Alpha2Code = "WS",
                Alpha3Code = "WSM",
                NumericCode = 882,
                SubdivisionCodeLinks = "ISO 3166-2:WS",
                InternetccTLD = ".ws"
            });

            builder.HasData(new CountryCode()
            {
                Id = 214,
                CountryName = "San Marino",
                OfficialStateName = "The Republic of San Marino",
                Sovereignty = "UN member state",
                Alpha2Code = "SM",
                Alpha3Code = "SMR",
                NumericCode = 674,
                SubdivisionCodeLinks = "ISO 3166-2:SM",
                InternetccTLD = ".sm"
            });

            builder.HasData(new CountryCode()
            {
                Id = 215,
                CountryName = "Sao Tome and Principe",
                OfficialStateName = "The Democratic Republic of São Tomé and Príncipe",
                Sovereignty = "UN member state",
                Alpha2Code = "ST",
                Alpha3Code = "STP",
                NumericCode = 678,
                SubdivisionCodeLinks = "ISO 3166-2:ST",
                InternetccTLD = ".st"
            });

            builder.HasData(new CountryCode()
            {
                Id = 216,
                CountryName = "Saudi Arabia",
                OfficialStateName = "The Kingdom of Saudi Arabia",
                Sovereignty = "UN member state",
                Alpha2Code = "SA",
                Alpha3Code = "SAU",
                NumericCode = 682,
                SubdivisionCodeLinks = "ISO 3166-2:SA",
                InternetccTLD = ".sa"
            });

            builder.HasData(new CountryCode()
            {
                Id = 217,
                CountryName = "Senegal",
                OfficialStateName = "The Republic of Senegal",
                Sovereignty = "UN member state",
                Alpha2Code = "SN",
                Alpha3Code = "SEN",
                NumericCode = 686,
                SubdivisionCodeLinks = "ISO 3166-2:SN",
                InternetccTLD = ".sn"
            });

            builder.HasData(new CountryCode()
            {
                Id = 218,
                CountryName = "Serbia",
                OfficialStateName = "The Republic of Serbia",
                Sovereignty = "UN member state",
                Alpha2Code = "RS",
                Alpha3Code = "SRB",
                NumericCode = 688,
                SubdivisionCodeLinks = "ISO 3166-2:RS",
                InternetccTLD = ".rs"
            });

            builder.HasData(new CountryCode()
            {
                Id = 219,
                CountryName = "Seychelles",
                OfficialStateName = "The Republic of Seychelles",
                Sovereignty = "UN member state",
                Alpha2Code = "SC",
                Alpha3Code = "SYC",
                NumericCode = 690,
                SubdivisionCodeLinks = "ISO 3166-2:SC",
                InternetccTLD = ".sc"
            });

            builder.HasData(new CountryCode()
            {
                Id = 220,
                CountryName = "Sierra Leone",
                OfficialStateName = "The Republic of Sierra Leone",
                Sovereignty = "UN member state",
                Alpha2Code = "SL",
                Alpha3Code = "SLE",
                NumericCode = 694,
                SubdivisionCodeLinks = "ISO 3166-2:SL",
                InternetccTLD = ".sl"
            });

            builder.HasData(new CountryCode()
            {
                Id = 221,
                CountryName = "Singapore",
                OfficialStateName = "The Republic of Singapore",
                Sovereignty = "UN member state",
                Alpha2Code = "SG",
                Alpha3Code = "SGP",
                NumericCode = 702,
                SubdivisionCodeLinks = "ISO 3166-2:SG",
                InternetccTLD = ".sg"
            });

            builder.HasData(new CountryCode()
            {
                Id = 223,
                CountryName = "Sint Maarten (Dutch part)",
                OfficialStateName = "Sint Maarten",
                Sovereignty = "Netherlands",
                Alpha2Code = "SX",
                Alpha3Code = "SXM",
                NumericCode = 534,
                SubdivisionCodeLinks = "ISO 3166-2:SX",
                InternetccTLD = ".sx"
            });

            builder.HasData(new CountryCode()
            {
                Id = 224,
                CountryName = "Slovakia",
                OfficialStateName = "The Slovak Republic",
                Sovereignty = "UN member state",
                Alpha2Code = "SK",
                Alpha3Code = "SVK",
                NumericCode = 703,
                SubdivisionCodeLinks = "ISO 3166-2:SK",
                InternetccTLD = ".sk"
            });

            builder.HasData(new CountryCode()
            {
                Id = 225,
                CountryName = "Slovenia",
                OfficialStateName = "The Republic of Slovenia",
                Sovereignty = "UN member state",
                Alpha2Code = "SI",
                Alpha3Code = "SVN",
                NumericCode = 705,
                SubdivisionCodeLinks = "ISO 3166-2:SI",
                InternetccTLD = ".si"
            });

            builder.HasData(new CountryCode()
            {
                Id = 226,
                CountryName = "Solomon Islands",
                OfficialStateName = "The Solomon Islands",
                Sovereignty = "UN member state",
                Alpha2Code = "SB",
                Alpha3Code = "SLB",
                NumericCode = 90,
                SubdivisionCodeLinks = "ISO 3166-2:SB",
                InternetccTLD = ".sb"
            });

            builder.HasData(new CountryCode()
            {
                Id = 227,
                CountryName = "Somalia",
                OfficialStateName = "The Federal Republic of Somalia",
                Sovereignty = "UN member state",
                Alpha2Code = "SO",
                Alpha3Code = "SOM",
                NumericCode = 706,
                SubdivisionCodeLinks = "ISO 3166-2:SO",
                InternetccTLD = ".so"
            });

            builder.HasData(new CountryCode()
            {
                Id = 228,
                CountryName = "South Africa",
                OfficialStateName = "The Republic of South Africa",
                Sovereignty = "UN member state",
                Alpha2Code = "ZA",
                Alpha3Code = "ZAF",
                NumericCode = 710,
                SubdivisionCodeLinks = "ISO 3166-2:ZA",
                InternetccTLD = ".za"
            });

            builder.HasData(new CountryCode()
            {
                Id = 229,
                CountryName = "South Georgia and the South Sandwich Islands",
                OfficialStateName = "South Georgia and the South Sandwich Islands",
                Sovereignty = "United Kingdom",
                Alpha2Code = "GS",
                Alpha3Code = "SGS",
                NumericCode = 239,
                SubdivisionCodeLinks = "ISO 3166-2:GS",
                InternetccTLD = ".gs"
            });

            builder.HasData(new CountryCode()
            {
                Id = 231,
                CountryName = "South Sudan",
                OfficialStateName = "The Republic of South Sudan",
                Sovereignty = "UN member state",
                Alpha2Code = "SS",
                Alpha3Code = "SSD",
                NumericCode = 728,
                SubdivisionCodeLinks = "ISO 3166-2:SS",
                InternetccTLD = ".ss"
            });

            builder.HasData(new CountryCode()
            {
                Id = 232,
                CountryName = "Spain",
                OfficialStateName = "The Kingdom of Spain",
                Sovereignty = "UN member state",
                Alpha2Code = "ES",
                Alpha3Code = "ESP",
                NumericCode = 724,
                SubdivisionCodeLinks = "ISO 3166-2:ES",
                InternetccTLD = ".es"
            });

            builder.HasData(new CountryCode()
            {
                Id = 233,
                CountryName = "Sri Lanka",
                OfficialStateName = "The Democratic Socialist Republic of Sri Lanka",
                Sovereignty = "UN member state",
                Alpha2Code = "LK",
                Alpha3Code = "LKA",
                NumericCode = 144,
                SubdivisionCodeLinks = "ISO 3166-2:LK",
                InternetccTLD = ".lk"
            });

            builder.HasData(new CountryCode()
            {
                Id = 234,
                CountryName = "Sudan (the)",
                OfficialStateName = "The Republic of the Sudan",
                Sovereignty = "UN member state",
                Alpha2Code = "SD",
                Alpha3Code = "SDN",
                NumericCode = 729,
                SubdivisionCodeLinks = "ISO 3166-2:SD",
                InternetccTLD = ".sd"
            });

            builder.HasData(new CountryCode()
            {
                Id = 235,
                CountryName = "Suriname",
                OfficialStateName = "The Republic of Suriname",
                Sovereignty = "UN member state",
                Alpha2Code = "SR",
                Alpha3Code = "SUR",
                NumericCode = 740,
                SubdivisionCodeLinks = "ISO 3166-2:SR",
                InternetccTLD = ".sr"
            });

            builder.HasData(new CountryCode()
            {
                Id = 236,
                CountryName = "Svalbard",
                OfficialStateName = "Svalbard and Jan Mayen",
                Sovereignty = "Norway",
                Alpha2Code = "SJ",
                Alpha3Code = "SJM",
                NumericCode = 744,
                SubdivisionCodeLinks = "ISO 3166-2:SJ",
                InternetccTLD = ""
            });

            builder.HasData(new CountryCode()
            {
                Id = 238,
                CountryName = "Sweden",
                OfficialStateName = "The Kingdom of Sweden",
                Sovereignty = "UN member state",
                Alpha2Code = "SE",
                Alpha3Code = "SWE",
                NumericCode = 752,
                SubdivisionCodeLinks = "ISO 3166-2:SE",
                InternetccTLD = ".se"
            });

            builder.HasData(new CountryCode()
            {
                Id = 239,
                CountryName = "Switzerland",
                OfficialStateName = "The Swiss Confederation",
                Sovereignty = "UN member state",
                Alpha2Code = "CH",
                Alpha3Code = "CHE",
                NumericCode = 756,
                SubdivisionCodeLinks = "ISO 3166-2:CH",
                InternetccTLD = ".ch"
            });

            builder.HasData(new CountryCode()
            {
                Id = 240,
                CountryName = "Syrian Arab Republic (the) [x]",
                OfficialStateName = "The Syrian Arab Republic",
                Sovereignty = "UN member state",
                Alpha2Code = "SY",
                Alpha3Code = "SYR",
                NumericCode = 760,
                SubdivisionCodeLinks = "ISO 3166-2:SY",
                InternetccTLD = ".sy"
            });

            builder.HasData(new CountryCode()
            {
                Id = 241,
                CountryName = "Taiwan (Province of China) [y]",
                OfficialStateName = "The Republic of China",
                Sovereignty = "Disputed [z]",
                Alpha2Code = "TW",
                Alpha3Code = "TWN",
                NumericCode = 158,
                SubdivisionCodeLinks = "ISO 3166-2:TW",
                InternetccTLD = ".tw"
            });

            builder.HasData(new CountryCode()
            {
                Id = 242,
                CountryName = "Tajikistan",
                OfficialStateName = "The Republic of Tajikistan",
                Sovereignty = "UN member state",
                Alpha2Code = "TJ",
                Alpha3Code = "TJK",
                NumericCode = 762,
                SubdivisionCodeLinks = "ISO 3166-2:TJ",
                InternetccTLD = ".tj"
            });

            builder.HasData(new CountryCode()
            {
                Id = 243,
                CountryName = "Tanzania, the United Republic of",
                OfficialStateName = "The United Republic of Tanzania",
                Sovereignty = "UN member state",
                Alpha2Code = "TZ",
                Alpha3Code = "TZA",
                NumericCode = 834,
                SubdivisionCodeLinks = "ISO 3166-2:TZ",
                InternetccTLD = ".tz"
            });

            builder.HasData(new CountryCode()
            {
                Id = 244,
                CountryName = "Thailand",
                OfficialStateName = "The Kingdom of Thailand",
                Sovereignty = "UN member state",
                Alpha2Code = "TH",
                Alpha3Code = "THA",
                NumericCode = 764,
                SubdivisionCodeLinks = "ISO 3166-2:TH",
                InternetccTLD = ".th"
            });

            builder.HasData(new CountryCode()
            {
                Id = 245,
                CountryName = "Timor-Leste ",
                OfficialStateName = "The Democratic Republic of Timor-Leste",
                Sovereignty = "UN member state",
                Alpha2Code = "TL",
                Alpha3Code = "TLS",
                NumericCode = 626,
                SubdivisionCodeLinks = "ISO 3166-2:TL",
                InternetccTLD = ".tl"
            });

            builder.HasData(new CountryCode()
            {
                Id = 246,
                CountryName = "To",
                OfficialStateName = "The Tolese Republic",
                Sovereignty = "UN member state",
                Alpha2Code = "TG",
                Alpha3Code = "T",
                NumericCode = 768,
                SubdivisionCodeLinks = "ISO 3166-2:TG",
                InternetccTLD = ".tg"
            });

            builder.HasData(new CountryCode()
            {
                Id = 247,
                CountryName = "Tokelau",
                OfficialStateName = "Tokelau",
                Sovereignty = "New Zealand",
                Alpha2Code = "TK",
                Alpha3Code = "TKL",
                NumericCode = 772,
                SubdivisionCodeLinks = "ISO 3166-2:TK",
                InternetccTLD = ".tk"
            });

            builder.HasData(new CountryCode()
            {
                Id = 248,
                CountryName = "Tonga",
                OfficialStateName = "The Kingdom of Tonga",
                Sovereignty = "UN member state",
                Alpha2Code = "TO",
                Alpha3Code = "TON",
                NumericCode = 776,
                SubdivisionCodeLinks = "ISO 3166-2:TO",
                InternetccTLD = ".to"
            });

            builder.HasData(new CountryCode()
            {
                Id = 249,
                CountryName = "Trinidad and Toba",
                OfficialStateName = "The Republic of Trinidad and Toba",
                Sovereignty = "UN member state",
                Alpha2Code = "TT",
                Alpha3Code = "TTO",
                NumericCode = 780,
                SubdivisionCodeLinks = "ISO 3166-2:TT",
                InternetccTLD = ".tt"
            });

            builder.HasData(new CountryCode()
            {
                Id = 250,
                CountryName = "Tunisia",
                OfficialStateName = "The Republic of Tunisia",
                Sovereignty = "UN member state",
                Alpha2Code = "TN",
                Alpha3Code = "TUN",
                NumericCode = 788,
                SubdivisionCodeLinks = "ISO 3166-2:TN",
                InternetccTLD = ".tn"
            });

            builder.HasData(new CountryCode()
            {
                Id = 251,
                CountryName = "Türkiye [ab]",
                OfficialStateName = "The Republic of Türkiye",
                Sovereignty = "UN member state",
                Alpha2Code = "TR",
                Alpha3Code = "TUR",
                NumericCode = 792,
                SubdivisionCodeLinks = "ISO 3166-2:TR",
                InternetccTLD = ".tr"
            });

            builder.HasData(new CountryCode()
            {
                Id = 252,
                CountryName = "Turkmenistan",
                OfficialStateName = "Turkmenistan",
                Sovereignty = "UN member state",
                Alpha2Code = "TM",
                Alpha3Code = "TKM",
                NumericCode = 795,
                SubdivisionCodeLinks = "ISO 3166-2:TM",
                InternetccTLD = ".tm"
            });

            builder.HasData(new CountryCode()
            {
                Id = 253,
                CountryName = "Turks and Caicos Islands (the)",
                OfficialStateName = "The Turks and Caicos Islands",
                Sovereignty = "United Kingdom",
                Alpha2Code = "TC",
                Alpha3Code = "TCA",
                NumericCode = 796,
                SubdivisionCodeLinks = "ISO 3166-2:TC",
                InternetccTLD = ".tc"
            });

            builder.HasData(new CountryCode()
            {
                Id = 254,
                CountryName = "Tuvalu",
                OfficialStateName = "Tuvalu",
                Sovereignty = "UN member state",
                Alpha2Code = "TV",
                Alpha3Code = "TUV",
                NumericCode = 798,
                SubdivisionCodeLinks = "ISO 3166-2:TV",
                InternetccTLD = ".tv"
            });

            builder.HasData(new CountryCode()
            {
                Id = 255,
                CountryName = "Uganda",
                OfficialStateName = "The Republic of Uganda",
                Sovereignty = "UN member state",
                Alpha2Code = "UG",
                Alpha3Code = "UGA",
                NumericCode = 800,
                SubdivisionCodeLinks = "ISO 3166-2:UG",
                InternetccTLD = ".ug"
            });

            builder.HasData(new CountryCode()
            {
                Id = 256,
                CountryName = "Ukraine",
                OfficialStateName = "Ukraine",
                Sovereignty = "UN member state",
                Alpha2Code = "UA",
                Alpha3Code = "UKR",
                NumericCode = 804,
                SubdivisionCodeLinks = "ISO 3166-2:UA",
                InternetccTLD = ".ua"
            });

            builder.HasData(new CountryCode()
            {
                Id = 257,
                CountryName = "United Arab Emirates (the)",
                OfficialStateName = "The United Arab Emirates",
                Sovereignty = "UN member state",
                Alpha2Code = "AE",
                Alpha3Code = "ARE",
                NumericCode = 784,
                SubdivisionCodeLinks = "ISO 3166-2:AE",
                InternetccTLD = ".ae"
            });

            builder.HasData(new CountryCode()
            {
                Id = 258,
                CountryName = "United Kingdom of Great Britain and Northern Ireland (the)",
                OfficialStateName = "The United Kingdom of Great Britain and Northern Ireland",
                Sovereignty = "UN member state",
                Alpha2Code = "GB",
                Alpha3Code = "GBR",
                NumericCode = 826,
                SubdivisionCodeLinks = "ISO 3166-2:GB",
                InternetccTLD = ".gb .uk "
            });

            builder.HasData(new CountryCode()
            {
                Id = 259,
                CountryName = "United States Minor Outlying Islands (the) [ad]",
                OfficialStateName = "Baker Island, Howland Island, Jarvis Island, Johnston Atoll, Kingman Reef, Midway Atoll, Navassa Island, Palmyra Atoll, and Wake Island",
                Sovereignty = "United States",
                Alpha2Code = "UM",
                Alpha3Code = "UMI",
                NumericCode = 581,
                SubdivisionCodeLinks = "ISO 3166-2:UM",
                InternetccTLD = ""
            });

            builder.HasData(new CountryCode()
            {
                Id = 260,
                CountryName = "United States of America (the)",
                OfficialStateName = "The United States of America",
                Sovereignty = "UN member state",
                Alpha2Code = "US",
                Alpha3Code = "USA",
                NumericCode = 840,
                SubdivisionCodeLinks = "ISO 3166-2:US",
                InternetccTLD = ".us"
            });

            builder.HasData(new CountryCode()
            {
                Id = 262,
                CountryName = "Uruguay",
                OfficialStateName = "The Oriental Republic of Uruguay",
                Sovereignty = "UN member state",
                Alpha2Code = "UY",
                Alpha3Code = "URY",
                NumericCode = 858,
                SubdivisionCodeLinks = "ISO 3166-2:UY",
                InternetccTLD = ".uy"
            });

            builder.HasData(new CountryCode()
            {
                Id = 263,
                CountryName = "Uzbekistan",
                OfficialStateName = "The Republic of Uzbekistan",
                Sovereignty = "UN member state",
                Alpha2Code = "UZ",
                Alpha3Code = "UZB",
                NumericCode = 860,
                SubdivisionCodeLinks = "ISO 3166-2:UZ",
                InternetccTLD = ".uz"
            });

            builder.HasData(new CountryCode()
            {
                Id = 264,
                CountryName = "Vanuatu",
                OfficialStateName = "The Republic of Vanuatu",
                Sovereignty = "UN member state",
                Alpha2Code = "VU",
                Alpha3Code = "VUT",
                NumericCode = 548,
                SubdivisionCodeLinks = "ISO 3166-2:VU",
                InternetccTLD = ".vu"
            });

            builder.HasData(new CountryCode()
            {
                Id = 266,
                CountryName = "Venezuela (Bolivarian Republic of)",
                OfficialStateName = "The Bolivarian Republic of Venezuela",
                Sovereignty = "UN member state",
                Alpha2Code = "VE",
                Alpha3Code = "VEN",
                NumericCode = 862,
                SubdivisionCodeLinks = "ISO 3166-2:VE",
                InternetccTLD = ".ve"
            });

            builder.HasData(new CountryCode()
            {
                Id = 267,
                CountryName = "Viet Nam ",
                OfficialStateName = "The Socialist Republic of Viet Nam",
                Sovereignty = "UN member state",
                Alpha2Code = "VN",
                Alpha3Code = "VNM",
                NumericCode = 704,
                SubdivisionCodeLinks = "ISO 3166-2:VN",
                InternetccTLD = ".vn"
            });

            builder.HasData(new CountryCode()
            {
                Id = 268,
                CountryName = "Virgin Islands (British) [ag]",
                OfficialStateName = "The Virgin Islands",
                Sovereignty = "United Kingdom",
                Alpha2Code = "VG",
                Alpha3Code = "VGB",
                NumericCode = 92,
                SubdivisionCodeLinks = "ISO 3166-2:VG",
                InternetccTLD = ".vg"
            });

            builder.HasData(new CountryCode()
            {
                Id = 269,
                CountryName = "Virgin Islands (U.S.) [ah]",
                OfficialStateName = "The Virgin Islands of the United States",
                Sovereignty = "United States",
                Alpha2Code = "VI",
                Alpha3Code = "VIR",
                NumericCode = 850,
                SubdivisionCodeLinks = "ISO 3166-2:VI",
                InternetccTLD = ".vi"
            });

            builder.HasData(new CountryCode()
            {
                Id = 270,
                CountryName = "Wallis and Futuna",
                OfficialStateName = "The Territory of the Wallis and Futuna Islands",
                Sovereignty = "France",
                Alpha2Code = "WF",
                Alpha3Code = "WLF",
                NumericCode = 876,
                SubdivisionCodeLinks = "ISO 3166-2:WF",
                InternetccTLD = ".wf"
            });

            builder.HasData(new CountryCode()
            {
                Id = 271,
                CountryName = "Western Sahara [ai]",
                OfficialStateName = "The Sahrawi Arab Democratic Republic",
                Sovereignty = "Disputed [aj]",
                Alpha2Code = "EH",
                Alpha3Code = "ESH",
                NumericCode = 732,
                SubdivisionCodeLinks = "ISO 3166-2:EH",
                InternetccTLD = ""
            });

            builder.HasData(new CountryCode()
            {
                Id = 272,
                CountryName = "Yemen",
                OfficialStateName = "The Republic of Yemen",
                Sovereignty = "UN member state",
                Alpha2Code = "YE",
                Alpha3Code = "YEM",
                NumericCode = 887,
                SubdivisionCodeLinks = "ISO 3166-2:YE",
                InternetccTLD = ".ye"
            });

            builder.HasData(new CountryCode()
            {
                Id = 273,
                CountryName = "Zambia",
                OfficialStateName = "The Republic of Zambia",
                Sovereignty = "UN member state",
                Alpha2Code = "ZM",
                Alpha3Code = "ZMB",
                NumericCode = 894,
                SubdivisionCodeLinks = "ISO 3166-2:ZM",
                InternetccTLD = ".zm"
            });

            builder.HasData(new CountryCode()
            {
                Id = 274,
                CountryName = "Zimbabwe",
                OfficialStateName = "The Republic of Zimbabwe",
                Sovereignty = "UN member state",
                Alpha2Code = "ZW",
                Alpha3Code = "ZWE",
                NumericCode = 716,
                SubdivisionCodeLinks = "ISO 3166-2:ZW",
                InternetccTLD = ".zw"
            });

            builder.HasData(new CountryCode()
            {
                Id = 275,
                CountryName = "Sint Eustatius",
                OfficialStateName = "Bonaire, Sint Eustatius and Saba",
                Sovereignty = "Netherlands",
                Alpha2Code = "BQ",
                Alpha3Code = "BES",
                NumericCode = 535,
                SubdivisionCodeLinks = "ISO 3166-2:BQ",
                InternetccTLD = ".bq .nl "
            });

            builder.HasData(new CountryCode()
            {
                Id = 280,
                CountryName = "Brunei Darussalam [e]",
                OfficialStateName = "The Nation of Brunei, the Abode of Peace",
                Sovereignty = "UN member state",
                Alpha2Code = "BN",
                Alpha3Code = "BRN",
                NumericCode = 96,
                SubdivisionCodeLinks = "ISO 3166-2:BN",
                InternetccTLD = ".bn"
            });

            builder.HasData(new CountryCode()
            {
                Id = 281,
                CountryName = "Cabo Verde ",
                OfficialStateName = "The Republic of Cabo Verde",
                Sovereignty = "UN member state",
                Alpha2Code = "CV",
                Alpha3Code = "CPV",
                NumericCode = 132,
                SubdivisionCodeLinks = "ISO 3166-2:CV",
                InternetccTLD = ".cv"
            });

            builder.HasData(new CountryCode()
            {
                Id = 282,
                CountryName = "Costa Rica",
                OfficialStateName = "The Republic of Costa Rica",
                Sovereignty = "UN member state",
                Alpha2Code = "CR",
                Alpha3Code = "CRI",
                NumericCode = 188,
                SubdivisionCodeLinks = "ISO 3166-2:CR",
                InternetccTLD = ".cr"
            });

            builder.HasData(new CountryCode()
            {
                Id = 283,
                CountryName = "Curaçao",
                OfficialStateName = "The Country of Curaçao",
                Sovereignty = "Netherlands",
                Alpha2Code = "CW",
                Alpha3Code = "CUW",
                NumericCode = 531,
                SubdivisionCodeLinks = "ISO 3166-2:CW",
                InternetccTLD = ".cw"
            });

            builder.HasData(new CountryCode()
            {
                Id = 286,
                CountryName = "Tristan da Cunha",
                OfficialStateName = "Saint Helena, Ascension and Tristan da Cunha",
                Sovereignty = "United Kingdom",
                Alpha2Code = "SH",
                Alpha3Code = "SHN",
                NumericCode = 654,
                SubdivisionCodeLinks = "ISO 3166-2:SH",
                InternetccTLD = ".sh"
            });

            builder.HasData(new CountryCode()
            {
                Id = 287,
                CountryName = "Svalbard",
                OfficialStateName = "Svalbard and Jan Mayen",
                Sovereignty = "Norway",
                Alpha2Code = "SJ",
                Alpha3Code = "SJM",
                NumericCode = 744,
                SubdivisionCodeLinks = "ISO 3166-2:SJ",
                InternetccTLD = ""
            });

            builder.HasData(new CountryCode()
            {
                Id = 288,
                CountryName = "Afghanistan",
                OfficialStateName = "The Islamic Republic of Afghanistan",
                Sovereignty = "UN member state",
                Alpha2Code = "AF",
                Alpha3Code = "AFG",
                NumericCode = 4,
                SubdivisionCodeLinks = "ISO 3166-2:AF",
                InternetccTLD = ".af"
            });

            builder.HasData(new CountryCode()
            {
                Id = 289,
                CountryName = "Åland Islands",
                OfficialStateName = "Åland",
                Sovereignty = "Finland",
                Alpha2Code = "AX",
                Alpha3Code = "ALA",
                NumericCode = 248,
                SubdivisionCodeLinks = "ISO 3166-2:AX",
                InternetccTLD = ".ax"
            });
        }
        }
}
