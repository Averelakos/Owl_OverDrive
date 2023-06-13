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
        public ICompanyStatusRepository CompanyStatusRepository { get; }
        public ICountryCodeRepository CountryCodeRepository { get; }
        #endregion Properties

        public RepositoryUnitOfWork(
            OwlOverdriveDbContext dbContext, 
            ICompanyRepository companyRepository, 
            ICompanyStatusRepository companyStatusRepository, 
            ICountryCodeRepository countryCodeRepository)
        {
            _dbContext = dbContext;
            CompanyRepository = companyRepository;
            CompanyStatusRepository = companyStatusRepository;
            CountryCodeRepository = countryCodeRepository;
        }
    }
}
