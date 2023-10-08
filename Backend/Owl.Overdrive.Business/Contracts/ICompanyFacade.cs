using Owl.Overdrive.Business.DTOs.CompanyDtos;
using Owl.Overdrive.Business.DTOs.CompanyDtos.Create;
using Owl.Overdrive.Business.DTOs.CompanyDtos.Display;
using Owl.Overdrive.Business.DTOs.CompanyDtos.Update;
using Owl.Overdrive.Business.DTOs.ServiceResults;
using Owl.Overdrive.Business.Services.Models;
using Owl.Overdrive.Domain.Entities.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Owl.Overdrive.Business.Contracts
{
    public interface ICompanyFacade
    {
        /// <summary>
        /// Creates the specified create company dto.
        /// </summary>
        /// <param name="createCompanyDto">The create company dto.</param>
        /// <returns></returns>
        Task<ServiceResult<CreateCompanyDto>> Create(CreateCompanyDto createCompanyDto);
        /// <summary>
        /// Searches the specified search input.
        /// </summary>
        /// <param name="searchInput">The search input.</param>
        /// <returns></returns>
        Task<List<SearchParentCompanyDto>> Search(string searchInput);
        Task<SearchParentCompanyDto> RetrieveSearchValue(long searchInput);
        Task<ServiceSearchResultData<List<CompanySimpleDto>>> ListCompany(DataLoaderOptions options);
        Task<SimpleCompanyDto> GetCompanyById(long companyId);
        Task<UpdateCompanyDto> GetCompanyForUpdate(long companyId);
        Task<UpdateCompanyLogoDto> GetLogoByCompanyId(long companyId);
        Task<ServiceResult<UpdateCompanyDto>> UpdateCompany(UpdateCompanyDto updateCompanyDto);
    }
}
