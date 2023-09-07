using Microsoft.EntityFrameworkCore;
using Owl.Overdrive.Domain.Entities.Game;
using Owl.Overdrive.Infrastructure.Persistence.DbContexts;
using Owl.Overdrive.Repository.Contracts;

namespace Owl.Overdrive.Repository.Repositories
{
    public class CoverRepository : BaseRepository<Cover>, ICoverRepository
    {
        public CoverRepository(OwlOverdriveDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Cover> Insert(Cover cover)
        {
            return await base.Insert(cover);
        }

        public async Task<Cover?> GetCompanyLogo(long id)
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

        public override async Task<Cover?> GetById(long id)
        {
            return await base.GetById(id);
        }

    }
}
