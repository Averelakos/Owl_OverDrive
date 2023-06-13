using Microsoft.EntityFrameworkCore;
using Owl.Overdrive.Domain.Entities;
using Owl.Overdrive.Infrastructure.Persistence.DbContexts;
using Owl.Overdrive.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Owl.Overdrive.Repository.Repositories
{
    /// <summary>
    /// Company reposiroty access database data for the company statuses
    /// </summary>
    /// <seealso cref="Owl.Overdrive.Repository.Repositories.BaseRepository&lt;Owl.Overdrive.Domain.Entities.CompanyStatus&gt;" />
    /// <seealso cref="Owl.Overdrive.Repository.Contracts.ICompanyStatusRepository" />
    public class CompanyStatusRepository : BaseRepository<CompanyStatus>, ICompanyStatusRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyStatusRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public CompanyStatusRepository(OwlOverdriveDbContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// Gets the companies status.
        /// </summary>
        /// <returns></returns>
        public async Task<List<CompanyStatus>> GetCompaniesStatus()
        {
            return await _DbSet
                .AsNoTracking()
                .OrderBy(x => x.Name)
                .ToListAsync();
        }
    }
}
