using Owl.Overdrive.Domain.Entities;
using Owl.Overdrive.Domain.Entities.Game;

namespace Owl.Overdrive.Repository.Contracts
{
    public interface IGameStatusRepository
    {
        /// <summary>
        /// Gets regions.
        /// </summary>
        /// <returns></returns>
        IQueryable<GameStatus> GetGameStatuses();
    }
}
