using Owl.Overdrive.Infrastructure.Persistence.DbContexts;
using Owl.Overdrive.Repository.Contracts;
using Owl.Overdrive.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Owl.Overdrive.Repository.UnitOfWork
{
    public class RepositoryUnitOfWork : IRepositoryUnitOfWork
    {
        #region Properties
        private readonly OwlOverdriveDbContext _dbContext;
        public ICompanyRepository CompanyRepository { get; }
        public ICompanyStatusRepository CompanyStatusRepository { get; }
        public ICountryCodeRepository CountryCodeRepository { get; }
        public IImageDraftRepository ImageDraftRepository { get; }
        public ICompanyLogoRepository CompanyLogoRepository { get; }
        public IPlatformRepository PlatformRepository { get; }
        public IRegionRepository RegionRepository { get; }
        public ILanguageRepository LanguageRepository { get; }
        public IGameRepository GameRepository { get; }
        public IAlternativeGameTitleRepository AlternativeGameTitleRepository { get; }
        public IGameLocalizationRepository GameLocalizationRepository { get; }
        public ICoverRepository CoverRepository { get; }
        public IScreenshotRepository ScreenshotRepository { get; }
        #endregion Properties

        public RepositoryUnitOfWork(
            OwlOverdriveDbContext dbContext, 
            ICompanyRepository companyRepository, 
            ICompanyStatusRepository companyStatusRepository, 
            ICountryCodeRepository countryCodeRepository,
            IImageDraftRepository imageDraftRepository,
            ICompanyLogoRepository companyLogoRepository,
            IPlatformRepository platformRepository,
            IRegionRepository regionRepository,
            ILanguageRepository languageRepository,
            IGameRepository gameRepository, 
            IAlternativeGameTitleRepository alternativeGameTitleRepository,
            IGameLocalizationRepository gameLocalizationRepository,
            ICoverRepository coverRepository,
            IScreenshotRepository screenshotRepository
            )
        {
            _dbContext = dbContext;
            CompanyRepository = companyRepository;
            CompanyStatusRepository = companyStatusRepository;
            CountryCodeRepository = countryCodeRepository;
            ImageDraftRepository = imageDraftRepository;
            CompanyLogoRepository = companyLogoRepository;
            PlatformRepository = platformRepository;
            RegionRepository = regionRepository; 
            LanguageRepository = languageRepository;
            GameRepository = gameRepository;
            AlternativeGameTitleRepository = alternativeGameTitleRepository;
            GameLocalizationRepository = gameLocalizationRepository;
            CoverRepository = coverRepository;
            ScreenshotRepository = screenshotRepository;
        }
    }
}
