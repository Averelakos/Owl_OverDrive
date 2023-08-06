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
    /// <seealso cref="Owl.Overdrive.Repository.Repositories.BaseRepository&lt;Owl.Overdrive.Domain.Entities.Region&gt;" />
    /// <seealso cref="Owl.Overdrive.Repository.Contracts.IRegionRepository" />
    public class RegionRepository : BaseRepository<Region>, IRegionRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CountryCodeRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public RegionRepository(OwlOverdriveDbContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// Gets the companies status.
        /// </summary>
        /// <returns></returns>
        public IQueryable<Region> GetRegions()
        {
            return _DbSet
                .AsNoTracking()
                .OrderBy(x => x.Name);
        }
    }
}
