using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Owl.Overdrive.Domain.Entities.Game;

namespace Owl.Overdrive.Infrastructure.Persistence.Configurations.GameConfigurations
{
    public class PlayerPerspectiveConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<PlayerPerspective>
    {
        public PlayerPerspectiveConfiguration() : base()
        {

        }

        public void Configure(EntityTypeBuilder<PlayerPerspective> builder)
        {
            ApplyConfiguration(builder);
            ConfigurationBase(builder);
        }

        public static void ApplyConfiguration(EntityTypeBuilder<PlayerPerspective> builder)
        {
            // Table Name
            builder.ToTable("PlayerPerspectives");

            // Properties parameters
            builder.Property(p => p.Name).HasColumnType("varchar(MAX)");

            // Seed data 
            Seed(builder);
        }

        private static void Seed(EntityTypeBuilder<PlayerPerspective> builder)
        {
            builder.HasData(new PlayerPerspective()
            {
                Id = 1,
                Name = "Auditory"
            });

            builder.HasData(new PlayerPerspective()
            {
                Id = 2,
                Name = "Bird view / Isometric"
            });

            builder.HasData(new PlayerPerspective()
            {
                Id = 3,
                Name = "First person"
            });

            builder.HasData(new PlayerPerspective()
            {
                Id = 4,
                Name = "Side view"
            });

            builder.HasData(new PlayerPerspective()
            {
                Id = 5,
                Name = "Text"
            });

            builder.HasData(new PlayerPerspective()
            {
                Id = 6,
                Name = "Third person"
            });

            builder.HasData(new PlayerPerspective()
            {
                Id = 7,
                Name = "Virtual Reality"
            });

        }
    }
}
