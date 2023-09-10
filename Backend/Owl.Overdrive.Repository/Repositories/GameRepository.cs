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
        public async Task<Game?> GetCompanyById(long id)
        {
            //return await GetCompany()
            //    .Include(x => x.ParentCompany)
            //    .AsNoTracking()
            //    .FirstAsync(x => x.Id == id)!;
            return new Game();
        }

        public override async Task<Game?> GetById(long id)
        {
            return await base.GetById(id);
        }

        public async Task<Game> UpdateCompany(Game game)
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
    }
}
