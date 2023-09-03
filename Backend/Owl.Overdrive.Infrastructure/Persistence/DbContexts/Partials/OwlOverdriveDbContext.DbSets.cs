using Microsoft.EntityFrameworkCore;
using Owl.Overdrive.Domain.Entities;
using Owl.Overdrive.Domain.Entities.Company;
using Owl.Overdrive.Domain.Entities.Game;

namespace Owl.Overdrive.Infrastructure.Persistence.DbContexts
{
    public sealed partial class OwlOverdriveDbContext: DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Company> Companies => Set<Company>();
        public DbSet<CompanyStatus> CompanyStatuses => Set<CompanyStatus>();
        public DbSet<CountryCode> CountryCodes => Set<CountryCode>();
        public DbSet<ImageDraft> ImageDrafts => Set<ImageDraft>();
        public DbSet<CompanyLogo> CompanyLogo => Set<CompanyLogo>();
        public DbSet<Platform> Platforms => Set<Platform>();
        public DbSet<Region> Regions => Set<Region>();
        //public DbSet<GameStatus> GameStatuses => Set<GameStatus>();
        public DbSet<Language> Languages => Set<Language>();

        // Game
        public DbSet<Game> Games => Set<Game>();
        public DbSet<GameEdition> GameEditions => Set<GameEdition>();
        public DbSet<AlternativeName> AlternativeGameTitles => Set<AlternativeName>();
        public DbSet<Localization> Localization => Set<Localization>();
        public DbSet<ReleaseDate> ReleaseDate => Set<ReleaseDate>();
        public DbSet<Website> Websites => Set<Website>();
        public DbSet<InvolvedCompany> InvolvedCompanies => Set<InvolvedCompany>();
        public DbSet<InvolvedCompanyPlatform> InvolvedCompanyPlatforms => Set<InvolvedCompanyPlatform>();
        public DbSet<LanguageSupport> LanguageSupport => Set<LanguageSupport>();
        public DbSet<LanguageSupportType> LanguageSupportTypes => Set<LanguageSupportType>();
        public DbSet<GameMode> GameModes => Set<GameMode>();
        public DbSet<GameGameMode> GameGameModes => Set<GameGameMode>();
        public DbSet<GamePlayerPerspective> GamePlayers => Set<GamePlayerPerspective>();
        public DbSet<PlayerPerspective> PlayerPlayers => Set<PlayerPerspective>();
        public DbSet<MultiplayerMode> MultiplayerModes => Set<MultiplayerMode>();
        public DbSet<Theme> Theme => Set<Theme>();
        public DbSet<Genre> Genre => Set<Genre>();
        public DbSet<GameTheme> GameThemes => Set<GameTheme>();
        public DbSet<GameGenre> GameGenres => Set<GameGenre>();
    }
}
