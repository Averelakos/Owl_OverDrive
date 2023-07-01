using Microsoft.EntityFrameworkCore;
using Owl.Overdrive.Infrastructure.Persistence.Configurations;

namespace Owl.Overdrive.Infrastructure.Persistence.DbContexts
{
    public sealed partial class OwlOverdriveDbContext: DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ModelCreating(modelBuilder);
        }

        public void ModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyStatusConfiguration());
            modelBuilder.ApplyConfiguration(new CountryCodeConfiguration());
            modelBuilder.ApplyConfiguration(new ImagesDraftConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyLogoConfiguration());
        }
    }
}
