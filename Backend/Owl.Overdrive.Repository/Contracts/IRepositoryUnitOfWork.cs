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
        ICompanyRepository CompanyRepository { get; }
    }
}
