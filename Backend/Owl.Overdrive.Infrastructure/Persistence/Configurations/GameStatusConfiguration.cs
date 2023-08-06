using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Owl.Overdrive.Domain.Entities.Game;

namespace Owl.Overdrive.Infrastructure.Persistence.Configurations
{
    public class GameStatusConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<GameStatus>
    {
        public GameStatusConfiguration() : base()
        {

        }

        public void Configure(EntityTypeBuilder<GameStatus> builder)
        {
            ApplyConfiguration(builder);
            ConfigurationBase(builder);
        }

        public static void ApplyConfiguration(EntityTypeBuilder<GameStatus> builder)
        {
            // Table Name
            builder.ToTable("GameStatuses");

            // Properties parameters
            builder.Property(p => p.Name).HasColumnType("varchar(MAX)");
            builder.Property(p => p.Description).HasColumnType("varchar(MAx)");

            Seed(builder);
        }

        private static void Seed(EntityTypeBuilder<GameStatus> builder)
        {
            builder.HasData(new GameStatus()
            {
                Id = 1,
                Name = "Alpha",
            });

            builder.HasData(new GameStatus()
            {
                Id = 2,
                Name = "Beta",
            });

            builder.HasData(new GameStatus()
            {
                Id = 3,
                Name = "Cancelled",
            });

            builder.HasData(new GameStatus()
            {
                Id = 4,
                Name = "Early Access",
            });

            builder.HasData(new GameStatus()
            {
                Id = 5,
                Name = "Full Release",
            });

            builder.HasData(new GameStatus()
            {
                Id = 6,
                Name = "Offline",
            });

        }

    }
}

