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
                Name = "Adventure"
            });

            builder.HasData(new Theme()
            {
                Id = 2,
                Name = "Arcade"
            });

            builder.HasData(new Theme()
            {
                Id = 3,
                Name = "Card & Board Game"
            });

            builder.HasData(new Theme()
            {
                Id = 4,
                Name = "Fighting"
            });

            builder.HasData(new Theme()
            {
                Id = 5,
                Name = "Hack and slash/ Beat 'em up"
            });

            builder.HasData(new Theme()
            {
                Id = 6,
                Name = "Indie"
            });

            builder.HasData(new Theme()
            {
                Id = 7,
                Name = "Music"
            });

            builder.HasData(new Theme()
            {
                Id = 8,
                Name = "Pinball"
            });

            builder.HasData(new Theme()
            {
                Id = 9,
                Name = "Platform"
            });

            builder.HasData(new Theme()
            {
                Id = 10,
                Name = "Point-and-click"
            });

            builder.HasData(new Theme()
            {
                Id = 11,
                Name = "Puzzle"
            });

            builder.HasData(new Theme()
            {
                Id = 12,
                Name = "Quiz/Trivia"
            });

            builder.HasData(new Theme()
            {
                Id = 13,
                Name = "Racing"
            });

            builder.HasData(new Theme()
            {
                Id = 14,
                Name = "Real Time Strategy(RTS)"
            });

            builder.HasData(new Theme()
            {
                Id = 15,
                Name = "Shooter"
            });

            builder.HasData(new Theme()
            {
                Id = 16,
                Name = "Role-playening(RPG)"
            });

            builder.HasData(new Theme()
            {
                Id = 17,
                Name = "Simulator"
            });

            builder.HasData(new Theme()
            {
                Id = 18,
                Name = "Sport"
            });

            builder.HasData(new Theme()
            {
                Id = 19,
                Name = "Strategy"
            });

            builder.HasData(new Theme()
            {
                Id = 20,
                Name = "Tactical"
            });

            builder.HasData(new Theme()
            {
                Id = 21,
                Name = "Turn-based-strategy(TBS)"
            });

            builder.HasData(new Theme()
            {
                Id = 22,
                Name = "Visual Novel"
            });

        }
    }
}
