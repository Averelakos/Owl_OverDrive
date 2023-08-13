using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Owl.Overdrive.Domain.Entities.Company;
using Owl.Overdrive.Domain.Entities.Game;
using Owl.Overdrive.Domain.Enums;

namespace Owl.Overdrive.Infrastructure.Persistence.Configurations.GameConfigurations
{
    public class AlternativeGameTitleConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<AlternativeGameTitle>
    {
        public AlternativeGameTitleConfiguration() : base()
        {

        }

        public void Configure(EntityTypeBuilder<AlternativeGameTitle> builder)
        {
            ApplyConfiguration(builder);
            ConfigurationBase(builder);
        }

        public static void ApplyConfiguration(EntityTypeBuilder<AlternativeGameTitle> builder)
        {
            // Table Name
            builder.ToTable("AlternativeGameTitles");

            // Properties parameters
            builder.Property(p => p.AlternativeName).HasMaxLength(255);
            builder.Property(p => p.AlternativeTitleType).HasConversion(c => c.ToString(), c => Enum.Parse<EAlternativeTitleType>(c));

            builder.HasOne(e => e.Game)
                .WithMany()
                .HasForeignKey(e => e.GameId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
