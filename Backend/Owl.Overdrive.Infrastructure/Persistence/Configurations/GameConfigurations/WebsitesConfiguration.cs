using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Owl.Overdrive.Domain.Entities.Game;
using Owl.Overdrive.Domain.Enums;

namespace Owl.Overdrive.Infrastructure.Persistence.Configurations.GameConfigurations
{
    public class WebsitesConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<Website>
    {
        public WebsitesConfiguration() : base()
        {

        }

        public void Configure(EntityTypeBuilder<Website> builder)
        {
            ApplyConfiguration(builder);
            ConfigurationBase(builder);
        }

        public static void ApplyConfiguration(EntityTypeBuilder<Website> builder)
        {
            // Table Name
            builder.ToTable("Websites");

            // Properties parameters
            builder.HasOne(e => e.Game)
                .WithMany(e => e.Websites)
                .HasForeignKey(e => e.GameId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(p => p.Url).HasColumnType("varchar(255)");

            builder.Property(p => p.Category)
                .HasConversion(c => c.ToString(), c => Enum.Parse<EWebsiteCategory>(c));
        }
    }
}
