using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Owl.Overdrive.Domain.Entities.Game;

namespace Owl.Overdrive.Infrastructure.Persistence.Configurations.GameConfigurations
{
    public class LanguageSupportConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<LanguageSupport>
    {
        public LanguageSupportConfiguration() : base()
        {

        }

        public void Configure(EntityTypeBuilder<LanguageSupport> builder)
        {
            ApplyConfiguration(builder);
            ConfigurationBase(builder);
        }

        public static void ApplyConfiguration(EntityTypeBuilder<LanguageSupport> builder)
        {
            // Table Name
            builder.ToTable("LanguageSupports");

            // Properties parameters
            builder.HasOne(e => e.Game)
                .WithMany(e => e.LanguageSupports)
                .HasForeignKey(e => e.GameId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e => e.Language)
              .WithMany()
              .HasForeignKey(e => e.LanguageId)
              .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e => e.LanguageSupportType)
              .WithMany()
              .HasForeignKey(e => e.LanguageSupportTypeId)
              .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
