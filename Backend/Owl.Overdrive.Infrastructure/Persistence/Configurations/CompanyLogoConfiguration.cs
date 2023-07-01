using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Owl.Overdrive.Domain.Entities;
using Owl.Overdrive.Domain.Entities.Company;

namespace Owl.Overdrive.Infrastructure.Persistence.Configurations
{
    public class CompanyLogoConfiguration :BaseEntityConfiguration, IEntityTypeConfiguration<CompanyLogo>
    {
        public CompanyLogoConfiguration() : base()
        {
            
        }

        public void Configure(EntityTypeBuilder<CompanyLogo> builder)
        {
            ApplyConfiguration(builder);
            ConfigurationBase(builder);
        }

        public static void ApplyConfiguration(EntityTypeBuilder<CompanyLogo> builder)
        {
            // Table Name
            builder.ToTable("CompanyLogos");

            // Properties parameters
            builder.HasOne(x => x.Company)
                .WithOne()
                .HasForeignKey<CompanyLogo>(x => x.CompanyId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }

        private static void Seed(EntityTypeBuilder<User> builder)
        {
            //builder.HasData(new User()
            //{
            //    Id = -1,
            //    Username = "Admin",
            //    Email = "Admin@owlo.gr"
            //});
        }
    }
}
