using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Owl.Overdrive.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Owl.Overdrive.Infrastructure.Persistence.Configurations
{
    public class CompanyConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<Company>
    {
        public CompanyConfiguration():base()
        {
            
        }

        public void Configure(EntityTypeBuilder<Company> builder)
        {
            ApplyConfiguration(builder);
            ConfigurationBase(builder);
        }

        public static void ApplyConfiguration(EntityTypeBuilder<Company> builder)
        {
            // Table Name
            builder.ToTable("Companies");

            // Properties parameters
            builder.Property(p => p.Name).HasMaxLength(255);
            builder.Property(p => p.Description).HasMaxLength(255);
            builder.Property(p => p.FoundedIn).HasColumnType("dateime2(7)");
            builder.Property(p => p.ChangeDate).HasColumnType("dateime2(7)");
            builder.Property(p => p.OfficialWebsite).HasMaxLength(255);
            builder.Property(p => p.Twitter).HasMaxLength(255);
            builder.HasOne(e => e.ParentCompany)
                .WithMany()
                .HasForeignKey(e => e.ParentCompanyId);
            builder.HasOne(e => e.Country)
                .WithMany()
                .HasForeignKey(e => e.CountryId);
            builder.HasOne(e => e.Status)
                .WithMany()
                .HasForeignKey(e => e.StatusId);

        }

        private static void Seed(EntityTypeBuilder<Company> builder)
        {
            builder.HasData(new Company() { Id = 1, N'Albania', N'The Republic of Albania', N'UN member state', N'AL', N'ALB', 8, N'ISO 3166-2:AL', N'.al' };
            builder.HasData(new Company() { Id = 2, N'Algeria', N'The People''s Democratic Republic of Algeria', N'UN member state', N'DZ', N'DZA', 12, N'ISO 3166-2:DZ', N'.dz' };
            builder.HasData(new Company() { Id = 3, N'American Samoa', N'The Territory of American Samoa', N'United States', N'AS', N'ASM', 16, N'ISO 3166-2:AS', N'.as' };
            builder.HasData(new Company() { Id = 4, N'Andorra', N'The Principality of Andorra', N'UN member state', N'AD', N'AND', 20, N'ISO 3166-2:AD', N'.ad' };
            builder.HasData(new Company() { Id = 5, N'Anla', N'The Republic of Anla', N'UN member state', N'AO', N'A', 24, N'ISO 3166-2:AO', N'.ao' };
            builder.HasData(new Company() { Id = 6, N'Anguilla', N'Anguilla', N'United Kingdom', N'AI', N'AIA', 660, N'ISO 3166-2:AI', N'.ai' };
            builder.HasData(new Company() { Id = 7, N'Antarctica', N'All land and ice shelves south of the 60th parallel south', N'Antarctic Treaty', N'AQ', N'ATA', 10, N'ISO 3166-2:AQ', N'.aq' };
            builder.HasData(new Company() { Id = 8, N'Antigua and Barbuda', N'Antigua and Barbuda', N'UN member state', N'AG', N'ATG', 28, N'ISO 3166-2:AG', N'.ag' };
            builder.HasData(new Company() { Id = 9, N'Argentina', N'The Argentine Republic', N'UN member state', N'AR', N'ARG', 32, N'ISO 3166-2:AR', N'.ar' };
            builder.HasData(new Company() { Id = 10, N'Armenia', N'The Republic of Armenia', N'UN member state', N'AM', N'ARM', 51, N'ISO 3166-2:AM', N'.am' };
            builder.HasData(new Company() { Id = 11, N'Aruba', N'Aruba', N'Netherlands', N'AW', N'ABW', 533, N'ISO 3166-2:AW', N'.aw' };
            builder.HasData(new Company() { Id = 12, N'Australia', N'The Commonwealth of Australia', N'UN member state', N'AU', N'AUS', 36, N'ISO 3166-2:AU', N'.au' };
            builder.HasData(new Company() { Id = 13, N'Austria', N'The Republic of Austria', N'UN member state', N'AT', N'AUT', 40, N'ISO 3166-2:AT', N'.at' };
            builder.HasData(new Company() { Id = 14, N'Azerbaijan', N'The Republic of Azerbaijan', N'UN member state', N'AZ', N'AZE', 31, N'ISO 3166-2:AZ', N'.az' };
            builder.HasData(new Company() { Id = 15, N'Bahamas (the),', N'The Commonwealth of The Bahamas', N'UN member state', N'BS', N'BHS', 44, N'ISO 3166-2:BS', N'.bs' };
            builder.HasData(new Company() { Id = 16, N'Bahrain', N'The Kingdom of Bahrain', N'UN member state', N'BH', N'BHR', 48, N'ISO 3166-2:BH', N'.bh' };
            builder.HasData(new Company() { Id = 17, N'Bangladesh', N'The People''s Republic of Bangladesh', N'UN member state', N'BD', N'BGD', 50, N'ISO 3166-2:BD', N'.bd' };
            builder.HasData(new Company() { Id = 18, N'Barbados', N'Barbados', N'UN member state', N'BB', N'BRB', 52, N'ISO 3166-2:BB', N'.bb' };
            builder.HasData(new Company() { Id = 19, N'Belarus', N'The Republic of Belarus', N'UN member state', N'BY', N'BLR', 112, N'ISO 3166-2:BY', N'.by' };
            builder.HasData(new Company() { Id = 20, N'Belgium', N'The Kingdom of Belgium', N'UN member state', N'BE', N'BEL', 56, N'ISO 3166-2:BE', N'.be' };
            builder.HasData(new Company() { Id = 21, N'Belize', N'Belize', N'UN member state', N'BZ', N'BLZ', 84, N'ISO 3166-2:BZ', N'.bz' };
            builder.HasData(new Company() { Id = 22, N'Benin', N'The Republic of Benin', N'UN member state', N'BJ', N'BEN', 204, N'ISO 3166-2:BJ', N'.bj' };
            builder.HasData(new Company() { Id = 23, N'Bermuda', N'Bermuda', N'United Kingdom', N'BM', N'BMU', 60, N'ISO 3166-2:BM', N'.bm' };
            builder.HasData(new Company() { Id = 24, N'Bhutan', N'The Kingdom of Bhutan', N'UN member state', N'BT', N'BTN', 64, N'ISO 3166-2:BT', N'.bt' };
            builder.HasData(new Company() { Id = 25, N'Bolivia (Plurinational State of)', N'The Plurinational State of Bolivia', N'UN member state', N'BO', N'BOL', 68, N'ISO 3166-2:BO', N'.bo' };
            builder.HasData(new Company() { Id = 26, N'Bonaire', N'Bonaire, Sint Eustatius and Saba', N'Netherlands', N'BQ', N'BES', 535, N'ISO 3166-2:BQ', N'.bq .nl ' };
            builder.HasData(new Company() { Id = 29, N'Bosnia and Herzevina', N'Bosnia and Herzevina', N'UN member state', N'BA', N'BIH', 70, N'ISO 3166-2:BA', N'.ba' };
            builder.HasData(new Company() { Id = 30, N'Botswana', N'The Republic of Botswana', N'UN member state', N'BW', N'BWA', 72, N'ISO 3166-2:BW', N'.bw' };
            builder.HasData(new Company() { Id = 31, N'Bouvet Island', N'Bouvet Island', N'Norway', N'BV', N'BVT', 74, N'ISO 3166-2:BV', N'' };
            builder.HasData(new Company() { Id = 32, N'Brazil', N'The Federative Republic of Brazil', N'UN member state', N'BR', N'BRA', 76, N'ISO 3166-2:BR', N'.br' };
            builder.HasData(new Company() { Id = 33, N'British Indian Ocean Territory builder.HasData(new Company() { Id = the)', N'The British Indian Ocean Territory', N'United Kingdom', N'IO', N'IOT', 86, N'ISO 3166-2:IO', N'.io' };
            builder.HasData(new Company() { Id = 35, N'Brunei Darussalam [e]', N'The Nation of Brunei, the Abode of Peace', N'UN member state', N'BN', N'BRN', 96, N'ISO 3166-2:BN', N'.bn' };
            builder.HasData(new Company() { Id = 36, N'Bulgaria', N'The Republic of Bulgaria', N'UN member state', N'BG', N'BGR', 100, N'ISO 3166-2:BG', N'.bg' };
            builder.HasData(new Company() { Id = 37, N'Burkina Faso', N'Burkina Faso', N'UN member state', N'BF', N'BFA', 854, N'ISO 3166-2:BF', N'.bf' };
            builder.HasData(new Company() { Id = 39, N'Burundi', N'The Republic of Burundi', N'UN member state', N'BI', N'BDI', 108, N'ISO 3166-2:BI', N'.bi' };
            builder.HasData(new Company() { Id = 40, N'Cabo Verde ', N'The Republic of Cabo Verde', N'UN member state', N'CV', N'CPV', 132, N'ISO 3166-2:CV', N'.cv' };
            builder.HasData(new Company() { Id = 41, N'Cambodia', N'The Kingdom of Cambodia', N'UN member state', N'KH', N'KHM', 116, N'ISO 3166-2:KH', N'.kh' };
            builder.HasData(new Company() { Id = 42, N'Cameroon', N'The Republic of Cameroon', N'UN member state', N'CM', N'CMR', 120, N'ISO 3166-2:CM', N'.cm' };
            builder.HasData(new Company() { Id = 43, N'Canada', N'Canada', N'UN member state', N'CA', N'CAN', 124, N'ISO 3166-2:CA', N'.ca' };
            builder.HasData(new Company() { Id = 46, N'Cayman Islands (the)', N'The Cayman Islands', N'United Kingdom', N'KY', N'CYM', 136, N'ISO 3166-2:KY', N'.ky' };
            builder.HasData(new Company() { Id = 47, N'Central African Republic (the)', N'The Central African Republic', N'UN member state', N'CF', N'CAF', 140, N'ISO 3166-2:CF', N'.cf' };
            builder.HasData(new Company() { Id = 48, N'Chad', N'The Republic of Chad', N'UN member state', N'TD', N'TCD', 148, N'ISO 3166-2:TD', N'.td' };
            builder.HasData(new Company() { Id = 49, N'Chile', N'The Republic of Chile', N'UN member state', N'CL', N'CHL', 152, N'ISO 3166-2:CL', N'.cl' };
            builder.HasData(new Company() { Id = 50, N'China', N'The People''s Republic of China', N'UN member state', N'CN', N'CHN', 156, N'ISO 3166-2:CN', N'.cn' };
            builder.HasData(new Company() { Id = 52, N'Christmas Island', N'The Territory of Christmas Island', N'Australia', N'CX', N'CXR', 162, N'ISO 3166-2:CX', N'.cx' };
            builder.HasData(new Company() { Id = 53, N'Cocos (Keeling) Islands (the)', N'The Territory of Cocos (Keeling) Islands', N'Australia', N'CC', N'CCK', 166, N'ISO 3166-2:CC', N'.cc' };
            builder.HasData(new Company() { Id = 54, N'Colombia', N'The Republic of Colombia', N'UN member state', N'CO', N'COL', 170, N'ISO 3166-2:CO', N'.co' };
            builder.HasData(new Company() { Id = 55, N'Comoros (the)', N'The Union of the Comoros', N'UN member state', N'KM', N'COM', 174, N'ISO 3166-2:KM', N'.km' };
            builder.HasData(new Company() { Id = 56, N'Con (the Democratic Republic of the)', N'The Democratic Republic of the Con', N'UN member state', N'CD', N'COD', 180, N'ISO 3166-2:CD', N'.cd' };
            builder.HasData(new Company() { Id = 57, N'Con (the) [g]', N'The Republic of the Con', N'UN member state', N'CG', N'COG', 178, N'ISO 3166-2:CG', N'.cg' };
            builder.HasData(new Company() { Id = 58, N'Cook Islands (the)', N'The Cook Islands', N'New Zealand', N'CK', N'COK', 184, N'ISO 3166-2:CK', N'.ck' };
            builder.HasData(new Company() { Id = 59, N'Costa Rica', N'The Republic of Costa Rica', N'UN member state', N'CR', N'CRI', 188, N'ISO 3166-2:CR', N'.cr' };
            builder.HasData(new Company() { Id = 60, N'Côte d''Ivoire [h]', N'The Republic of Côte d''Ivoire', N'UN member state', N'CI', N'CIV', 384, N'ISO 3166-2:CI', N'.ci' };
            builder.HasData(new Company() { Id = 61, N'Croatia', N'The Republic of Croatia', N'UN member state', N'HR', N'HRV', 191, N'ISO 3166-2:HR', N'.hr' };
            builder.HasData(new Company() { Id = 62, N'Cuba', N'The Republic of Cuba', N'UN member state', N'CU', N'CUB', 192, N'ISO 3166-2:CU', N'.cu' };
            builder.HasData(new Company() { Id = 63, N'Curaçao', N'The Country of Curaçao', N'Netherlands', N'CW', N'CUW', 531, N'ISO 3166-2:CW', N'.cw' };
            builder.HasData(new Company() { Id = 64, N'Cyprus', N'The Republic of Cyprus', N'UN member state', N'CY', N'CYP', 196, N'ISO 3166-2:CY', N'.cy' };
            builder.HasData(new Company() { Id = 65, N'Czechia [i]', N'The Czech Republic', N'UN member state', N'CZ', N'CZE', 203, N'ISO 3166-2:CZ', N'.cz' };
            builder.HasData(new Company() { Id = 68, N'Denmark', N'The Kingdom of Denmark', N'UN member state', N'DK', N'DNK', 208, N'ISO 3166-2:DK', N'.dk' };
            builder.HasData(new Company() { Id = 69, N'Djibouti', N'The Republic of Djibouti', N'UN member state', N'DJ', N'DJI', 262, N'ISO 3166-2:DJ', N'.dj' };
            builder.HasData(new Company() { Id = 70, N'Dominica', N'The Commonwealth of Dominica', N'UN member state', N'DM', N'DMA', 212, N'ISO 3166-2:DM', N'.dm' };
            builder.HasData(new Company() { Id = 71, N'Dominican Republic (the)', N'The Dominican Republic', N'UN member state', N'DO', N'DOM', 214, N'ISO 3166-2:DO', N'.do' };
            builder.HasData(new Company() { Id = 73, N'Ecuador', N'The Republic of Ecuador', N'UN member state', N'EC', N'ECU', 218, N'ISO 3166-2:EC', N'.ec' };
            builder.HasData(new Company() { Id = 74, N'Egypt', N'The Arab Republic of Egypt', N'UN member state', N'EG', N'EGY', 818, N'ISO 3166-2:EG', N'.eg' };
            builder.HasData(new Company() { Id = 75, N'El Salvador', N'The Republic of El Salvador', N'UN member state', N'SV', N'SLV', 222, N'ISO 3166-2:SV', N'.sv' };
            builder.HasData(new Company() { Id = 76, N'Equatorial Guinea', N'The Republic of Equatorial Guinea', N'UN member state', N'GQ', N'GNQ', 226, N'ISO 3166-2:GQ', N'.gq' };
            builder.HasData(new Company() { Id = 77, N'Eritrea', N'The State of Eritrea', N'UN member state', N'ER', N'ERI', 232, N'ISO 3166-2:ER', N'.er' };
            builder.HasData(new Company() { Id = 78, N'Estonia', N'The Republic of Estonia', N'UN member state', N'EE', N'EST', 233, N'ISO 3166-2:EE', N'.ee' };
            builder.HasData(new Company() { Id = 79, N'Eswatini ', N'The Kingdom of Eswatini', N'UN member state', N'SZ', N'SWZ', 748, N'ISO 3166-2:SZ', N'.sz' };
            builder.HasData(new Company() { Id = 80, N'Ethiopia', N'The Federal Democratic Republic of Ethiopia', N'UN member state', N'ET', N'ETH', 231, N'ISO 3166-2:ET', N'.et' };
            builder.HasData(new Company() { Id = 81, N'Falkland Islands (the) [Malvinas] [k]', N'The Falkland Islands', N'United Kingdom', N'FK', N'FLK', 238, N'ISO 3166-2:FK', N'.fk' };
            builder.HasData(new Company() { Id = 82, N'Faroe Islands (the)', N'The Faroe Islands', N'Denmark', N'FO', N'FRO', 234, N'ISO 3166-2:FO', N'.fo' };
            builder.HasData(new Company() { Id = 83, N'Fiji', N'The Republic of Fiji', N'UN member state', N'FJ', N'FJI', 242, N'ISO 3166-2:FJ', N'.fj' };
            builder.HasData(new Company() { Id = 84, N'Finland', N'The Republic of Finland', N'UN member state', N'FI', N'FIN', 246, N'ISO 3166-2:FI', N'.fi' };
            builder.HasData(new Company() { Id = 85, N'France ', N'The French Republic', N'UN member state', N'FR', N'FRA', 250, N'ISO 3166-2:FR', N'.fr' };
            builder.HasData(new Company() { Id = 86, N'French Guiana', N'Guyane', N'France', N'GF', N'GUF', 254, N'ISO 3166-2:GF', N'.gf' };
            builder.HasData(new Company() { Id = 87, N'French Polynesia', N'French Polynesia', N'France', N'PF', N'PYF', 258, N'ISO 3166-2:PF', N'.pf' };
            builder.HasData(new Company() { Id = 88, N'French Southern Territories (the) [m]', N'The French Southern and Antarctic Lands', N'France', N'TF', N'ATF', 260, N'ISO 3166-2:TF', N'.tf' };
            builder.HasData(new Company() { Id = 89, N'Gabon', N'The Gabonese Republic', N'UN member state', N'GA', N'GAB', 266, N'ISO 3166-2:GA', N'.ga' };
            builder.HasData(new Company() { Id = 90, N'Gambia (the)', N'The Republic of The Gambia', N'UN member state', N'GM', N'GMB', 270, N'ISO 3166-2:GM', N'.gm' };
            builder.HasData(new Company() { Id = 91, N'Georgia', N'Georgia', N'UN member state', N'GE', N'GEO', 268, N'ISO 3166-2:GE', N'.ge' };
            builder.HasData(new Company() { Id = 92, N'Germany', N'The Federal Republic of Germany', N'UN member state', N'DE', N'DEU', 276, N'ISO 3166-2:DE', N'.de' };
            builder.HasData(new Company() { Id = 93, N'Ghana', N'The Republic of Ghana', N'UN member state', N'GH', N'GHA', 288, N'ISO 3166-2:GH', N'.gh' };
            builder.HasData(new Company() { Id = 94, N'Gibraltar', N'Gibraltar', N'United Kingdom', N'GI', N'GIB', 292, N'ISO 3166-2:GI', N'.gi' };
            builder.HasData(new Company() { Id = 96, N'Greece', N'The Hellenic Republic', N'UN member state', N'GR', N'GRC', 300, N'ISO 3166-2:GR', N'.gr' };
            builder.HasData(new Company() { Id = 97, N'Greenland', N'Kalaallit Nunaat', N'Denmark', N'GL', N'GRL', 304, N'ISO 3166-2:GL', N'.gl' };
            builder.HasData(new Company() { Id = 98, N'Grenada', N'Grenada', N'UN member state', N'GD', N'GRD', 308, N'ISO 3166-2:GD', N'.gd' };
            builder.HasData(new Company() { Id = 99, N'Guadeloupe', N'Guadeloupe', N'France', N'GP', N'GLP', 312, N'ISO 3166-2:GP', N'.gp' };
            builder.HasData(new Company() { Id = 100, N'Guam', N'The Territory of Guam', N'United States', N'GU', N'GUM', 316, N'ISO 3166-2:GU', N'.gu' };
            builder.HasData(new Company() { Id = 101, N'Guatemala', N'The Republic of Guatemala', N'UN member state', N'GT', N'GTM', 320, N'ISO 3166-2:GT', N'.gt' };
            builder.HasData(new Company() { Id = 102, N'Guernsey', N'The Bailiwick of Guernsey', N'British Crown', N'GG', N'GGY', 831, N'ISO 3166-2:GG', N'.gg' };
            builder.HasData(new Company() { Id = 103, N'Guinea', N'The Republic of Guinea', N'UN member state', N'GN', N'GIN', 324, N'ISO 3166-2:GN', N'.gn' };
            builder.HasData(new Company() { Id = 104, N'Guinea-Bissau', N'The Republic of Guinea-Bissau', N'UN member state', N'GW', N'GNB', 624, N'ISO 3166-2:GW', N'.gw' };
            builder.HasData(new Company() { Id = 105, N'Guyana', N'The Co-operative Republic of Guyana', N'UN member state', N'GY', N'GUY', 328, N'ISO 3166-2:GY', N'.gy' };
            builder.HasData(new Company() { Id = 106, N'Haiti', N'The Republic of Haiti', N'UN member state', N'HT', N'HTI', 332, N'ISO 3166-2:HT', N'.ht' };
            builder.HasData(new Company() { Id = 107, N'Heard Island and McDonald Islands', N'The Territory of Heard Island and McDonald Islands', N'Australia', N'HM', N'HMD', 334, N'ISO 3166-2:HM', N'.hm' };
            builder.HasData(new Company() { Id = 108, N'Holy See (the) [n]', N'The Holy See', N'UN observer state', N'VA', N'VAT', 336, N'ISO 3166-2:VA', N'.va' };
            builder.HasData(new Company() { Id = 109, N'Honduras', N'The Republic of Honduras', N'UN member state', N'HN', N'HND', 340, N'ISO 3166-2:HN', N'.hn' };
            builder.HasData(new Company() { Id = 110, N'Hong Kong', N'The Hong Kong Special Administrative Region of China[10]', N'China', N'HK', N'HKG', 344, N'ISO 3166-2:HK', N'.hk' };
            builder.HasData(new Company() { Id = 111, N'Hungary', N'Hungary', N'UN member state', N'HU', N'HUN', 348, N'ISO 3166-2:HU', N'.hu' };
            builder.HasData(new Company() { Id = 112, N'Iceland', N'Iceland', N'UN member state', N'IS', N'ISL', 352, N'ISO 3166-2:IS', N'.is' };
            builder.HasData(new Company() { Id = 113, N'India', N'The Republic of India', N'UN member state', N'IN', N'IND', 356, N'ISO 3166-2:IN', N'.in' };
            builder.HasData(new Company() { Id = 114, N'Indonesia', N'The Republic of Indonesia', N'UN member state', N'ID', N'IDN', 360, N'ISO 3166-2:ID', N'.id' };
            builder.HasData(new Company() { Id = 115, N'Iran (Islamic Republic of)', N'The Islamic Republic of Iran', N'UN member state', N'IR', N'IRN', 364, N'ISO 3166-2:IR', N'.ir' };
            builder.HasData(new Company() { Id = 116, N'Iraq', N'The Republic of Iraq', N'UN member state', N'IQ', N'IRQ', 368, N'ISO 3166-2:IQ', N'.iq' };
            builder.HasData(new Company() { Id = 117, N'Ireland', N'Ireland', N'UN member state', N'IE', N'IRL', 372, N'ISO 3166-2:IE', N'.ie' };
            builder.HasData(new Company() { Id = 118, N'Isle of Man', N'The Isle of Man', N'British Crown', N'IM', N'IMN', 833, N'ISO 3166-2:IM', N'.im' };
            builder.HasData(new Company() { Id = 119, N'Israel', N'The State of Israel', N'UN member state', N'IL', N'ISR', 376, N'ISO 3166-2:IL', N'.il' };
            builder.HasData(new Company() { Id = 120, N'Italy', N'The Italian Republic', N'UN member state', N'IT', N'ITA', 380, N'ISO 3166-2:IT', N'.it' };
            builder.HasData(new Company() { Id = 122, N'Jamaica', N'Jamaica', N'UN member state', N'JM', N'JAM', 388, N'ISO 3166-2:JM', N'.jm' };
            builder.HasData(new Company() { Id = 124, N'Japan', N'Japan', N'UN member state', N'JP', N'JPN', 392, N'ISO 3166-2:JP', N'.jp' };
            builder.HasData(new Company() { Id = 125, N'Jersey', N'The Bailiwick of Jersey', N'British Crown', N'JE', N'JEY', 832, N'ISO 3166-2:JE', N'.je' };
            builder.HasData(new Company() { Id = 126, N'Jordan', N'The Hashemite Kingdom of Jordan', N'UN member state', N'JO', N'JOR', 400, N'ISO 3166-2:JO', N'.jo' };
            builder.HasData(new Company() { Id = 127, N'Kazakhstan', N'The Republic of Kazakhstan', N'UN member state', N'KZ', N'KAZ', 398, N'ISO 3166-2:KZ', N'.kz' };
            builder.HasData(new Company() { Id = 128, N'Kenya', N'The Republic of Kenya', N'UN member state', N'KE', N'KEN', 404, N'ISO 3166-2:KE', N'.ke' };
            builder.HasData(new Company() { Id = 129, N'Kiribati', N'The Republic of Kiribati', N'UN member state', N'KI', N'KIR', 296, N'ISO 3166-2:KI', N'.ki' };
            builder.HasData(new Company() { Id = 130, N'Korea (the Democratic People''s Republic of) [o]', N'The Democratic People''s Republic of Korea', N'UN member state', N'KP', N'PRK', 408, N'ISO 3166-2:KP', N'.kp' };
            builder.HasData(new Company() { Id = 131, N'Korea (the Republic of) [p]', N'The Republic of Korea', N'UN member state', N'KR', N'KOR', 410, N'ISO 3166-2:KR', N'.kr' };
            builder.HasData(new Company() { Id = 132, N'Kuwait', N'The State of Kuwait', N'UN member state', N'KW', N'KWT', 414, N'ISO 3166-2:KW', N'.kw' };
            builder.HasData(new Company() { Id = 133, N'Kyrgyzstan', N'The Kyrgyz Republic', N'UN member state', N'KG', N'KGZ', 417, N'ISO 3166-2:KG', N'.kg' };
            builder.HasData(new Company() { Id = 134, N'Lao People''s Democratic Republic (the) [q]', N'The Lao People''s Democratic Republic', N'UN member state', N'LA', N'LAO', 418, N'ISO 3166-2:LA', N'.la' };
            builder.HasData(new Company() { Id = 135, N'Latvia', N'The Republic of Latvia', N'UN member state', N'LV', N'LVA', 428, N'ISO 3166-2:LV', N'.lv' };
            builder.HasData(new Company() { Id = 136, N'Lebanon', N'The Lebanese Republic', N'UN member state', N'LB', N'LBN', 422, N'ISO 3166-2:LB', N'.lb' };
            builder.HasData(new Company() { Id = 137, N'Lesotho', N'The Kingdom of Lesotho', N'UN member state', N'LS', N'LSO', 426, N'ISO 3166-2:LS', N'.ls' };
            builder.HasData(new Company() { Id = 138, N'Liberia', N'The Republic of Liberia', N'UN member state', N'LR', N'LBR', 430, N'ISO 3166-2:LR', N'.lr' };
            builder.HasData(new Company() { Id = 139, N'Libya', N'The State of Libya', N'UN member state', N'LY', N'LBY', 434, N'ISO 3166-2:LY', N'.ly' };
            builder.HasData(new Company() { Id = 140, N'Liechtenstein', N'The Principality of Liechtenstein', N'UN member state', N'LI', N'LIE', 438, N'ISO 3166-2:LI', N'.li' };
            builder.HasData(new Company() { Id = 141, N'Lithuania', N'The Republic of Lithuania', N'UN member state', N'LT', N'LTU', 440, N'ISO 3166-2:LT', N'.lt' };
            builder.HasData(new Company() { Id = 142, N'Luxembourg', N'The Grand Duchy of Luxembourg', N'UN member state', N'LU', N'LUX', 442, N'ISO 3166-2:LU', N'.lu' };
            builder.HasData(new Company() { Id = 143, N'Macao ', N'The Macao Special Administrative Region of China[11]', N'China', N'MO', N'MAC', 446, N'ISO 3166-2:MO', N'.mo' };
            builder.HasData(new Company() { Id = 144, N'North Macedonia [s]', N'The Republic of North Macedonia[12]', N'UN member state', N'MK', N'MKD', 807, N'ISO 3166-2:MK', N'.mk' };
            builder.HasData(new Company() { Id = 145, N'Madagascar', N'The Republic of Madagascar', N'UN member state', N'MG', N'MDG', 450, N'ISO 3166-2:MG', N'.mg' };
            builder.HasData(new Company() { Id = 146, N'Malawi', N'The Republic of Malawi', N'UN member state', N'MW', N'MWI', 454, N'ISO 3166-2:MW', N'.mw' };
            builder.HasData(new Company() { Id = 147, N'Malaysia', N'Malaysia', N'UN member state', N'MY', N'MYS', 458, N'ISO 3166-2:MY', N'.my' };
            builder.HasData(new Company() { Id = 148, N'Maldives', N'The Republic of Maldives', N'UN member state', N'MV', N'MDV', 462, N'ISO 3166-2:MV', N'.mv' };
            builder.HasData(new Company() { Id = 149, N'Mali', N'The Republic of Mali', N'UN member state', N'ML', N'MLI', 466, N'ISO 3166-2:ML', N'.ml' };
            builder.HasData(new Company() { Id = 150, N'Malta', N'The Republic of Malta', N'UN member state', N'MT', N'MLT', 470, N'ISO 3166-2:MT', N'.mt' };
            builder.HasData(new Company() { Id = 151, N'Marshall Islands (the)', N'The Republic of the Marshall Islands', N'UN member state', N'MH', N'MHL', 584, N'ISO 3166-2:MH', N'.mh' };
            builder.HasData(new Company() { Id = 152, N'Martinique', N'Martinique', N'France', N'MQ', N'MTQ', 474, N'ISO 3166-2:MQ', N'.mq' };
            builder.HasData(new Company() { Id = 153, N'Mauritania', N'The Islamic Republic of Mauritania', N'UN member state', N'MR', N'MRT', 478, N'ISO 3166-2:MR', N'.mr' };
            builder.HasData(new Company() { Id = 154, N'Mauritius', N'The Republic of Mauritius', N'UN member state', N'MU', N'MUS', 480, N'ISO 3166-2:MU', N'.mu' };
            builder.HasData(new Company() { Id = 155, N'Mayotte', N'The Department of Mayotte', N'France', N'YT', N'MYT', 175, N'ISO 3166-2:YT', N'.yt' };
            builder.HasData(new Company() { Id = 156, N'Mexico', N'The United Mexican States', N'UN member state', N'MX', N'MEX', 484, N'ISO 3166-2:MX', N'.mx' };
            builder.HasData(new Company() { Id = 157, N'Micronesia (Federated States of)', N'The Federated States of Micronesia', N'UN member state', N'FM', N'FSM', 583, N'ISO 3166-2:FM', N'.fm' };
            builder.HasData(new Company() { Id = 158, N'Moldova (the Republic of)', N'The Republic of Moldova', N'UN member state', N'MD', N'MDA', 498, N'ISO 3166-2:MD', N'.md' };
            builder.HasData(new Company() { Id = 159, N'Monaco', N'The Principality of Monaco', N'UN member state', N'MC', N'MCO', 492, N'ISO 3166-2:MC', N'.mc' };
            builder.HasData(new Company() { Id = 160, N'Monlia', N'Monlia', N'UN member state', N'MN', N'MNG', 496, N'ISO 3166-2:MN', N'.mn' };
            builder.HasData(new Company() { Id = 161, N'Montenegro', N'Montenegro', N'UN member state', N'ME', N'MNE', 499, N'ISO 3166-2:ME', N'.me' };
            builder.HasData(new Company() { Id = 162, N'Montserrat', N'Montserrat', N'United Kingdom', N'MS', N'MSR', 500, N'ISO 3166-2:MS', N'.ms' };
            builder.HasData(new Company() { Id = 163, N'Morocco', N'The Kingdom of Morocco', N'UN member state', N'MA', N'MAR', 504, N'ISO 3166-2:MA', N'.ma' };
            builder.HasData(new Company() { Id = 164, N'Mozambique', N'The Republic of Mozambique', N'UN member state', N'MZ', N'MOZ', 508, N'ISO 3166-2:MZ', N'.mz' };
            builder.HasData(new Company() { Id = 165, N'Myanmar ', N'The Republic of the Union of Myanmar', N'UN member state', N'MM', N'MMR', 104, N'ISO 3166-2:MM', N'.mm' };
            builder.HasData(new Company() { Id = 166, N'Namibia', N'The Republic of Namibia', N'UN member state', N'NA', N'NAM', 516, N'ISO 3166-2:NA', N'.na' };
            builder.HasData(new Company() { Id = 167, N'Nauru', N'The Republic of Nauru', N'UN member state', N'NR', N'NRU', 520, N'ISO 3166-2:NR', N'.nr' };
            builder.HasData(new Company() { Id = 168, N'Nepal', N'The Federal Democratic Republic of Nepal', N'UN member state', N'NP', N'NPL', 524, N'ISO 3166-2:NP', N'.np' };
            builder.HasData(new Company() { Id = 169, N'Netherlands (the)', N'The Kingdom of the Netherlands', N'UN member state', N'NL', N'NLD', 528, N'ISO 3166-2:NL', N'.nl' };
            builder.HasData(new Company() { Id = 170, N'New Caledonia', N'New Caledonia', N'France', N'NC', N'NCL', 540, N'ISO 3166-2:NC', N'.nc' };
            builder.HasData(new Company() { Id = 171, N'New Zealand', N'New Zealand', N'UN member state', N'NZ', N'NZL', 554, N'ISO 3166-2:NZ', N'.nz' };
            builder.HasData(new Company() { Id = 172, N'Nicaragua', N'The Republic of Nicaragua', N'UN member state', N'NI', N'NIC', 558, N'ISO 3166-2:NI', N'.ni' };
            builder.HasData(new Company() { Id = 173, N'Niger (the)', N'The Republic of the Niger', N'UN member state', N'NE', N'NER', 562, N'ISO 3166-2:NE', N'.ne' };
            builder.HasData(new Company() { Id = 174, N'Nigeria', N'The Federal Republic of Nigeria', N'UN member state', N'NG', N'NGA', 566, N'ISO 3166-2:NG', N'.ng' };
            builder.HasData(new Company() { Id = 175, N'Niue', N'Niue', N'New Zealand', N'NU', N'NIU', 570, N'ISO 3166-2:NU', N'.nu' };
            builder.HasData(new Company() { Id = 176, N'Norfolk Island', N'The Territory of Norfolk Island', N'Australia', N'NF', N'NFK', 574, N'ISO 3166-2:NF', N'.nf' };
            builder.HasData(new Company() { Id = 178, N'Northern Mariana Islands (the)', N'The Commonwealth of the Northern Mariana Islands', N'United States', N'MP', N'MNP', 580, N'ISO 3166-2:MP', N'.mp' };
            builder.HasData(new Company() { Id = 179, N'Norway', N'The Kingdom of Norway', N'UN member state', N'NO', N'NOR', 578, N'ISO 3166-2:NO', N'.no' };
            builder.HasData(new Company() { Id = 180, N'Oman', N'The Sultanate of Oman', N'UN member state', N'OM', N'OMN', 512, N'ISO 3166-2:OM', N'.om' };
            builder.HasData(new Company() { Id = 181, N'Pakistan', N'The Islamic Republic of Pakistan', N'UN member state', N'PK', N'PAK', 586, N'ISO 3166-2:PK', N'.pk' };
            builder.HasData(new Company() { Id = 182, N'Palau', N'The Republic of Palau', N'UN member state', N'PW', N'PLW', 585, N'ISO 3166-2:PW', N'.pw' };
            builder.HasData(new Company() { Id = 183, N'Palestine, State of', N'The State of Palestine', N'UN observer state', N'PS', N'PSE', 275, N'ISO 3166-2:PS', N'.ps' };
            builder.HasData(new Company() { Id = 184, N'Panama', N'The Republic of Panamá', N'UN member state', N'PA', N'PAN', 591, N'ISO 3166-2:PA', N'.pa' };
            builder.HasData(new Company() { Id = 185, N'Papua New Guinea', N'The Independent State of Papua New Guinea', N'UN member state', N'PG', N'PNG', 598, N'ISO 3166-2:PG', N'.pg' };
            builder.HasData(new Company() { Id = 186, N'Paraguay', N'The Republic of Paraguay', N'UN member state', N'PY', N'PRY', 600, N'ISO 3166-2:PY', N'.py' };
            builder.HasData(new Company() { Id = 188, N'Peru', N'The Republic of Perú', N'UN member state', N'PE', N'PER', 604, N'ISO 3166-2:PE', N'.pe' };
            builder.HasData(new Company() { Id = 189, N'Philippines (the)', N'The Republic of the Philippines', N'UN member state', N'PH', N'PHL', 608, N'ISO 3166-2:PH', N'.ph' };
            builder.HasData(new Company() { Id = 190, N'Pitcairn [u]', N'The Pitcairn, Henderson, Ducie and Oeno Islands', N'United Kingdom', N'PN', N'PCN', 612, N'ISO 3166-2:PN', N'.pn' };
            builder.HasData(new Company() { Id = 191, N'Poland', N'The Republic of Poland', N'UN member state', N'PL', N'POL', 616, N'ISO 3166-2:PL', N'.pl' };
            builder.HasData(new Company() { Id = 192, N'Portugal', N'The Portuguese Republic', N'UN member state', N'PT', N'PRT', 620, N'ISO 3166-2:PT', N'.pt' };
            builder.HasData(new Company() { Id = 193, N'Puerto Rico', N'The Commonwealth of Puerto Rico', N'United States', N'PR', N'PRI', 630, N'ISO 3166-2:PR', N'.pr' };
            builder.HasData(new Company() { Id = 194, N'Qatar', N'The State of Qatar', N'UN member state', N'QA', N'QAT', 634, N'ISO 3166-2:QA', N'.qa' };
            builder.HasData(new Company() { Id = 198, N'Réunion', N'Réunion', N'France', N'RE', N'REU', 638, N'ISO 3166-2:RE', N'.re' };
            builder.HasData(new Company() { Id = 199, N'Romania', N'Romania', N'UN member state', N'RO', N'ROU', 642, N'ISO 3166-2:RO', N'.ro' };
            builder.HasData(new Company() { Id = 200, N'Russian Federation (the)', N'The Russian Federation', N'UN member state', N'RU', N'RUS', 643, N'ISO 3166-2:RU', N'.ru' };
            builder.HasData(new Company() { Id = 201, N'Rwanda', N'The Republic of Rwanda', N'UN member state', N'RW', N'RWA', 646, N'ISO 3166-2:RW', N'.rw' };
            builder.HasData(new Company() { Id = 204, N'Saint Barthélemy', N'The Collectivity of Saint-Barthélemy', N'France', N'BL', N'BLM', 652, N'ISO 3166-2:BL', N'.bl' };
            builder.HasData(new Company() { Id = 205, N'Saint Helena', N'Saint Helena, Ascension and Tristan da Cunha', N'United Kingdom', N'SH', N'SHN', 654, N'ISO 3166-2:SH', N'.sh' };
            builder.HasData(new Company() { Id = 208, N'Saint Kitts and Nevis', N'Saint Kitts and Nevis', N'UN member state', N'KN', N'KNA', 659, N'ISO 3166-2:KN', N'.kn' };
            builder.HasData(new Company() { Id = 209, N'Saint Lucia', N'Saint Lucia', N'UN member state', N'LC', N'LCA', 662, N'ISO 3166-2:LC', N'.lc' };
            builder.HasData(new Company() { Id = 210, N'Saint Martin (French part)', N'The Collectivity of Saint-Martin', N'France', N'MF', N'MAF', 663, N'ISO 3166-2:MF', N'.mf' };
            builder.HasData(new Company() { Id = 211, N'Saint Pierre and Miquelon', N'The Overseas Collectivity of Saint-Pierre and Miquelon', N'France', N'PM', N'SPM', 666, N'ISO 3166-2:PM', N'.pm' };
            builder.HasData(new Company() { Id = 212, N'Saint Vincent and the Grenadines', N'Saint Vincent and the Grenadines', N'UN member state', N'VC', N'VCT', 670, N'ISO 3166-2:VC', N'.vc' };
            builder.HasData(new Company() { Id = 213, N'Samoa', N'The Independent State of Samoa', N'UN member state', N'WS', N'WSM', 882, N'ISO 3166-2:WS', N'.ws' };
            builder.HasData(new Company() { Id = 214, N'San Marino', N'The Republic of San Marino', N'UN member state', N'SM', N'SMR', 674, N'ISO 3166-2:SM', N'.sm' };
            builder.HasData(new Company() { Id = 215, N'Sao Tome and Principe', N'The Democratic Republic of São Tomé and Príncipe', N'UN member state', N'ST', N'STP', 678, N'ISO 3166-2:ST', N'.st' };
            builder.HasData(new Company() { Id = 216, N'Saudi Arabia', N'The Kingdom of Saudi Arabia', N'UN member state', N'SA', N'SAU', 682, N'ISO 3166-2:SA', N'.sa' };
            builder.HasData(new Company() { Id = 217, N'Senegal', N'The Republic of Senegal', N'UN member state', N'SN', N'SEN', 686, N'ISO 3166-2:SN', N'.sn' };
            builder.HasData(new Company() { Id = 218, N'Serbia', N'The Republic of Serbia', N'UN member state', N'RS', N'SRB', 688, N'ISO 3166-2:RS', N'.rs' };
            builder.HasData(new Company() { Id = 219, N'Seychelles', N'The Republic of Seychelles', N'UN member state', N'SC', N'SYC', 690, N'ISO 3166-2:SC', N'.sc' };
            builder.HasData(new Company() { Id = 220, N'Sierra Leone', N'The Republic of Sierra Leone', N'UN member state', N'SL', N'SLE', 694, N'ISO 3166-2:SL', N'.sl' };
            builder.HasData(new Company() { Id = 221, N'Singapore', N'The Republic of Singapore', N'UN member state', N'SG', N'SGP', 702, N'ISO 3166-2:SG', N'.sg' };
            builder.HasData(new Company() { Id = 223, N'Sint Maarten (Dutch part)', N'Sint Maarten', N'Netherlands', N'SX', N'SXM', 534, N'ISO 3166-2:SX', N'.sx' };
            builder.HasData(new Company() { Id = 224, N'Slovakia', N'The Slovak Republic', N'UN member state', N'SK', N'SVK', 703, N'ISO 3166-2:SK', N'.sk' };
            builder.HasData(new Company() { Id = 225, N'Slovenia', N'The Republic of Slovenia', N'UN member state', N'SI', N'SVN', 705, N'ISO 3166-2:SI', N'.si' };
            builder.HasData(new Company() { Id = 226, N'Solomon Islands', N'The Solomon Islands', N'UN member state', N'SB', N'SLB', 90, N'ISO 3166-2:SB', N'.sb' };
            builder.HasData(new Company() { Id = 227, N'Somalia', N'The Federal Republic of Somalia', N'UN member state', N'SO', N'SOM', 706, N'ISO 3166-2:SO', N'.so' };
            builder.HasData(new Company() { Id = 228, N'South Africa', N'The Republic of South Africa', N'UN member state', N'ZA', N'ZAF', 710, N'ISO 3166-2:ZA', N'.za' };
            builder.HasData(new Company() { Id = 229, N'South Georgia and the South Sandwich Islands', N'South Georgia and the South Sandwich Islands', N'United Kingdom', N'GS', N'SGS', 239, N'ISO 3166-2:GS', N'.gs' };
            builder.HasData(new Company() { Id = 231, N'South Sudan', N'The Republic of South Sudan', N'UN member state', N'SS', N'SSD', 728, N'ISO 3166-2:SS', N'.ss' };
            builder.HasData(new Company() { Id = 232, N'Spain', N'The Kingdom of Spain', N'UN member state', N'ES', N'ESP', 724, N'ISO 3166-2:ES', N'.es' };
            builder.HasData(new Company() { Id = 233, N'Sri Lanka', N'The Democratic Socialist Republic of Sri Lanka', N'UN member state', N'LK', N'LKA', 144, N'ISO 3166-2:LK', N'.lk' };
            builder.HasData(new Company() { Id = 234, N'Sudan (the)', N'The Republic of the Sudan', N'UN member state', N'SD', N'SDN', 729, N'ISO 3166-2:SD', N'.sd' };
            builder.HasData(new Company() { Id = 235, N'Suriname', N'The Republic of Suriname', N'UN member state', N'SR', N'SUR', 740, N'ISO 3166-2:SR', N'.sr' };
            builder.HasData(new Company() { Id = 236, N'Svalbard', N'Svalbard and Jan Mayen', N'Norway', N'SJ', N'SJM', 744, N'ISO 3166-2:SJ', N'' };
            builder.HasData(new Company() { Id = 238, N'Sweden', N'The Kingdom of Sweden', N'UN member state', N'SE', N'SWE', 752, N'ISO 3166-2:SE', N'.se' };
            builder.HasData(new Company() { Id = 239, N'Switzerland', N'The Swiss Confederation', N'UN member state', N'CH', N'CHE', 756, N'ISO 3166-2:CH', N'.ch' };
            builder.HasData(new Company() { Id = 240, N'Syrian Arab Republic (the) [x]', N'The Syrian Arab Republic', N'UN member state', N'SY', N'SYR', 760, N'ISO 3166-2:SY', N'.sy' };
            builder.HasData(new Company() { Id = 241, N'Taiwan (Province of China) [y]', N'The Republic of China', N'Disputed [z]', N'TW', N'TWN', 158, N'ISO 3166-2:TW', N'.tw' };
            builder.HasData(new Company() { Id = 242, N'Tajikistan', N'The Republic of Tajikistan', N'UN member state', N'TJ', N'TJK', 762, N'ISO 3166-2:TJ', N'.tj' };
            builder.HasData(new Company() { Id = 243, N'Tanzania, the United Republic of', N'The United Republic of Tanzania', N'UN member state', N'TZ', N'TZA', 834, N'ISO 3166-2:TZ', N'.tz' };
            builder.HasData(new Company() { Id = 244, N'Thailand', N'The Kingdom of Thailand', N'UN member state', N'TH', N'THA', 764, N'ISO 3166-2:TH', N'.th' };
            builder.HasData(new Company() { Id = 245, N'Timor-Leste ', N'The Democratic Republic of Timor-Leste', N'UN member state', N'TL', N'TLS', 626, N'ISO 3166-2:TL', N'.tl' };
            builder.HasData(new Company() { Id = 246, N'To', N'The Tolese Republic', N'UN member state', N'TG', N'T', 768, N'ISO 3166-2:TG', N'.tg' };
            builder.HasData(new Company() { Id = 247, N'Tokelau', N'Tokelau', N'New Zealand', N'TK', N'TKL', 772, N'ISO 3166-2:TK', N'.tk' };
            builder.HasData(new Company() { Id = 248, N'Tonga', N'The Kingdom of Tonga', N'UN member state', N'TO', N'TON', 776, N'ISO 3166-2:TO', N'.to' };
            builder.HasData(new Company() { Id = 249, N'Trinidad and Toba', N'The Republic of Trinidad and Toba', N'UN member state', N'TT', N'TTO', 780, N'ISO 3166-2:TT', N'.tt' };
            builder.HasData(new Company() { Id = 250, N'Tunisia', N'The Republic of Tunisia', N'UN member state', N'TN', N'TUN', 788, N'ISO 3166-2:TN', N'.tn' };
            builder.HasData(new Company() { Id = 251, N'Türkiye [ab]', N'The Republic of Türkiye', N'UN member state', N'TR', N'TUR', 792, N'ISO 3166-2:TR', N'.tr' };
            builder.HasData(new Company() { Id = 252, N'Turkmenistan', N'Turkmenistan', N'UN member state', N'TM', N'TKM', 795, N'ISO 3166-2:TM', N'.tm' };
            builder.HasData(new Company() { Id = 253, N'Turks and Caicos Islands (the)', N'The Turks and Caicos Islands', N'United Kingdom', N'TC', N'TCA', 796, N'ISO 3166-2:TC', N'.tc' };
            builder.HasData(new Company() { Id = 254, N'Tuvalu', N'Tuvalu', N'UN member state', N'TV', N'TUV', 798, N'ISO 3166-2:TV', N'.tv' };
            builder.HasData(new Company() { Id = 255, N'Uganda', N'The Republic of Uganda', N'UN member state', N'UG', N'UGA', 800, N'ISO 3166-2:UG', N'.ug' };
            builder.HasData(new Company() { Id = 256, N'Ukraine', N'Ukraine', N'UN member state', N'UA', N'UKR', 804, N'ISO 3166-2:UA', N'.ua' };
            builder.HasData(new Company() { Id = 257, N'United Arab Emirates (the)', N'The United Arab Emirates', N'UN member state', N'AE', N'ARE', 784, N'ISO 3166-2:AE', N'.ae' };
            builder.HasData(new Company() { Id = 258, N'United Kingdom of Great Britain and Northern Ireland (the)', N'The United Kingdom of Great Britain and Northern Ireland', N'UN member state', N'GB', N'GBR', 826, N'ISO 3166-2:GB', N'.gb .uk ' };
            builder.HasData(new Company() { Id = 259, N'United States Minor Outlying Islands (the) [ad]', N'Baker Island, Howland Island, Jarvis Island, Johnston Atoll, Kingman Reef, Midway Atoll, Navassa Island, Palmyra Atoll, and Wake Island', N'United States', N'UM', N'UMI', 581, N'ISO 3166-2:UM', N'' };
            builder.HasData(new Company() { Id = 260, N'United States of America (the)', N'The United States of America', N'UN member state', N'US', N'USA', 840, N'ISO 3166-2:US', N'.us' };
            builder.HasData(new Company() { Id = 262, N'Uruguay', N'The Oriental Republic of Uruguay', N'UN member state', N'UY', N'URY', 858, N'ISO 3166-2:UY', N'.uy' };
            builder.HasData(new Company() { Id = 263, N'Uzbekistan', N'The Republic of Uzbekistan', N'UN member state', N'UZ', N'UZB', 860, N'ISO 3166-2:UZ', N'.uz' };
            builder.HasData(new Company() { Id = 264, N'Vanuatu', N'The Republic of Vanuatu', N'UN member state', N'VU', N'VUT', 548, N'ISO 3166-2:VU', N'.vu' };
            builder.HasData(new Company() { Id = 266, N'Venezuela (Bolivarian Republic of)', N'The Bolivarian Republic of Venezuela', N'UN member state', N'VE', N'VEN', 862, N'ISO 3166-2:VE', N'.ve' };
            builder.HasData(new Company() { Id = 267, N'Viet Nam ', N'The Socialist Republic of Viet Nam', N'UN member state', N'VN', N'VNM', 704, N'ISO 3166-2:VN', N'.vn' };
            builder.HasData(new Company() { Id = 268, N'Virgin Islands (British) [ag]', N'The Virgin Islands', N'United Kingdom', N'VG', N'VGB', 92, N'ISO 3166-2:VG', N'.vg' };
            builder.HasData(new Company() { Id = 269, N'Virgin Islands (U.S.) [ah]', N'The Virgin Islands of the United States', N'United States', N'VI', N'VIR', 850, N'ISO 3166-2:VI', N'.vi' };
            builder.HasData(new Company() { Id = 270, N'Wallis and Futuna', N'The Territory of the Wallis and Futuna Islands', N'France', N'WF', N'WLF', 876, N'ISO 3166-2:WF', N'.wf' };
            builder.HasData(new Company() { Id = 271, N'Western Sahara [ai]', N'The Sahrawi Arab Democratic Republic', N'Disputed [aj]', N'EH', N'ESH', 732, N'ISO 3166-2:EH', N'' };
            builder.HasData(new Company() { Id = 272, N'Yemen', N'The Republic of Yemen', N'UN member state', N'YE', N'YEM', 887, N'ISO 3166-2:YE', N'.ye' };
            builder.HasData(new Company() { Id = 273, N'Zambia', N'The Republic of Zambia', N'UN member state', N'ZM', N'ZMB', 894, N'ISO 3166-2:ZM', N'.zm' };
            builder.HasData(new Company() { Id = 274, N'Zimbabwe', N'The Republic of Zimbabwe', N'UN member state', N'ZW', N'ZWE', 716, N'ISO 3166-2:ZW', N'.zw' };
            builder.HasData(new Company() { Id = 275, N'Sint Eustatius', N'Bonaire, Sint Eustatius and Saba', N'Netherlands', N'BQ', N'BES', 535, N'ISO 3166-2:BQ', N'.bq .nl ' };
            builder.HasData(new Company() { Id = 280, N'Brunei Darussalam [e]', N'The Nation of Brunei, the Abode of Peace', N'UN member state', N'BN', N'BRN', 96, N'ISO 3166-2:BN', N'.bn' };
            builder.HasData(new Company() { Id = 281, N'Cabo Verde ', N'The Republic of Cabo Verde', N'UN member state', N'CV', N'CPV', 132, N'ISO 3166-2:CV', N'.cv' };
            builder.HasData(new Company() { Id = 282, N'Costa Rica', N'The Republic of Costa Rica', N'UN member state', N'CR', N'CRI', 188, N'ISO 3166-2:CR', N'.cr' };
            builder.HasData(new Company() { Id = 283, N'Curaçao', N'The Country of Curaçao', N'Netherlands', N'CW', N'CUW', 531, N'ISO 3166-2:CW', N'.cw' };
            builder.HasData(new Company() { Id = 286, N'Tristan da Cunha', N'Saint Helena, Ascension and Tristan da Cunha', N'United Kingdom', N'SH', N'SHN', 654, N'ISO 3166-2:SH', N'.sh' };
            builder.HasData(new Company() { Id = 287, N'Svalbard', N'Svalbard and Jan Mayen', N'Norway', N'SJ', N'SJM', 744, N'ISO 3166-2:SJ', N'' };
            builder.HasData(new Company() { Id = 288, N'Afghanistan', N'The Islamic Republic of Afghanistan', N'UN member state', N'AF', N'AFG', 4, N'ISO 3166-2:AF', N'.af' };
            builder.HasData(new Company() { Id = 289, N'Åland Islands', N'Åland', N'Finland', N'AX', N'ALA', 248, N'ISO 3166-2:AX', N'.ax');
        }
    }
}
