using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Owl.Overdrive.Domain.Entities.Game;

namespace Owl.Overdrive.Infrastructure.Persistence.Configurations.GameConfigurations
{
    public class InvovlvedCompanyConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<InvolvedCompany>
    {
        public InvovlvedCompanyConfiguration() : base()
        {

        }

        public void Configure(EntityTypeBuilder<InvolvedCompany> builder)
        {
            ApplyConfiguration(builder);
            ConfigurationBase(builder);
        }

        public static void ApplyConfiguration(EntityTypeBuilder<InvolvedCompany> builder)
        {
            // Table Name
            builder.ToTable("InvolvedCompanys");

            // Properties parameters
            builder.HasOne(e => e.Game)
                .WithMany()
                .HasForeignKey(e => e.GameId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Company)
                .WithMany()
                .HasForeignKey(e =>e.CompanyId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
