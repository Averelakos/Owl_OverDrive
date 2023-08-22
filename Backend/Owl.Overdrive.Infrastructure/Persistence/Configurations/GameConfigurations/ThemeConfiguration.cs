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

    public class GenreConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<Genre>
    {
        public GenreConfiguration() : base()
        {

        }

        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            ApplyConfiguration(builder);
            ConfigurationBase(builder);
        }

        public static void ApplyConfiguration(EntityTypeBuilder<Genre> builder)
        {
            // Table Name
            builder.ToTable("Genres");

            // Properties parameters
            builder.Property(p => p.Name).HasColumnType("varchar(MAX)");

            // Seed data 
            Seed(builder);
        }

        private static void Seed(EntityTypeBuilder<Genre> builder)
        {
            builder.HasData(new Genre()
            {
                Id = 1,
                Name = "4X(explore, expand, exploit and exterminate)"
            });

            builder.HasData(new Genre()
            {
                Id = 2,
                Name = "Action"
            });

            builder.HasData(new Genre()
            {
                Id = 3,
                Name = "Bussiness"
            });

            builder.HasData(new Genre()
            {
                Id = 4,
                Name = "Comedy"
            });

            builder.HasData(new Genre()
            {
                Id = 5,
                Name = "Drama"
            });

            builder.HasData(new Genre()
            {
                Id = 6,
                Name = "Educational"
            });

            builder.HasData(new Genre()
            {
                Id = 7,
                Name = "Erotic"
            });

            builder.HasData(new Genre()
            {
                Id = 8,
                Name = "Fantasy"
            });

            builder.HasData(new Genre()
            {
                Id = 9,
                Name = "Historical"
            });

            builder.HasData(new Genre()
            {
                Id = 10,
                Name = "Horror"
            });

            builder.HasData(new Genre()
            {
                Id = 11,
                Name = "Kids"
            });

            builder.HasData(new Genre()
            {
                Id = 12,
                Name = "Mystery"
            });

            builder.HasData(new Genre()
            {
                Id = 13,
                Name = "Non-fiction"
            });

            builder.HasData(new Genre()
            {
                Id = 14,
                Name = "Open world"
            });

            builder.HasData(new Genre()
            {
                Id = 15,
                Name = "Party"
            });

            builder.HasData(new Genre()
            {
                Id = 16,
                Name = "Romance"
            });

            builder.HasData(new Genre()
            {
                Id = 17,
                Name = "Sandbox"
            });

            builder.HasData(new Genre()
            {
                Id = 18,
                Name = "Science fiction"
            });

            builder.HasData(new Genre()
            {
                Id = 19,
                Name = "Stealth"
            });

            builder.HasData(new Genre()
            {
                Id = 20,
                Name = "Survival"
            });

            builder.HasData(new Genre()
            {
                Id = 21,
                Name = "Thriller"
            });

            builder.HasData(new Genre()
            {
                Id = 22,
                Name = "Warfare"
            });

        }
    }

    public class GameThemeConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<GameTheme>
    {
        public GameThemeConfiguration() : base()
        {

        }

        public void Configure(EntityTypeBuilder<GameTheme> builder)
        {
            ApplyConfiguration(builder);
            ConfigurationBase(builder);
        }

        public static void ApplyConfiguration(EntityTypeBuilder<GameTheme> builder)
        {
            // Table Name
            builder.ToTable("GameThemes");

            // Properties parameters
            builder.HasOne(e => e.Game)
                .WithMany()
                .HasForeignKey(e => e.GameId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Theme)
                .WithMany()
                .HasForeignKey(e => e.ThemeId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }

    public class GameGenreConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<GameGenre>
    {
        public GameGenreConfiguration() : base()
        {

        }

        public void Configure(EntityTypeBuilder<GameGenre> builder)
        {
            ApplyConfiguration(builder);
            ConfigurationBase(builder);
        }

        public static void ApplyConfiguration(EntityTypeBuilder<GameGenre> builder)
        {
            // Table Name
            builder.ToTable("GameGenres");

            // Properties parameters
            builder.HasOne(e => e.Game)
                .WithMany()
                .HasForeignKey(e => e.GameId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Genre)
                .WithMany()
                .HasForeignKey(e => e.GenreId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
