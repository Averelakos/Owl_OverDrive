using Microsoft.AspNetCore.Mvc;
using Owl.Overdrive.Business.Contracts;
using Owl.Overdrive.Business.DTOs.CompanyDtos;
using Owl.Overdrive.Business.DTOs.LookupsDtos;
using Owl.Overdrive.Business.DTOs.ServiceResults;
using Owl.Overdrive.Domain.Entities.Company;
using System.Reflection.Metadata;

namespace Owl.Overdrive.Controllers
{
    public class PlatformController : BaseApiController
    {
        private readonly ILogger<PlatformController> _logger;
        private readonly IPlatformFacade _platformFacade;

        public PlatformController(ILogger<PlatformController> logger, IPlatformFacade PlatformFacade) : base(logger)
        {
            _logger = logger;
            _platformFacade = PlatformFacade;
        }

        [HttpPost("SearchPlatform")]
        public async Task<ActionResult<ServiceResult<CreateCompanyDto>>> SearchPlatform([FromQuery] string? input)
        {
            var result = await _platformFacade.SearchPlatform(input);
            return Ok(result);
        }

    }
}