using Owl.Overdrive.Domain.Entities;
using Owl.Overdrive.Domain.Entities.Company;

namespace Owl.Overdrive.Repository.Contracts
{
    public interface ICompanyLogoRepository
    {
        Task<CompanyLogo> Insert(CompanyLogo companyLogo);
        Task<CompanyLogo?> GetCompanyLogo(long id);
        Task<CompanyLogo?> GetById(long id);
    }
}
