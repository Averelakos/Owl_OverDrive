using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Owl.Overdrive.Domain.Entities.Company;
using Owl.Overdrive.Domain.Entities.Game;
using Owl.Overdrive.Domain.Enums;

namespace Owl.Overdrive.Infrastructure.Persistence.Configurations.GameConfigurations
{
    public class GameConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<Game>
    {
        public GameConfiguration() : base()
        {

        }

        public void Configure(EntityTypeBuilder<Game> builder)
        {
            ApplyConfiguration(builder);
            ConfigurationBase(builder);
        }

        public static void ApplyConfiguration(EntityTypeBuilder<Game> builder)
        {
            // Table Name
            builder.ToTable("Games");

            // Properties parameters
            builder.Property(p => p.Name).HasMaxLength(255);
            builder.Property(p => p.Description).HasColumnType("varchar(MAX)");
            builder.Property(p => p.Story).HasColumnType("varchar(MAX)");
            builder.Property(p => p.UpdateGameType).HasConversion(c => c.ToString(), c => Enum.Parse<EGameType>(c));
            builder.Property(p => p.GameStatus).HasConversion(c => c.ToString(), c => Enum.Parse<EGameStatus>(c));

            builder.HasOne(e => e.UpdatedGame)
                .WithOne()
                .HasForeignKey<Game>(e => e.UpdatedGameId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(e => e.Cover)
                .WithOne()
                .HasForeignKey<Game>(e => e.CoverId)
                .OnDelete(DeleteBehavior.SetNull);

        }
    }
}
