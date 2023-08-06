using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Owl.Overdrive.Domain.Entities;


namespace Owl.Overdrive.Infrastructure.Persistence.Configurations
{
    public class RegionConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<Region>
    {
        public RegionConfiguration() : base()
        {

        }

        public void Configure(EntityTypeBuilder<Region> builder)
        {
            ApplyConfiguration(builder);
            ConfigurationBase(builder);
        }

        public static void ApplyConfiguration(EntityTypeBuilder<Region> builder)
        {
            // Table Name
            builder.ToTable("Regions");

            // Properties parameters
            builder.Property(p => p.Name).HasColumnType("varchar(MAX)");
            builder.Property(p => p.RegionCode).HasColumnType("varchar(4)");

            Seed(builder);
        }

        private static void Seed(EntityTypeBuilder<Region> builder)
        {
            builder.HasData(new Region()
            {
                Id = 1,
                Name = "Worldwide",
                RegionCode = "WW"
            });

            builder.HasData(new Region()
            {
                Id = 2,
                Name = "Europe",
                RegionCode = "EU"
            });

            builder.HasData(new Region()
            {
                Id = 3,
                Name = "North America",
                RegionCode = "NA"
            });

            builder.HasData(new Region()
            {
                Id = 4,
                Name = "Australia",
                RegionCode = "AU"
            });

            builder.HasData(new Region()
            {
                Id = 5,
                Name = "New Zealand",
                RegionCode = "NZ"
            });

            builder.HasData(new Region()
            {
                Id = 6,
                Name = "Japan",
                RegionCode = "JP"
            });

            builder.HasData(new Region()
            {
                Id = 7,
                Name = "China",
                RegionCode = "CH"
            });

            builder.HasData(new Region()
            {
                Id = 8,
                Name = "Asia",
                RegionCode = "AS"
            });

            builder.HasData(new Region()
            {
                Id = 9,
                Name = "Korea",
                RegionCode = "KR"
            });

            builder.HasData(new Region()
            {
                Id = 10,
                Name = "Brazil",
                RegionCode = "BR"
            });

        }

    }
}

