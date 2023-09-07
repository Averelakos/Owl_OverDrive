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
}
