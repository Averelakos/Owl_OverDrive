using Microsoft.EntityFrameworkCore;
using Owl.Overdrive.Domain.Contracts;
using Owl.Overdrive.Infrastructure.Persistence.DbContexts;
using Owl.Overdrive.Repository.Contracts;

namespace Owl.Overdrive.Repository.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, IBaseEntity, new()
    {
        protected readonly OwlOverdriveDbContext _dbContext;
        protected readonly DbSet<TEntity> _DbSet;
        protected BaseRepository(OwlOverdriveDbContext dbContext)
        {
            _dbContext = dbContext;
            _DbSet = dbContext.Set<TEntity>();
        }

        /// <summary>
        /// Get all data from a specific database item.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async virtual Task<IList<TEntity>> GetAll()
        {
            try
            {
                return await _DbSet.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        /// <summary>
        /// Get a specific database item
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async virtual Task<TEntity?> GetById(long id)
        {
            try
            {
                return await _DbSet.SingleOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        /// <summary>
        /// Insert a specific database item.
        /// </summary>
        /// <param name="dbitem"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public async virtual Task<TEntity> Insert(TEntity dbitem, bool saveChanges = true)
        {
            if (dbitem is null)
            {
                throw new ArgumentNullException(nameof(dbitem));
            }

            try
            {
                await _DbSet.AddAsync(dbitem);
                if (saveChanges)
                    await SaveChangesAsync();

                return dbitem;
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        /// <summary>
        /// Inserts the specified database items
        /// </summary>
        /// <param name="dbItems"></param>
        /// <param name="saveChanges"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public async virtual Task<List<TEntity>> InsertRange(List<TEntity> dbItems, bool saveChanges = true)
        {
            if (dbItems is null || dbItems.Count == 0)
            {
                throw new ArgumentNullException("No entities to save in database");
            }

            try
            {
                var results = new List<TEntity>();
                foreach (var item in dbItems)
                {
                    results.Add( await Insert(item, false));
                }

                await SaveChangesAsync();
                return results;
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        /// <summary>
        /// Update database item.
        /// </summary>
        /// <param name="dbitem"></param>
        /// <param name="saveChanges"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async virtual Task<TEntity> Update(TEntity dbitem, bool saveChanges = true)
        {
            if (dbitem is null)
            {
                throw new ArgumentNullException(nameof(dbitem));
            }

            var entry = _dbContext.Entry(dbitem);
            if (entry.State != EntityState.Unchanged)
            {

                await SaveChangesAsync();
            }

            return dbitem;
        }

        /// <summary>
        /// Delete specified database item.
        /// </summary>
        /// <param name="dbitem"></param>
        /// <returns></returns>
        public async virtual Task<int> Delete(TEntity dbitem)
        {
            var entry = _dbContext.Entry(dbitem);
            _dbContext.Remove(dbitem);
            return await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Save changes
        /// </summary>
        public virtual async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task BeginTransactionAsync()
        {
            await _dbContext.Database.BeginTransactionAsync();
        }

        public virtual async Task CommitTransactionAsync()
        {
            await _dbContext.Database.CommitTransactionAsync();
        }

        public virtual async Task RollBackTransactionAsync()
        {
            await _dbContext.Database.RollbackTransactionAsync();
        }

    }
}
