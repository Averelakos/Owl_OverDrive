﻿using Microsoft.EntityFrameworkCore;
using Owl.Overdrive.Business.Contracts;
using Owl.Overdrive.Business.Facades;
using Owl.Overdrive.Domain.Configurations;
using Owl.Overdrive.Infrastructure.Contracts;
using Owl.Overdrive.Infrastructure.Persistence.DbContexts;
using Owl.Overdrive.Infrastructure.Services;
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
        /// <summary>
        /// Add to the scope the Unit of work repository
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            return services.AddScoped<IRepositoryUnitOfWork, RepositoryUnitOfWork>();
        }
        /// <summary>
        /// Adds the repositories.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped<ICompanyRepository, CompanyRepository>()
                .AddScoped<ICompanyStatusRepository, CompanyStatusRepository>()
                .AddScoped<ICountryCodeRepository, CountryCodeRepository>()
                .AddScoped<IImageDraftRepository, ImageDraftRepository>()
                .AddScoped<ICompanyLogoRepository, CompanyLogoRepository>()
                .AddScoped<IPlatformRepository,  PlatformRepository>()
                .AddScoped<IRegionRepository, RegionRepository>()
                .AddScoped<ILanguageRepository, LanguageRepository>()
                .AddScoped<IGameRepository, GameRepository>()
                .AddScoped<IAlternativeGameTitleRepository, AlternativeGameTitleRepository>()
                .AddScoped<IGameLocalizationRepository, GameLocalizationRepository>()
                .AddScoped<ICoverRepository, CoverRepository>()
                .AddScoped<IScreenshotRepository, ScreenshotRepository>()
                .AddScoped<IUserRepository, UserRepository>()
                ;
        }
        /// <summary>
        /// Adds the facades.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IServiceCollection AddFacades(this IServiceCollection services)
        {
            return services
                .AddScoped<ICompanyFacade, CompanyFacade>()
                .AddScoped<ILookupFacade, LookupFacade>()
                .AddScoped<IImageDraftFacade, ImageDraftFacade>()
                .AddScoped<IPlatformFacade, PlatformFacade>()
                .AddScoped<IGameFacade, GameFacade>()
                .AddScoped<IAuthFacade, AuthFacade>()
                .AddScoped<IUserFacade, UserFacade>()
                ;
        }
        /// <summary>
        /// Adds the infrastucture services.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IServiceCollection AddInfrastuctureServices(this IServiceCollection services)
        {
            return services
                .AddTransient<ITokenProviderService, TokenProviderService>()
                .AddTransient<ICurrentUserService, CurrentUserService>();
        }
        /// <summary>
        /// Adds the configurations.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">Missing token configuration</exception>
        public static IServiceCollection AddConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            var tokenConfiguration = configuration.GetSection(nameof(TokenConfiguration)).Get<TokenConfiguration>();
            if (tokenConfiguration is null)
                throw new Exception("Missing token configuration");
            services.AddSingleton(tokenConfiguration);
            return services;
        }

    }
}
