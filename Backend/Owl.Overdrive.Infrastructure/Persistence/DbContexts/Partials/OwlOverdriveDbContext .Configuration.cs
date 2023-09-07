using Microsoft.EntityFrameworkCore;
using Owl.Overdrive.Infrastructure.Persistence.Configurations;
using Owl.Overdrive.Infrastructure.Persistence.Configurations.CompanyConfigurations;
using Owl.Overdrive.Infrastructure.Persistence.Configurations.GameConfigurations;

namespace Owl.Overdrive.Infrastructure.Persistence.DbContexts
{
    public sealed partial class OwlOverdriveDbContext: DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ModelCreating(modelBuilder);
        }

        public void ModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyStatusConfiguration());
            modelBuilder.ApplyConfiguration(new CountryCodeConfiguration());
            modelBuilder.ApplyConfiguration(new ImagesDraftConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyLogoConfiguration());
            modelBuilder.ApplyConfiguration(new PlatformConfiguration());
            modelBuilder.ApplyConfiguration(new RegionConfiguration());
            modelBuilder.ApplyConfiguration(new LanguageConfiguration());

            // Game
            modelBuilder.ApplyConfiguration(new GameConfiguration());
            //modelBuilder.ApplyConfiguration(new GameEditionConfiguration());
            modelBuilder.ApplyConfiguration(new AlternativeNameConfiguration());
            modelBuilder.ApplyConfiguration(new LocalizationConfiguration());
            modelBuilder.ApplyConfiguration(new ReleaseDateConfiguration());
            modelBuilder.ApplyConfiguration(new WebsitesConfiguration());
            modelBuilder.ApplyConfiguration(new InvovlvedCompanyConfiguration());
            modelBuilder.ApplyConfiguration(new InvolvedCompanyPlatformConfiguration());
            modelBuilder.ApplyConfiguration(new LanguageSupportTypeConfiguration());
            modelBuilder.ApplyConfiguration(new LanguageSupportConfiguration());
            modelBuilder.ApplyConfiguration(new GameModeConfiguration());
            modelBuilder.ApplyConfiguration(new GameGameModeConfiguration());
            modelBuilder.ApplyConfiguration(new PlayerPerspectiveConfiguration());
            modelBuilder.ApplyConfiguration(new GamePlayerPerspectiveConfiguration());
            modelBuilder.ApplyConfiguration(new MultiplayerModeConfiguration());
            modelBuilder.ApplyConfiguration(new ThemeConfiguration());
            modelBuilder.ApplyConfiguration(new GenreConfiguration());
            modelBuilder.ApplyConfiguration(new GameThemeConfiguration());
            modelBuilder.ApplyConfiguration(new GameGenreConfiguration());
            modelBuilder.ApplyConfiguration(new CoverConfiguration());
            //modelBuilder.ApplyConfiguration(new ScreenshotConfiguration());

        }
    }
}
