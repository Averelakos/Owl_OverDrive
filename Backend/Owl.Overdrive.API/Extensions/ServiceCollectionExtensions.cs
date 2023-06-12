using Microsoft.EntityFrameworkCore;
using Owl.Overdrive.Infrastructure.Persistence.DbContexts;
using Owl.Overdrive.Repository.Contracts;
using Owl.Overdrive.Repository.Repositories;
using Owl.Overdrive.Repository.UnitOfWork;

namespace Owl.Overdrive.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the database
        /// </summary>
        /// <param name="services">The services</param>
        /// <param name="configuration">The configuration</param>
        /// <returns>An IServiceCollections.</returns>
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddDbContext<OwlOverdriveDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            return services.AddScoped<IRepositoryUnitOfWork, RepositoryUnitOfWork>();
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped<ICompanyRepository, CompanyRepository>()
                ;
        }
    }
}
