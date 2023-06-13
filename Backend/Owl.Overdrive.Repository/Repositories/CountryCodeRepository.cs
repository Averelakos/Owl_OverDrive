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
    /// Country codes reposiroty is used to access database data for the country codes
    /// </summary>
    /// <seealso cref="Owl.Overdrive.Repository.Repositories.BaseRepository&lt;Owl.Overdrive.Domain.Entities.CountryCode&gt;" />
    /// <seealso cref="Owl.Overdrive.Repository.Contracts.ICountryCodeRepository" />
    public class CountryCodeRepository : BaseRepository<CountryCode>, ICountryCodeRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CountryCodeRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public CountryCodeRepository(OwlOverdriveDbContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// Gets the companies status.
        /// </summary>
        /// <returns></returns>
        public async Task<List<CountryCode>> GetCoutriesCodes()
        {
            return await _DbSet
                .AsNoTracking()
                .OrderBy(x => x.CountryName)
                .ToListAsync();
        }
    }
}
