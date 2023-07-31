using Microsoft.EntityFrameworkCore;
using Owl.Overdrive.Domain.Entities;
using Owl.Overdrive.Domain.Entities.Company;
using Owl.Overdrive.Infrastructure.Persistence.DbContexts;
using Owl.Overdrive.Repository.Contracts;

namespace Owl.Overdrive.Repository.Repositories
{
    public class PlatformRepository : BaseRepository<Platform>, IPlatformRepository
    {
        public PlatformRepository(OwlOverdriveDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Platform>> GetAllPlatforms()
        {
            return new List<Platform>(await base.GetAll());
        }
    }
}
