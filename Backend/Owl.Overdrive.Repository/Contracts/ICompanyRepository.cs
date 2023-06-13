using Owl.Overdrive.Domain.Entities;

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
    }
}
