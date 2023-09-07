using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Owl.Overdrive.Domain.Entities.Game;

namespace Owl.Overdrive.Infrastructure.Persistence.Configurations.GameConfigurations
{
    public class GameGenreConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<GameGenre>
    {
        public GameGenreConfiguration() : base()
        {

        }

        public void Configure(EntityTypeBuilder<GameGenre> builder)
        {
            ApplyConfiguration(builder);
            ConfigurationBase(builder);
        }

        public static void ApplyConfiguration(EntityTypeBuilder<GameGenre> builder)
        {
            // Table Name
            builder.ToTable("GameGenres");

            // Properties parameters
            builder.HasOne(e => e.Game)
                .WithMany(e => e.GameGenres)
                .HasForeignKey(e => e.GameId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Genre)
                .WithMany()
                .HasForeignKey(e => e.GenreId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
