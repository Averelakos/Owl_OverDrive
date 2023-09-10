using Owl.Overdrive.Domain.Entities.Game;

namespace Owl.Overdrive.Repository.Contracts
{
    public interface IGameRepository
    {
        /// <summary>
        /// Queries the game.
        /// </summary>
        /// <returns></returns>
        IQueryable<Game> QueryGame();
        /// <summary>
        /// Inserts the specified game.
        /// </summary>
        /// <param name="company">The company.</param>
        /// <returns></returns>
        Task<Game> Insert(Game company);
        /// <summary>
        /// Searches the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        Task<List<Game>> Search(string input);
        /// <summary>
        /// Gets the list of games.
        /// </summary>
        /// <returns></returns>
        Task<List<Game>> GetList();
        /// <summary>
        /// Gets the game by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<Game?> GetCompanyById(long id);
        Task<Game?> GetById(long id);
        Task<Game> UpdateCompany(Game company);

        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollBackTransactionAsync();
        Task SaveChangesAsync();
    }
}
