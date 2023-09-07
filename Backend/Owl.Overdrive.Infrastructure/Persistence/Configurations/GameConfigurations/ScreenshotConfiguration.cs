using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Owl.Overdrive.Domain.Entities.Game;

namespace Owl.Overdrive.Infrastructure.Persistence.Configurations.GameConfigurations
{
    public class ScreenshotConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<Screenshot>
    {
        public void Configure(EntityTypeBuilder<Screenshot> builder)
        {
            ApplyConfiguration(builder);
            ConfigurationBase(builder);
        }

        public static void ApplyConfiguration(EntityTypeBuilder<Screenshot> builder)
        {
            // Table Name
            builder.ToTable("Screenshots");

            // Properties parameters
            builder.HasOne(x => x.Game)
                .WithMany()
                .HasForeignKey(x => x.GameId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
