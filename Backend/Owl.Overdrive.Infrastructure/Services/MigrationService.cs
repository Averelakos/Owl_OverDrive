using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Options;
using Owl.Overdrive.Domain.Configurations;
using Owl.Overdrive.Infrastructure.Persistence.DbContexts;

namespace Owl.Overdrive.Infrastructure.Services
{
    public sealed class MigrationService
    {
        private readonly OwlOverdriveDbContext _owlOverdriveDbContext;
        private readonly MigrationsSettings _migrationsSettings;

        public MigrationService(OwlOverdriveDbContext owlOverdriveDbContext, IOptions<MigrationsSettings> migrationsSettings)
        {
            _owlOverdriveDbContext = owlOverdriveDbContext;
            _migrationsSettings = migrationsSettings.Value;
        }

        public async Task StartAsync()
        {
            if (_migrationsSettings.Enabled is false)
                return;

            RelationalDatabaseCreator creator = (_owlOverdriveDbContext.Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator)!;
            var hasCreated = await creator.ExistsAsync();
            if (!hasCreated)
                await creator.CreateAsync();

            var migrationsPending = _owlOverdriveDbContext.Database.GetPendingMigrations();

            if (migrationsPending.Any())
                await _owlOverdriveDbContext.Database.MigrateAsync();
        }
    }
}
