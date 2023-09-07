using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Owl.Overdrive.Domain.Entities.Company;
using Owl.Overdrive.Domain.Entities.Game;
using Owl.Overdrive.Domain.Enums;

namespace Owl.Overdrive.Infrastructure.Persistence.Configurations.GameConfigurations
{
    public class AlternativeNameConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<AlternativeName>
    {
        public AlternativeNameConfiguration() : base()
        {

        }

        public void Configure(EntityTypeBuilder<AlternativeName> builder)
        {
            ApplyConfiguration(builder);
            ConfigurationBase(builder);
        }

        public static void ApplyConfiguration(EntityTypeBuilder<AlternativeName> builder)
        {
            // Table Name
            builder.ToTable("AlternativeNames");

            // Properties parameters
            builder.Property(p => p.Name).HasMaxLength(255);
            builder.Property(p => p.Type).HasConversion(c => c.ToString(), c => Enum.Parse<EAlternativeTitleType>(c));

            builder.HasOne(e => e.Game)
                .WithMany(x => x.AlternativeGameTitles)
                .HasForeignKey(e => e.GameId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(true);

        }
    }
}
