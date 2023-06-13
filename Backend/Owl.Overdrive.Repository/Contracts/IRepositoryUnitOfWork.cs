using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Owl.Overdrive.Repository.Contracts
{
    /// <summary>
    /// The repository unit if work.
    /// </summary>
    public interface IRepositoryUnitOfWork
    {
        /// <summary>
        /// Gets the company repository.
        /// </summary>
        /// <value>
        /// The company repository.
        /// </value>
        ICompanyRepository CompanyRepository { get; }
        /// <summary>
        /// Gets the company status repository.
        /// </summary>
        /// <value>
        /// The company status repository.
        /// </value>
        ICompanyStatusRepository CompanyStatusRepository { get; }
        /// <summary>
        /// Gets the country code repository.
        /// </summary>
        /// <value>
        /// The country code repository.
        /// </value>
        ICountryCodeRepository CountryCodeRepository { get; }
    }
}
