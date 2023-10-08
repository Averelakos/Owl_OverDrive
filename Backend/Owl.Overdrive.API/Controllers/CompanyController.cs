using Microsoft.AspNetCore.Mvc;
using Owl.Overdrive.Business.Contracts;
using Owl.Overdrive.Business.DTOs.CompanyDtos;
using Owl.Overdrive.Business.DTOs.CompanyDtos.Create;
using Owl.Overdrive.Business.DTOs.CompanyDtos.Display;
using Owl.Overdrive.Business.DTOs.CompanyDtos.Update;
using Owl.Overdrive.Business.DTOs.GameDtos.Display.Simple;
using Owl.Overdrive.Business.DTOs.LookupsDtos;
using Owl.Overdrive.Business.DTOs.ServiceResults;
using Owl.Overdrive.Business.Services.Models;
using Owl.Overdrive.Domain.Entities.Company;
using Owl.Overdrive.Infrastructure.Attributes;
using System.Reflection.Metadata;

namespace Owl.Overdrive.Controllers
{
    public class CompanyController : BaseApiController
    {
        private readonly ILogger<CompanyController> _logger;
        private readonly ICompanyFacade _companyFacade;

        public CompanyController(ILogger<CompanyController> logger, ICompanyFacade CompanyFacade) : base(logger)
        {
            _logger = logger;
            _companyFacade = CompanyFacade;
        }

        [HttpPost("AddCompany")]
        [AuthorizeJwt]
        public async Task<ActionResult<ServiceResult<CreateCompanyDto>>> AddCompany([FromBody] CreateCompanyDto createCompanyDto)
        {
            var result = await _companyFacade.Create(createCompanyDto);
            return Ok(result);
        }

        [HttpPost("SearchParent")]
        [AuthorizeJwt]
        public async Task<ActionResult<List<SearchParentCompanyDto>>> SearchParentCompany([FromQuery]string searchInput)
        {
            var result = await _companyFacade.Search(searchInput);
            return Ok(result);
        }

        [HttpPost("RetrieveSearchCompany")]
        [AuthorizeJwt]
        public async Task<ActionResult<List<SearchParentCompanyDto>>> RetrieveSearchCompany([FromQuery] long searchInput)
        {
            var result = await _companyFacade.RetrieveSearchValue(searchInput);
            return Ok(result);
        }

        [HttpPost("list")]
        [AuthorizeJwt]
        public async Task<ActionResult<ServiceSearchResultData<List<CompanySimpleDto>>>> List([FromBody] DataLoaderOptions options)
        {
            var result = await _companyFacade.ListCompany(options);
            return Ok(result);
        }

        [HttpGet("GetCompany")]
        [AuthorizeJwt]
        public async Task<ActionResult<SimpleCompanyDto>> GetCompany([FromQuery] long companyId)
        {
            var result = await _companyFacade.GetCompanyById(companyId);
            return Ok(result);
        }

        [HttpGet("GetCompanyLogo")]
        [AuthorizeJwt]
        public async Task<ActionResult<UpdateCompanyDto>> GetCompanyLogo([FromQuery] long companyId)
        {
            var result = await _companyFacade.GetLogoByCompanyId(companyId);
            return Ok(result);
        }

        [HttpPost("UpdateCompany")]
        [AuthorizeJwt]
        public async Task<ActionResult<ServiceResult<UpdateCompanyDto>>> UpdateCompany([FromBody] UpdateCompanyDto updateCompanyDto)
        {
            var result = await _companyFacade.UpdateCompany(updateCompanyDto);
            return Ok(result);
        }
    }
}