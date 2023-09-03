using Owl.Overdrive.Domain.Entities.Game;

namespace Owl.Overdrive.Repository.Contracts
{
    public interface IAlternativeGameTitleRepository
    {
        /// <summary>
        /// Inserts the range.
        /// </summary>
        /// <param name="alternativeGameTitles">The alternative game titles.</param>
        /// <returns></returns>
        Task<List<AlternativeName>> InsertRange(List<AlternativeName> alternativeGameTitles);
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollBackTransactionAsync();
        Task SaveChangesAsync();
    }
}
