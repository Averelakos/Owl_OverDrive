using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Owl.Overdrive.Repository.Contracts
{
    public interface IBaseRepository<TEntity> where TEntity: class
    {
        /// <summary>
        /// Get all data from a specific database item.
        /// </summary>
        /// <returns></returns>
        Task<IList<TEntity>> GetAll();
        /// <summary>
        /// Get a specific database item
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity?> GetById(long id);
        /// <summary>
        /// Insert a specific database item.
        /// </summary>
        /// <param name="dbitem"></param>
        /// <param name="saveChanges"></param>
        /// <returns></returns>
        Task<TEntity> Insert(TEntity dbitem, bool saveChanges = true);
        /// <summary>
        /// Inserts the specified database items
        /// </summary>
        /// <param name="dbItems"></param>
        /// <param name="saveChanges"></param>
        /// <returns></returns>
        Task<List<TEntity>> InsertRange(List<TEntity> dbItems, bool saveChanges = true);
        /// <summary>
        /// Update database item.
        /// </summary>
        /// <param name="dbitem"></param>
        /// <param name="saveChanges"></param>
        /// <returns></returns>
        Task<TEntity> Update(TEntity dbitem, bool saveChanges = true);
        /// <summary>
        /// Delete specified database item.
        /// </summary>
        /// <param name="dbitem"></param>
        /// <returns></returns>
        Task<int> Delete(TEntity dbitem);
        /// <summary>
        /// Save changes
        /// </summary>
        Task SaveChangesAsync();
    }
}
