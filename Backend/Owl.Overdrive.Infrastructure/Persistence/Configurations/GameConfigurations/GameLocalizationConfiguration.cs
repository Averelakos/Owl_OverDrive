using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Owl.Overdrive.Domain.Entities.Game;

namespace Owl.Overdrive.Infrastructure.Persistence.Configurations.GameConfigurations
{
    public class GameLocalizationConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<GameLocalization>
    {
        public GameLocalizationConfiguration() : base()
        {

        }

        public void Configure(EntityTypeBuilder<GameLocalization> builder)
        {
            ApplyConfiguration(builder);
            ConfigurationBase(builder);
        }

        public static void ApplyConfiguration(EntityTypeBuilder<GameLocalization> builder)
        {
            // Table Name
            builder.ToTable("GameLocalizations");

            // Properties parameters
            builder.Property(p => p.LocalizedTitle).HasMaxLength(255);

            builder.HasOne(e => e.Region)
                .WithMany()
                .HasForeignKey(e => e.RegionId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e => e.Game)
              .WithMany()
              .HasForeignKey(e => e.GameId)
              .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
