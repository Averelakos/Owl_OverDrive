using Microsoft.AspNetCore.Mvc;
using Owl.Overdrive.Business.Contracts;
using Owl.Overdrive.Business.DTOs.PlatformDtos;
using Owl.Overdrive.Infrastructure.Attributes;

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

        [HttpPost("SearchPlatformByName")]
        [AuthorizeJwt]
        public async Task<ActionResult<List<SearchPlatformDto>>> SearchPlatformByName([FromQuery] string? input)
        {
            var result = await _platformFacade.SearchPlatform(input);
            return Ok(result);
        }

        [HttpPost("GetPlatformById")]
        [AuthorizeJwt]
        public async Task<ActionResult<SearchPlatformDto>> GetPlatform([FromQuery] long input)
        {
            var result = await _platformFacade.GetPlatform(input);
            return Ok(result);
        }

    }
}