using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Owl.Overdrive.Domain.Entities.Game;

namespace Owl.Overdrive.Infrastructure.Persistence.Configurations.GameConfigurations
{
    public class GameThemeConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<GameTheme>
    {
        public GameThemeConfiguration() : base()
        {

        }

        public void Configure(EntityTypeBuilder<GameTheme> builder)
        {
            ApplyConfiguration(builder);
            ConfigurationBase(builder);
        }

        public static void ApplyConfiguration(EntityTypeBuilder<GameTheme> builder)
        {
            // Table Name
            builder.ToTable("GameThemes");

            // Properties parameters
            builder.HasOne(e => e.Game)
                .WithMany(e => e.GameThemes)
                .HasForeignKey(e => e.GameId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Theme)
                .WithMany()
                .HasForeignKey(e => e.ThemeId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
