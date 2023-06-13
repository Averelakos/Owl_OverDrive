using Owl.Overdrive.Domain.Entities;

namespace Owl.Overdrive.Repository.Contracts
{
    public interface ICountryCodeRepository
    {
        /// <summary>
        /// Gets the companies status.
        /// </summary>
        /// <returns></returns>
        IQueryable<CountryCode> GetCoutriesCodes();
    }
}
