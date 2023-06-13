using Owl.Overdrive.Domain.Entities;

namespace Owl.Overdrive.Repository.Contracts
{
    public interface ICompanyStatusRepository
    {
        /// <summary>
        /// Gets the companies status.
        /// </summary>
        /// <returns></returns>
        IQueryable<CompanyStatus> GetCompaniesStatus();
    }
}
