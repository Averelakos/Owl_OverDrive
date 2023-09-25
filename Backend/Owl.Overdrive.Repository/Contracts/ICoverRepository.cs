using Owl.Overdrive.Domain.Entities.Game;

namespace Owl.Overdrive.Repository.Contracts
{
    public interface ICoverRepository
    {
        Task<Cover> Insert(Cover companyLogo);
        Task<Cover?> GetCover(long id);
        Task<Cover?> GetById(long id);
    }
}
