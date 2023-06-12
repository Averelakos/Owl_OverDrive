using Owl.Overdrive.Infrastructure.Persistence.DbContexts;
using Owl.Overdrive.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Owl.Overdrive.Repository.UnitOfWork
{
    public class RepositoryUnitOfWork : IRepositoryUnitOfWork
    {
        #region Properties
        private readonly OwlOverdriveDbContext _dbContext;
        public ICompanyRepository CompanyRepository { get; }
        #endregion Properties

        public RepositoryUnitOfWork(OwlOverdriveDbContext dbContext, ICompanyRepository companyRepository)
        {
            _dbContext = dbContext;
            CompanyRepository = companyRepository;
        }
    }
}
