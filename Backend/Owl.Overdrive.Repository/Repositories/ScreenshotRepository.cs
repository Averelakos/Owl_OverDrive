using Microsoft.EntityFrameworkCore;
using Owl.Overdrive.Domain.Entities.Game;
using Owl.Overdrive.Infrastructure.Persistence.DbContexts;
using Owl.Overdrive.Repository.Contracts;

namespace Owl.Overdrive.Repository.Repositories
{
    public class ScreenshotRepository : BaseRepository<Screenshot>, IScreenshotRepository
    {
        public ScreenshotRepository(OwlOverdriveDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Screenshot> Insert(Screenshot screenshot)
        {
            return await base.Insert(screenshot);
        }

        public async Task<Screenshot?> GetCompanyLogo(long id)
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

        public override async Task<Screenshot?> GetById(long id)
        {
            return await base.GetById(id);
        }

    }
}
