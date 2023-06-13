using Microsoft.EntityFrameworkCore;
using Owl.Overdrive.Domain.Entities;
using Owl.Overdrive.Infrastructure.Persistence.DbContexts;
using Owl.Overdrive.Repository.Contracts;

namespace Owl.Overdrive.Repository.Repositories
{
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(OwlOverdriveDbContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// Inserts the specified company.
        /// </summary>
        /// <param name="company">The company.</param>
        /// <returns></returns>
        public async Task<Company> Insert(Company company)
        {
            var result =  await base.Insert(company);
            return result;
        }

        /// <summary>
        /// Searches the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public async Task<List<Company>> Search(string input)
        {
            return await _DbSet
                .Where(x => x.Name.ToLower().Contains(input.ToLower()))
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
