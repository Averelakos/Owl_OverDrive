using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Owl.Overdrive.Domain.Entities;
using Owl.Overdrive.Domain.Entities.Game;

namespace Owl.Overdrive.Infrastructure.Persistence.Configurations.GameConfigurations
{
    public class LanguageSupportTypeConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<LanguageSupportType>
    {
        public LanguageSupportTypeConfiguration() : base()
        {

        }

        public void Configure(EntityTypeBuilder<LanguageSupportType> builder)
        {
            ApplyConfiguration(builder);
            ConfigurationBase(builder);
        }

        public static void ApplyConfiguration(EntityTypeBuilder<LanguageSupportType> builder)
        {
            // Table Name
            builder.ToTable("LanguageSupportTypes");

            // Properties parameters
            builder.Property(p => p.Name).HasColumnType("varchar(MAX)");

            // Seed Data
            Seed(builder);
        }

        private static void Seed(EntityTypeBuilder<LanguageSupportType> builder)
        {
            builder.HasData(new LanguageSupportType()
            {
                Id = 1,
                Name = "Audio",
            });

            builder.HasData(new LanguageSupportType()
            {
                Id = 2,
                Name = "Subtitles",
            });

            builder.HasData(new LanguageSupportType()
            {
                Id = 3,
                Name = "Interface",
            });

        }
    }
}
