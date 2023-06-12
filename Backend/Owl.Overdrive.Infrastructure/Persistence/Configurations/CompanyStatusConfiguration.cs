using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Owl.Overdrive.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Owl.Overdrive.Infrastructure.Persistence.Configurations
{
    public class CompanyStatusConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<CompanyStatus>
    {
        public CompanyStatusConfiguration():base()
        {
            
        }

        public void Configure(EntityTypeBuilder<CompanyStatus> builder)
        {
            ApplyConfiguration(builder);
            ConfigurationBase(builder);
        }

        public static void ApplyConfiguration(EntityTypeBuilder<CompanyStatus> builder)
        {
            // Table Name
            builder.ToTable("CompaniesStatus");

            // Properties parameters
            builder.Property(p => p.Name).HasMaxLength(255);
            builder.Property(p => p.Description).HasMaxLength(255);

            Seed(builder);
        }

        private static void Seed(EntityTypeBuilder<CompanyStatus> builder)
        {
            builder.HasData(new CompanyStatus()
            {
                Id = 1,
                Name = "Active",
                Description = "The company exists.",
                Created = DateTime.Now,
                CreatedById = -1
            });
            builder.HasData(new CompanyStatus()
            {
                Id = 2,
                Name = "Defuct",
                Description = "No longer existing or functioning.",
                Created = DateTime.Now,
                CreatedById = -1
            });
            builder.HasData(new CompanyStatus()
            {
                Id = 3,
                Name = "Merged",
                Description = "Independent companies combine to form a new, singular legal entity.",
                Created = DateTime.Now,
                CreatedById = -1
            });
            builder.HasData(new CompanyStatus()
            {
                Id = 4,
                Name = "Renamed",
                Description = "The process of changing the corporate image of an organisation.",
                Created = DateTime.Now,
                CreatedById = -1
            });
        }
    }
}
