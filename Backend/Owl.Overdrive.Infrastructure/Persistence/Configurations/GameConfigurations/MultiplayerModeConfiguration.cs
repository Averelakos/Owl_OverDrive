using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Owl.Overdrive.Domain.Entities.Game;

namespace Owl.Overdrive.Infrastructure.Persistence.Configurations.GameConfigurations
{
    public class MultiplayerModeConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<MultiplayerMode>
    {
        public MultiplayerModeConfiguration() : base()
        {

        }

        public void Configure(EntityTypeBuilder<MultiplayerMode> builder)
        {
            ApplyConfiguration(builder);
            ConfigurationBase(builder);
        }

        public static void ApplyConfiguration(EntityTypeBuilder<MultiplayerMode> builder)
        {
            // Table Name
            builder.ToTable("MultiplayerModes");

            // Properties parameters
            builder.HasOne(e => e.Game)
                .WithMany(e => e.MultiplayerModes)
                .HasForeignKey(e => e.GameId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Platform)
                .WithMany()
                .HasForeignKey(e => e.PlatformId)
                .OnDelete(DeleteBehavior.Restrict);

        }

    }
}
