using Owl.Overdrive.Domain.Entities.Game;

namespace Owl.Overdrive.Repository.Contracts
{
    public interface IGameLocalizationRepository
    {
        /// <summary>
        /// Inserts the range.
        /// </summary>
        /// <param name="gameLocalizations">The game localizations.</param>
        /// <returns></returns>
        Task<List<Localization>> InsertRange(List<Localization> gameLocalizations);
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollBackTransactionAsync();
        Task SaveChangesAsync();
    }
}
