using Microsoft.AspNetCore.Mvc;
using Owl.Overdrive.Business.Contracts;
using Owl.Overdrive.Business.DTOs.CompanyDtos;
using Owl.Overdrive.Business.DTOs.LookupsDtos;

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
        public async Task<ActionResult> AddCompany([FromBody] CreateCompanyDto createCompanyDto)
        {
            await _companyFacade.Create(createCompanyDto);
            return Ok();
        }
    }
}