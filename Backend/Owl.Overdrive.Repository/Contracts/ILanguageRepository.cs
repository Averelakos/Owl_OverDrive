using Owl.Overdrive.Domain.Entities;
using Owl.Overdrive.Domain.Entities.Company;

namespace Owl.Overdrive.Repository.Contracts
{
    public interface ILanguageRepository
    {
        Task<List<Language>> GetAllLanguages();
        IQueryable<Language> GetAllNotTracking();
    }
}
