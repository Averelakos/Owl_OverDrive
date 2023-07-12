using Microsoft.EntityFrameworkCore;
using Owl.Overdrive.Domain.Entities;
using Owl.Overdrive.Domain.Entities.Company;
using Owl.Overdrive.Infrastructure.Persistence.DbContexts;
using Owl.Overdrive.Repository.Contracts;

namespace Owl.Overdrive.Repository.Repositories
{
    public class CompanyLogoRepository : BaseRepository<CompanyLogo>, ICompanyLogoRepository
    {
        public CompanyLogoRepository(OwlOverdriveDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<CompanyLogo> Insert(CompanyLogo companyLogo)
        {
            return await base.Insert(companyLogo);
        }

        public async Task<CompanyLogo?> GetCompanyLogo(long id)
        {
            try
            {
                return await _DbSet
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
            
        }

        public override async Task<CompanyLogo?> GetById(long id)
        {
            return await base.GetById(id);
        }

    }
}
