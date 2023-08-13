using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Owl.Overdrive.Domain.Entities.Company;
using Owl.Overdrive.Domain.Entities.Game;
using Owl.Overdrive.Domain.Enums;

namespace Owl.Overdrive.Infrastructure.Persistence.Configurations.GameConfigurations
{
    public class GameEditionConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<GameEdition>
    {
        public GameEditionConfiguration() : base()
        {

        }

        public void Configure(EntityTypeBuilder<GameEdition> builder)
        {
            ApplyConfiguration(builder);
            ConfigurationBase(builder);
        }

        public static void ApplyConfiguration(EntityTypeBuilder<GameEdition> builder)
        {
            // Table Name
            builder.ToTable("GameEditions");

            // Properties parameters
            builder.HasOne(e => e.EditionGame)
                .WithOne()
                .HasForeignKey<GameEdition>(e => e.EditionGameId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.ParentGame)
                .WithMany()
                .HasForeignKey(e => e.ParentGameId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
