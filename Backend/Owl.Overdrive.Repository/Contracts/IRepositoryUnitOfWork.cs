using Owl.Overdrive.Infrastructure.Persistence.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Owl.Overdrive.Repository.Contracts
{
    /// <summary>
    /// The repository unit if work.
    /// </summary>
    public interface IRepositoryUnitOfWork
    {
        /// <summary>
        /// Gets the company repository.
        /// </summary>
        /// <value>
        /// The company repository.
        /// </value>
        ICompanyRepository CompanyRepository { get; }
        /// <summary>
        /// Gets the company status repository.
        /// </summary>
        /// <value>
        /// The company status repository.
        /// </value>
        ICompanyStatusRepository CompanyStatusRepository { get; }
        /// <summary>
        /// Gets the country code repository.
        /// </summary>
        /// <value>
        /// The country code repository.
        /// </value>
        ICountryCodeRepository CountryCodeRepository { get; }
        /// <summary>
        /// Gets the image draft repository.
        /// </summary>
        /// <value>
        /// The image draft repository.
        /// </value>
        IImageDraftRepository ImageDraftRepository { get; }
        /// <summary>
        /// Gets the company logo repository.
        /// </summary>
        /// <value>
        /// The company logo repository.
        /// </value>
        ICompanyLogoRepository CompanyLogoRepository { get; }
        /// <summary>
        /// Gets the platform repository.
        /// </summary>
        /// <value>
        /// The platform repository.
        /// </value>
        IPlatformRepository PlatformRepository { get; }
        /// <summary>
        /// Gets the region repository.
        /// </summary>
        /// <value>
        /// The region repository.
        /// </value>
        IRegionRepository RegionRepository { get; }
        /// <summary>
        /// Gets the game status repository.
        /// </summary>
        /// <value>
        /// The game status repository.
        /// </value>
        IGameStatusRepository GameStatusRepository { get; }
        /// <summary>
        /// Gets the language repository.
        /// </summary>
        /// <value>
        /// The language repository.
        /// </value>
        ILanguageRepository LanguageRepository { get; }
        /// <summary>
        /// Gets the game repository.
        /// </summary>
        /// <value>
        /// The game repository.
        /// </value>
        IGameRepository GameRepository { get; }
        /// <summary>
        /// Gets the game title repository.
        /// </summary>
        /// <value>
        /// The game title repository.
        /// </value>
        IAlternativeGameTitleRepository AlternativeGameTitleRepository { get; }
    }
}
