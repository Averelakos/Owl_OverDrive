using Owl.Overdrive.Domain.Entities.Game;

namespace Owl.Overdrive.Repository.Contracts
{
    public interface IScreenshotRepository
    {
        Task<Screenshot> Insert(Screenshot companyLogo);
        Task<Screenshot?> GetCompanyLogo(long id);
        Task<Screenshot?> GetById(long id);
    }
}
