using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Owl.Overdrive.Domain.Entities.Game;

namespace Owl.Overdrive.Infrastructure.Persistence.Configurations.GameConfigurations
{
    public class ThemeConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<Theme>
    {
        public ThemeConfiguration() : base()
        {

        }

        public void Configure(EntityTypeBuilder<Theme> builder)
        {
            ApplyConfiguration(builder);
            ConfigurationBase(builder);
        }

        public static void ApplyConfiguration(EntityTypeBuilder<Theme> builder)
        {
            // Table Name
            builder.ToTable("Themes");

            // Properties parameters
            builder.Property(p => p.Name).HasColumnType("varchar(MAX)");

            // Seed data 
            Seed(builder);
        }

        private static void Seed(EntityTypeBuilder<Theme> builder)
        {
            builder.HasData(new Theme()
            {
                Id = 1,
                Name = "4X(explore, expand, exploit and exterminate)"
            });

            builder.HasData(new Theme()
            {
                Id = 2,
                Name = "Action"
            });

            builder.HasData(new Theme()
            {
                Id = 3,
                Name = "Bussiness"
            });

            builder.HasData(new Theme()
            {
                Id = 4,
                Name = "Comedy"
            });

            builder.HasData(new Theme()
            {
                Id = 5,
                Name = "Drama"
            });

            builder.HasData(new Theme()
            {
                Id = 6,
                Name = "Educational"
            });

            builder.HasData(new Theme()
            {
                Id = 7,
                Name = "Erotic"
            });

            builder.HasData(new Theme()
            {
                Id = 8,
                Name = "Fantasy"
            });

            builder.HasData(new Theme()
            {
                Id = 9,
                Name = "Historical"
            });

            builder.HasData(new Theme()
            {
                Id = 10,
                Name = "Horror"
            });

            builder.HasData(new Theme()
            {
                Id = 11,
                Name = "Kids"
            });

            builder.HasData(new Theme()
            {
                Id = 12,
                Name = "Mystery"
            });

            builder.HasData(new Theme()
            {
                Id = 13,
                Name = "Non-fiction"
            });

            builder.HasData(new Theme()
            {
                Id = 14,
                Name = "Open world"
            });

            builder.HasData(new Theme()
            {
                Id = 15,
                Name = "Party"
            });

            builder.HasData(new Theme()
            {
                Id = 16,
                Name = "Romance"
            });

            builder.HasData(new Theme()
            {
                Id = 17,
                Name = "Sandbox"
            });

            builder.HasData(new Theme()
            {
                Id = 18,
                Name = "Science fiction"
            });

            builder.HasData(new Theme()
            {
                Id = 19,
                Name = "Stealth"
            });

            builder.HasData(new Theme()
            {
                Id = 20,
                Name = "Survival"
            });

            builder.HasData(new Theme()
            {
                Id = 21,
                Name = "Thriller"
            });

            builder.HasData(new Theme()
            {
                Id = 22,
                Name = "Warfare"
            });

        }
       
    }
}
