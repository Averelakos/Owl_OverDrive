using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Owl.Overdrive.Domain.Entities.Game;
using Owl.Overdrive.Domain.Enums;

namespace Owl.Overdrive.Infrastructure.Persistence.Configurations.GameConfigurations
{
    public class WebsitesConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<Websites>
    {
        public WebsitesConfiguration() : base()
        {

        }

        public void Configure(EntityTypeBuilder<Websites> builder)
        {
            ApplyConfiguration(builder);
            ConfigurationBase(builder);
        }

        public static void ApplyConfiguration(EntityTypeBuilder<Websites> builder)
        {
            // Table Name
            builder.ToTable("Websites");

            // Properties parameters
            builder.HasOne(e => e.Game)
                .WithOne()
                .HasForeignKey<Websites>(e => e.GameId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(p => p.Url).HasColumnType("varchar(255)");

            builder.Property(p => p.Category)
                .HasConversion(c => c.ToString(), c => Enum.Parse<EWebsiteCategory>(c));
        }
    }
}
