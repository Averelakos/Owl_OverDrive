using Microsoft.EntityFrameworkCore;
using Owl.Overdrive.Domain.Entities;
using Owl.Overdrive.Domain.Entities.Company;
using Owl.Overdrive.Domain.Entities.Game;
using Owl.Overdrive.Infrastructure.Persistence.DbContexts;
using Owl.Overdrive.Repository.Contracts;

namespace Owl.Overdrive.Repository.Repositories
{
    public class LanguageRepository : BaseRepository<Language>, ILanguageRepository
    {
        public LanguageRepository(OwlOverdriveDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Language>> GetAllLanguages()
        {
            return new List<Language>(await base.GetAll());
        }

        public IQueryable<Language> GetAllNotTracking()
        {
            return _DbSet
                .AsNoTracking()
                .OrderBy(x => x.Name);
        }
    }
}
