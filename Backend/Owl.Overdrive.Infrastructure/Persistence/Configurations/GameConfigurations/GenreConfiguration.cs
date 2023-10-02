using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Owl.Overdrive.Domain.Entities.Game;

namespace Owl.Overdrive.Infrastructure.Persistence.Configurations.GameConfigurations
{
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
                Name = "Adventure"
            });

            builder.HasData(new Genre()
            {
                Id = 2,
                Name = "Arcade"
            });

            builder.HasData(new Genre()
            {
                Id = 3,
                Name = "Card & Board Game"
            });

            builder.HasData(new Genre()
            {
                Id = 4,
                Name = "Fighting"
            });

            builder.HasData(new Genre()
            {
                Id = 5,
                Name = "Hack and slash/ Beat 'em up"
            });

            builder.HasData(new Genre()
            {
                Id = 6,
                Name = "Indie"
            });

            builder.HasData(new Genre()
            {
                Id = 7,
                Name = "Music"
            });

            builder.HasData(new Genre()
            {
                Id = 8,
                Name = "Pinball"
            });

            builder.HasData(new Genre()
            {
                Id = 9,
                Name = "Platform"
            });

            builder.HasData(new Genre()
            {
                Id = 10,
                Name = "Point-and-click"
            });

            builder.HasData(new Genre()
            {
                Id = 11,
                Name = "Puzzle"
            });

            builder.HasData(new Genre()
            {
                Id = 12,
                Name = "Quiz/Trivia"
            });

            builder.HasData(new Genre()
            {
                Id = 13,
                Name = "Racing"
            });

            builder.HasData(new Genre()
            {
                Id = 14,
                Name = "Real Time Strategy(RTS)"
            });

            builder.HasData(new Genre()
            {
                Id = 15,
                Name = "Shooter"
            });

            builder.HasData(new Genre()
            {
                Id = 16,
                Name = "Role-playening(RPG)"
            });

            builder.HasData(new Genre()
            {
                Id = 17,
                Name = "Simulator"
            });

            builder.HasData(new Genre()
            {
                Id = 18,
                Name = "Sport"
            });

            builder.HasData(new Genre()
            {
                Id = 19,
                Name = "Strategy"
            });

            builder.HasData(new Genre()
            {
                Id = 20,
                Name = "Tactical"
            });

            builder.HasData(new Genre()
            {
                Id = 21,
                Name = "Turn-based-strategy(TBS)"
            });

            builder.HasData(new Genre()
            {
                Id = 22,
                Name = "Visual Novel"
            });

        }
    }
}
