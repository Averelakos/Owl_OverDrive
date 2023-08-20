using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Owl.Overdrive.Domain.Entities.Game;

namespace Owl.Overdrive.Infrastructure.Persistence.Configurations.GameConfigurations
{
    public class InvolvedCompanyPlatformConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<InvolvedCompanyPlatform>
    {
        public InvolvedCompanyPlatformConfiguration() : base()
        {

        }

        public void Configure(EntityTypeBuilder<InvolvedCompanyPlatform> builder)
        {
            ApplyConfiguration(builder);
            ConfigurationBase(builder);
        }

        public static void ApplyConfiguration(EntityTypeBuilder<InvolvedCompanyPlatform> builder)
        {
            // Table Name
            builder.ToTable("InvolvedCompaniesPlatforms");

            // Properties parameters
            builder.HasOne(e => e.InvolvedCompany)
                .WithMany()
                .HasForeignKey(e => e.InvolvedCompany)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Platform)
                .WithMany()
                .HasForeignKey(e =>e.Platform)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
