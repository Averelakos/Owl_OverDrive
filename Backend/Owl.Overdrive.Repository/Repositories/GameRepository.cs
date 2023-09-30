using Microsoft.EntityFrameworkCore;
using Owl.Overdrive.Domain.Entities.Company;
using Owl.Overdrive.Domain.Entities.Game;
using Owl.Overdrive.Infrastructure.Persistence.DbContexts;
using Owl.Overdrive.Repository.Contracts;

namespace Owl.Overdrive.Repository.Repositories
{
    public class GameRepository : BaseRepository<Game>, IGameRepository
    {
        public GameRepository(OwlOverdriveDbContext dbContext) : base(dbContext)
        {
        }

        public IQueryable<Game> QueryGame()
        {
            return _DbSet;
        }

        /// <summary>
        /// Inserts the specified company.
        /// </summary>
        /// <param name="company">The company.</param>
        /// <returns></returns>
        public async Task<Game> Insert(Game company)
        {
            var result =  await base.Insert(company);
            return result;
        }

        /// <summary>
        /// Searches the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public async Task<List<Game>> Search(string input)
        {
            return await _DbSet
                .Where(x => x.Name.ToLower().Contains(input.ToLower()))
                .AsNoTracking()
                .ToListAsync();
        }

        /// <summary>
        /// Gets the list of companies.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Game>> GetList()
        {
            var result = await base.GetAll();
            return result.ToList();
        }

        /// <summary>
        /// Gets the company information by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<Game?> GetGameByIdNoTacking(long id)
        {
            return await QueryGame()
                .Include(x =>x.ReleaseDates)
                .ThenInclude(x =>x.Platform)
                .Include(x => x.InvolvedCompanies)
                .ThenInclude(x =>x.Company)
                .Include(x => x.GameThemes)
                .ThenInclude(x => x.Theme)
                .Include(x => x.GameGenres)
                .ThenInclude(x => x.Genre)
                .Include(x => x.GameGameModes)
                .ThenInclude(x => x.GameMode)
                .Include(x => x.GamePlayerPerspectives)
                .ThenInclude(x => x.PlayerPerspective)
                .Include(x => x.MultiplayerModes)
                .ThenInclude(x => x.Platform)
                .Include(x => x.AlternativeGameTitles)
                .Include(x =>x.Localizations)
                .ThenInclude(x => x.Region)
                .Include(x => x.Websites)
                //.Include(x => x.LanguageSupports)
                //.ThenInclude(x => x.LanguageSupportType)
                
                .AsNoTracking()
                .FirstAsync(x => x.Id == id)!;
        }

        public async Task<Game?> GetGameById(long id)
        {
            return await base.GetById(id);
        }

        public async Task<Game> UpdateGame(Game game)
        {
            return await base.Update(game);
        }

        public override async Task SaveChangesAsync()
        {
            await base.SaveChangesAsync();
        }

        public override async Task BeginTransactionAsync()
        {
            await _dbContext.Database.BeginTransactionAsync();
        }

        public override async Task CommitTransactionAsync()
        {
            await _dbContext.Database.CommitTransactionAsync();
        }

        public override async Task RollBackTransactionAsync()
        {
            await _dbContext.Database.RollbackTransactionAsync();
        }

        public async Task RemoveRangeAltTitles(List<AlternativeName> dbItems)
        {
            if (dbItems is null || dbItems.Count == 0)
            {
                throw new ArgumentNullException("No entities to save in database");
            }

            try
            {
                _dbContext.AlternativeTitles.RemoveRange(dbItems);

                await SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public async Task RemoveRangeLocalizations(List<Localization> dbItems)
        {
            if (dbItems is null || dbItems.Count == 0)
            {
                throw new ArgumentNullException("No entities to save in database");
            }

            try
            {
                _dbContext.Localization.RemoveRange(dbItems);

                await SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public async Task RemoveRangeReleaseDates(List<ReleaseDate> dbItems)
        {
            if (dbItems is null || dbItems.Count == 0)
            {
                throw new ArgumentNullException("No entities to save in database");
            }

            try
            {
                _dbContext.ReleaseDate.RemoveRange(dbItems);

                await SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public async Task RemoveRangeMultiplayerModes(List<MultiplayerMode> dbItems)
        {
            if (dbItems is null || dbItems.Count == 0)
            {
                throw new ArgumentNullException("No entities to save in database");
            }

            try
            {
                _dbContext.MultiplayerModes.RemoveRange(dbItems);

                await SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public async Task RemoveRangeGameThemes(List<GameTheme> dbItems)
        {
            if (dbItems is null || dbItems.Count == 0)
            {
                throw new ArgumentNullException("No entities to save in database");
            }

            try
            {
                _dbContext.GameThemes.RemoveRange(dbItems);

                await SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public async Task RemoveRangeGameGenres(List<GameGenre> dbItems)
        {
            if (dbItems is null || dbItems.Count == 0)
            {
                throw new ArgumentNullException("No entities to save in database");
            }

            try
            {
                _dbContext.GameGenres.RemoveRange(dbItems);

                await SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public async Task RemoveRangeGameModes(List<GameGameMode> dbItems)
        {
            if (dbItems is null || dbItems.Count == 0)
            {
                throw new ArgumentNullException("No entities to save in database");
            }

            try
            {
                _dbContext.GameGameModes.RemoveRange(dbItems);

                await SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public async Task RemoveRangeGamePerspectives(List<GamePlayerPerspective> dbItems)
        {
            if (dbItems is null || dbItems.Count == 0)
            {
                throw new ArgumentNullException("No entities to save in database");
            }

            try
            {
                _dbContext.GamePlayerPerspectives.RemoveRange(dbItems);

                await SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public async Task RemoveRangeWebsites(List<Website> dbItems)
        {
            if (dbItems is null || dbItems.Count == 0)
            {
                throw new ArgumentNullException("No entities to save in database");
            }

            try
            {
                _dbContext.Websites.RemoveRange(dbItems);

                await SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public async Task RemoveRangeInvolvedCompanies(List<InvolvedCompany> dbItems)
        {
            if (dbItems is null || dbItems.Count == 0)
            {
                throw new ArgumentNullException("No entities to save in database");
            }

            try
            {
                foreach (InvolvedCompany dbItem in dbItems)
                {
                    if(dbItem.GameInvolvedCompanyPlatforms.Count > 0) 
                        await RemoveRangeInvolvedCompaniesPlatforms(dbItem.GameInvolvedCompanyPlatforms);
                }

                _dbContext.InvolvedCompanies.RemoveRange(dbItems);

                await SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public async Task RemoveRangeInvolvedCompaniesPlatforms(List<InvolvedCompanyPlatform> dbItems)
        {
            if (dbItems is null || dbItems.Count == 0)
            {
                throw new ArgumentNullException("No entities to save in database");
            }

            try
            {
                _dbContext.InvolvedCompanyPlatforms.RemoveRange(dbItems);

                await SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public async Task RemoveRangeSupportedLanguagess(List<LanguageSupport> dbItems)
        {
            if (dbItems is null || dbItems.Count == 0)
            {
                throw new ArgumentNullException("No entities to save in database");
            }

            try
            {
                _dbContext.LanguageSupport.RemoveRange(dbItems);

                await SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }
    }
}
