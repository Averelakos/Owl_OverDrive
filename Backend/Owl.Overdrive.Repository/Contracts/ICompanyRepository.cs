using Owl.Overdrive.Domain.Entities.Company;

namespace Owl.Overdrive.Repository.Contracts
{
    public interface ICompanyRepository
    {
        /// <summary>
        /// Inserts the specified company.
        /// </summary>
        /// <param name="company">The company.</param>
        /// <returns></returns>
        Task<Company> Insert(Company company);
        /// <summary>
        /// Searches the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        Task<List<Company>> Search(string input);
        /// <summary>
        /// Gets the list of companies.
        /// </summary>
        /// <returns></returns>
        Task<List<Company>> GetList();
        /// <summary>
        /// Gets the company information by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<Company> GetCompanyInfoById(long id);
        /// <summary>
        /// Gets the company by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<Company?> GetCompanyById(long id);
    }
}
