using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Owl.Overdrive.Domain.Entities.Game;

namespace Owl.Overdrive.Infrastructure.Persistence.Configurations.GameConfigurations
{
    public class LocalizationConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<Localization>
    {
        public LocalizationConfiguration() : base()
        {

        }

        public void Configure(EntityTypeBuilder<Localization> builder)
        {
            ApplyConfiguration(builder);
            ConfigurationBase(builder);
        }

        public static void ApplyConfiguration(EntityTypeBuilder<Localization> builder)
        {
            // Table Name
            builder.ToTable("Localizations");

            // Properties parameters
            builder.Property(p => p.LocalizedTitle).HasMaxLength(255);

            builder.HasOne(e => e.Region)
                .WithMany()
                .HasForeignKey(e => e.RegionId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e => e.Game)
              .WithMany(e => e.Localizations)
              .HasForeignKey(e => e.GameId)
              .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
