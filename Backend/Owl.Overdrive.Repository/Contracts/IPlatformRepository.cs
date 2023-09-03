using Owl.Overdrive.Domain.Entities;
using Owl.Overdrive.Domain.Entities.Company;

namespace Owl.Overdrive.Repository.Contracts
{
    public interface IPlatformRepository
    {
        Task<List<Platform>> GetAllPlatforms();
        Task<Platform?> GetPlatformById(long id);
    }
}
