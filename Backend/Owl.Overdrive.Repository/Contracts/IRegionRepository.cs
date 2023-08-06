using Owl.Overdrive.Domain.Entities;

namespace Owl.Overdrive.Repository.Contracts
{
    public interface IRegionRepository
    {
        /// <summary>
        /// Gets regions.
        /// </summary>
        /// <returns></returns>
        IQueryable<Region> GetRegions();
    }
}
