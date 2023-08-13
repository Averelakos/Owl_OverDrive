using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Owl.Overdrive.Domain.Entities.Company;

namespace Owl.Overdrive.Infrastructure.Persistence.Configurations.CompanyConfigurations
{
    public class CompanyConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<Company>
    {
        public CompanyConfiguration() : base()
        {

        }

        public void Configure(EntityTypeBuilder<Company> builder)
        {
            ApplyConfiguration(builder);
            ConfigurationBase(builder);
        }

        public static void ApplyConfiguration(EntityTypeBuilder<Company> builder)
        {
            // Table Name
            builder.ToTable("Companies");

            // Properties parameters
            builder.Property(p => p.Name).HasMaxLength(255);
            builder.Property(p => p.Description).HasColumnType("varchar(MAX)");//.HasMaxLength(255);
            builder.Property(p => p.FoundedIn).HasColumnType("datetime2(7)");
            builder.Property(p => p.ChangedDate).HasColumnType("datetime2(7)");
            builder.Property(p => p.OfficialWebsite).HasMaxLength(255);
            builder.Property(p => p.Twitter).HasMaxLength(255);
            builder.HasOne(e => e.ParentCompany)
                .WithMany()
                .HasForeignKey(e => e.ParentCompanyId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(e => e.Country)
                .WithMany()
                .HasForeignKey(e => e.CountryId)
                .OnDelete(DeleteBehavior.SetNull);
            builder.HasOne(e => e.Status)
                .WithMany()
                .HasForeignKey(e => e.StatusId)
                .OnDelete(DeleteBehavior.SetNull);
            builder.HasOne(e => e.CompanyLogo)
                .WithOne()
                .HasForeignKey<Company>(e => e.CompanyLogoId)
                .OnDelete(DeleteBehavior.SetNull);

        }
    }
}
