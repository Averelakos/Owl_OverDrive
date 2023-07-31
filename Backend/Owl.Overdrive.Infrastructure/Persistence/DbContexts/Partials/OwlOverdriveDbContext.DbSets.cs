using Microsoft.EntityFrameworkCore;
using Owl.Overdrive.Domain.Entities;
using Owl.Overdrive.Domain.Entities.Company;

namespace Owl.Overdrive.Infrastructure.Persistence.DbContexts
{
    public sealed partial class OwlOverdriveDbContext: DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Company> Companies => Set<Company>();
        public DbSet<CompanyStatus> CompanyStatuses => Set<CompanyStatus>();
        public DbSet<CountryCode> CountryCodes => Set<CountryCode>();
        public DbSet<ImageDraft> ImageDrafts => Set<ImageDraft>();
        public DbSet<CompanyLogo> CompanyLogo => Set<CompanyLogo>();
        public DbSet<Platform> Platforms => Set<Platform>();
    }
}
