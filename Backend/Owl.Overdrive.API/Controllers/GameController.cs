using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Owl.Overdrive.Business.Contracts;
using Owl.Overdrive.Business.DTOs.CompanyDtos;
using Owl.Overdrive.Business.DTOs.GameDtos.Create;
using Owl.Overdrive.Business.DTOs.GameDtos.Display.Simple;
using Owl.Overdrive.Business.DTOs.ServiceResults;
using Owl.Overdrive.Business.Services.Models;

namespace Owl.Overdrive.Controllers
{
    public class GameController : BaseApiController
    {
        private readonly ILogger<GameController> _logger;
        private readonly IGameFacade _gameFacade;

        public GameController(ILogger<GameController> logger, IGameFacade gameFacade) : base(logger)
        {
            _logger = logger;
            _gameFacade = gameFacade;
        }

        [HttpPost("AddGame")]
        public async Task<ActionResult<ServiceResult<CreateCompanyDto>>> AddGame([FromBody] CreateGameDto createGameDto)
        {
            var result = await _gameFacade.Create(createGameDto);
            return Ok();
        }

        [HttpPost("Search")]
        public async Task<ActionResult<List<SearchParentCompanyDto>>> Search([FromQuery] string searchInput)
        {
           var result = await _gameFacade.Search(searchInput);
            return Ok(result);
        }

        [HttpPost("GetAllGames")]
        public async Task<ActionResult<ServiceSearchResultData<List<GameSimpleDto>>>> GetAllGames([FromBody] DataLoaderOptions options)
        {
            var result = await _gameFacade.List(options);
            return Ok(result);
        }

        //[HttpGet("list")]
        //public async Task<ActionResult<List<ListCompanyDto>>> List()
        //{
        //    var result = await _companyFacade.GetAll();
        //    return Ok(result);
        //}

        //[HttpGet("GetCompany")]
        //public async Task<ActionResult<SimpleCompanyDto>> GetCompany([FromQuery] long companyId)
        //{
        //    var result = await _companyFacade.GetCompanyById(companyId);
        //    return Ok(result);
        //}

        //[HttpGet("GetCompanyLogo")]
        //public async Task<ActionResult<UpdateCompanyDto>> GetCompanyLogo([FromQuery] long companyId)
        //{
        //    var result = await _companyFacade.GetLogoByCompanyId(companyId);
        //    return Ok(result);
        //}

        //[HttpPost("UpdateCompany")]
        //public async Task<ActionResult<ServiceResult<UpdateCompanyDto>>> UpdateCompany([FromBody] UpdateCompanyDto updateCompanyDto)
        //{
        //    var result = await _companyFacade.UpdateCompany(updateCompanyDto);
        //    return Ok(result);
        //}
    }
}