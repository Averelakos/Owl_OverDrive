using Microsoft.AspNetCore.Mvc;
using Owl.Overdrive.Business.Contracts;
using Owl.Overdrive.Business.DTOs.LookupsDtos;

namespace Owl.Overdrive.Controllers
{
    public class LooksupController : BaseApiController
    {
        private readonly ILogger<LooksupController> _logger;
        private readonly ILookupFacade _lookupFacade;

        public LooksupController(ILogger<LooksupController> logger, ILookupFacade lookupFacade) : base(logger)
        {
            _logger = logger;
            _lookupFacade = lookupFacade;
        }

        [HttpGet]
        public async Task<ActionResult<LookupsDto>> Get()
        {
            var result = await _lookupFacade.Get();
            return Ok(result);
        }
    }
}