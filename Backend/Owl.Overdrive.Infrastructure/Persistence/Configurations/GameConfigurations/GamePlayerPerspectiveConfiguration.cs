using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Owl.Overdrive.Domain.Entities.Game;

namespace Owl.Overdrive.Infrastructure.Persistence.Configurations.GameConfigurations
{
    public class GamePlayerPerspectiveConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<GamePlayerPerspective>
    {
        public GamePlayerPerspectiveConfiguration() : base()
        {

        }

        public void Configure(EntityTypeBuilder<GamePlayerPerspective> builder)
        {
            ApplyConfiguration(builder);
            ConfigurationBase(builder);
        }

        public static void ApplyConfiguration(EntityTypeBuilder<GamePlayerPerspective> builder)
        {
            // Table Name
            builder.ToTable("GamePlayerPerspectives");

            // Properties parameters
            builder.HasOne(e => e.Game)
                .WithMany(e => e.GamePlayerPerspectives)
                .HasForeignKey(e => e.GameId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.PlayerPerspective)
                .WithMany()
                .HasForeignKey(e => e.PlayerPerspectiveId)
                .OnDelete(DeleteBehavior.Restrict);

        }

    }
}
