using Owl.Overdrive.Domain.Entities.Game;
using Owl.Overdrive.Infrastructure.Persistence.DbContexts;
using Owl.Overdrive.Repository.Contracts;

namespace Owl.Overdrive.Repository.Repositories
{
    public class GameLocalizationRepository : BaseRepository<Localization>, IGameLocalizationRepository
    {
        public GameLocalizationRepository(OwlOverdriveDbContext dbContext) : base(dbContext)
        {
        }

        private IQueryable<Localization> GetGameLocalization()
        {
            return _DbSet;
        }
        /// <summary>
        /// Inserts the range.
        /// </summary>
        /// <param name="alternativeGameTitles">The alternative game titles.</param>
        /// <returns></returns>
        public async Task<List<Localization>> InsertRange(List<Localization> gameLocalizations)
        {
            return await base.InsertRange(gameLocalizations);
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
    }
}
