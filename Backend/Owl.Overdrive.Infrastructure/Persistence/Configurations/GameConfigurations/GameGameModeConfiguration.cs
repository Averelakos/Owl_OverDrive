using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Owl.Overdrive.Domain.Entities.Game;

namespace Owl.Overdrive.Infrastructure.Persistence.Configurations.GameConfigurations
{
    public class GameGameModeConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<GameGameMode>
    {
        public GameGameModeConfiguration() : base()
        {

        }

        public void Configure(EntityTypeBuilder<GameGameMode> builder)
        {
            ApplyConfiguration(builder);
            ConfigurationBase(builder);
        }

        public static void ApplyConfiguration(EntityTypeBuilder<GameGameMode> builder)
        {
            // Table Name
            builder.ToTable("GamesGameModes");

            // Properties parameters
            builder.HasOne(e => e.Game)
                .WithMany()
                .HasForeignKey(e => e.GameId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.GameMode)
                .WithMany()
                .HasForeignKey(e => e.GameModeId)
                .OnDelete(DeleteBehavior.Restrict);

        }

    }
}
