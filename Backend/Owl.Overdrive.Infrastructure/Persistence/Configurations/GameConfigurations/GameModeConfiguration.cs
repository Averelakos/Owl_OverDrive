using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Owl.Overdrive.Domain.Entities.Game;

namespace Owl.Overdrive.Infrastructure.Persistence.Configurations.GameConfigurations
{
    public class GameModeConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<GameMode>
    {
        public GameModeConfiguration() : base()
        {

        }

        public void Configure(EntityTypeBuilder<GameMode> builder)
        {
            ApplyConfiguration(builder);
            ConfigurationBase(builder);
        }

        public static void ApplyConfiguration(EntityTypeBuilder<GameMode> builder)
        {
            // Table Name
            builder.ToTable("GameModes");

            // Properties parameters
            builder.Property(p => p.Name).HasColumnType("varchar(MAX)");

            // Seed data 
            Seed(builder);
        }

        private static void Seed(EntityTypeBuilder<GameMode> builder)
        {
            builder.HasData(new GameMode()
            {
                Id = 1,
                Name = "Battle Royale"
            });

            builder.HasData(new GameMode()
            {
                Id = 2,
                Name = "Co-operative"
            });

            builder.HasData(new GameMode()
            {
                Id = 3,
                Name = "Massively Multiplayer Online(MMO)"
            });

            builder.HasData(new GameMode()
            {
                Id = 4,
                Name = "Multiplayer"
            });

            builder.HasData(new GameMode()
            {
                Id = 5,
                Name = "Single player"
            });

            builder.HasData(new GameMode()
            {
                Id = 6,
                Name = "Split screen"
            });

        } 
    }
}
