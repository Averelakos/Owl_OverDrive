using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Owl.Overdrive.Domain.Entities.Game;
using Owl.Overdrive.Domain.Enums;

namespace Owl.Overdrive.Infrastructure.Persistence.Configurations.GameConfigurations
{
    public class ReleaseDateConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<ReleaseDate>
    {
        public ReleaseDateConfiguration() : base()
        {

        }

        public void Configure(EntityTypeBuilder<ReleaseDate> builder)
        {
            ApplyConfiguration(builder);
            ConfigurationBase(builder);
        }

        public static void ApplyConfiguration(EntityTypeBuilder<ReleaseDate> builder)
        {
            // Table Name
            builder.ToTable("ReleaseDates");

            // Properties parameters
            builder.Property(p => p.Date).HasColumnType("datetime2(7)");

            builder.Property(p => p.Status)
                .HasConversion(c => c.ToString(), c => Enum.Parse<EGameStatus>(c));

            builder.HasOne(e => e.Region)
                .WithMany()
                .HasForeignKey(e => e.RegionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Game)
                .WithMany(e => e.ReleaseDates)
                .HasForeignKey(e => e.GameId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Platform)
              .WithMany()
              .HasForeignKey(e => e.PlatformId)
              .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
