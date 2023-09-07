using Owl.Overdrive.Domain.Entities.Game;

namespace Owl.Overdrive.Repository.Contracts
{
    public interface ICoverRepository
    {
        Task<Cover> Insert(Cover companyLogo);
        Task<Cover?> GetCompanyLogo(long id);
        Task<Cover?> GetById(long id);
    }
}
