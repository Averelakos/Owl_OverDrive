using Microsoft.EntityFrameworkCore;
using Owl.Overdrive.Domain.Entities;
using Owl.Overdrive.Domain.Entities.Auth;
using Owl.Overdrive.Domain.Entities.Company;
using Owl.Overdrive.Domain.Entities.Game;

namespace Owl.Overdrive.Infrastructure.Persistence.DbContexts
{
    public sealed partial class OwlOverdriveDbContext: DbContext
    {
        #region Auth
        public DbSet<User> Users => Set<User>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<UserRole> UserRoles => Set<UserRole>();
        public DbSet<RolePermission> RolePermissions => Set<RolePermission>();
        #endregion Auth

        #region Company
        public DbSet<Company> Companies => Set<Company>();
        public DbSet<CompanyStatus> CompanyStatuses => Set<CompanyStatus>();
        public DbSet<ImageDraft> ImageDrafts => Set<ImageDraft>();
        public DbSet<CompanyLogo> CompanyLogo => Set<CompanyLogo>();
        #endregion Company

        #region General
        public DbSet<CountryCode> CountryCodes => Set<CountryCode>();
        public DbSet<Platform> Platforms => Set<Platform>();
        public DbSet<Region> Regions => Set<Region>();
        public DbSet<Language> Languages => Set<Language>();
        #endregion General

        #region Game
        public DbSet<Game> Games => Set<Game>();
        //public DbSet<GameEdition> GameEditions => Set<GameEdition>();
        public DbSet<AlternativeName> AlternativeTitles => Set<AlternativeName>();
        public DbSet<Localization> Localization => Set<Localization>();
        public DbSet<ReleaseDate> ReleaseDate => Set<ReleaseDate>();
        public DbSet<Website> Websites => Set<Website>();
        public DbSet<InvolvedCompany> InvolvedCompanies => Set<InvolvedCompany>();
        public DbSet<InvolvedCompanyPlatform> InvolvedCompanyPlatforms => Set<InvolvedCompanyPlatform>();
        public DbSet<LanguageSupportType> LanguageSupportTypes => Set<LanguageSupportType>();
        public DbSet<LanguageSupport> LanguageSupport => Set<LanguageSupport>();
        public DbSet<GameMode> GameModes => Set<GameMode>();
        public DbSet<GameGameMode> GameGameModes => Set<GameGameMode>();
        public DbSet<PlayerPerspective> PlayerPerspectives => Set<PlayerPerspective>();
        public DbSet<GamePlayerPerspective> GamePlayerPerspectives => Set<GamePlayerPerspective>();
        public DbSet<MultiplayerMode> MultiplayerModes => Set<MultiplayerMode>();
        public DbSet<Theme> Theme => Set<Theme>();
        public DbSet<Genre> Genre => Set<Genre>();
        public DbSet<GameTheme> GameThemes => Set<GameTheme>();
        public DbSet<GameGenre> GameGenres => Set<GameGenre>();
        public DbSet<Cover> Covers => Set<Cover>();
        //public DbSet<Screenshot> Screenshots => Set<Screenshot>();
        #endregion Game
    }
}
