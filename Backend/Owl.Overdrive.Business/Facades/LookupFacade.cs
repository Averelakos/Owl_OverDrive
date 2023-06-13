using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Owl.Overdrive.Business.Contracts;
using Owl.Overdrive.Business.DTOs.LookupsDtos;
using Owl.Overdrive.Business.Facades.Base;
using Owl.Overdrive.Repository.Contracts;

namespace Owl.Overdrive.Business.Facades
{
    public class LookupFacade : BaseFacade, ILookupFacade
    {
        public LookupFacade(IRepositoryUnitOfWork repoUoW, IMapper mapper) : base(repoUoW, mapper)
        {
        }

        public async Task<LookupsDto> Get()
        {
            var companyStatus = await GetLookupValues<CompanyStatusLookupDto>();
            var countryCodes = await GetLookupValues<CountryCodeLookupDto>();

            LookupsDto result = new LookupsDto() 
            {
                CompanyStatus = companyStatus,
                CountryCode = countryCodes
            };

            return result;
        }

        /// <summary>
        /// Gets the lookup values.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public async Task<List<T>> GetLookupValues<T>() where T: BaseLookupDto
        {
            List<T> lookupDto = await GetValues<T>();
            return lookupDto is not null ? lookupDto : new List<T>();
        }

        /// <summary>
        /// Gets the values.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        private async Task<dynamic> GetValues<T>() where T: BaseLookupDto
        {
            switch(typeof(T))
            {
                case Type type when type == typeof(CompanyStatusLookupDto):
                    return await GetCompanyStatuses();
                case Type type when type == typeof(CountryCodeLookupDto):
                    return await GetCountryCodes();
                default: 
                    throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets the company statuses.
        /// </summary>
        /// <returns></returns>
        private async Task<List<CompanyStatusLookupDto>> GetCompanyStatuses()
        {
            return await _repoUoW.CompanyStatusRepository
                .GetCompaniesStatus()
                .ProjectTo<CompanyStatusLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        /// <summary>
        /// Gets the country codes.
        /// </summary>
        /// <returns></returns>
        private async Task<List<CountryCodeLookupDto>> GetCountryCodes()
        {
            return await _repoUoW.CountryCodeRepository
                .GetCoutriesCodes()
                .ProjectTo<CountryCodeLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}
