using Microsoft.AspNetCore.Mvc;
using Owl.Overdrive.Business.Contracts;
using Owl.Overdrive.Business.DTOs.GameDtos;
using Owl.Overdrive.Business.DTOs.GameDtos.Create;
using Owl.Overdrive.Business.DTOs.GameDtos.Display.Details;
using Owl.Overdrive.Business.DTOs.GameDtos.Display.Simple;
using Owl.Overdrive.Business.DTOs.GameDtos.Responses;
using Owl.Overdrive.Business.DTOs.GameDtos.Update;
using Owl.Overdrive.Business.DTOs.ReviewsDtos.Create;
using Owl.Overdrive.Business.DTOs.ReviewsDtos.Display;
using Owl.Overdrive.Business.DTOs.ServiceResults;
using Owl.Overdrive.Business.Services.Models;
using Owl.Overdrive.Infrastructure.Attributes;

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
        [AuthorizeJwt]
        public async Task<ActionResult<ServiceResult<CreateGameResponseDto>>> AddGame([FromBody] CreateGameDto createGameDto)
        {
            var result = await _gameFacade.Create(createGameDto);
            return Ok(result);
        }

        [HttpPost("Search")]
        [AuthorizeJwt]
        public async Task<ActionResult<List<SearchParentGameDto>>> Search([FromQuery] string searchInput)
        {
           var result = await _gameFacade.Search(searchInput);
            return Ok(result);
        }

        [HttpPost("GetAllGames")]
        [AuthorizeJwt]
        public async Task<ActionResult<ServiceSearchResultData<List<GameSimpleDto>>>> GetAllGames([FromBody] DataLoaderOptions options)
        {
            var result = await _gameFacade.List(options);
            return Ok(result);
        }

        [HttpGet("GetGame")]
        [AuthorizeJwt]
        public async Task<ActionResult<GameDetailsDto>> GetGame([FromQuery] long gameId)
        {
            var result = await _gameFacade.GetGameById(gameId);
            return Ok(result);
        }

        [HttpGet("GetGameForEdit")]
        [AuthorizeJwt]
        public async Task<ActionResult<UpdateGameDto>> GetGameForEdit([FromQuery] long gameId)
        {
            var result = await _gameFacade.GetGameForUpdate(gameId);
            return Ok(result);
        }

        [HttpPost("UpdateGame")]
        [AuthorizeJwt]
        public async Task<ActionResult<ServiceResult<UpdateGameDto>>> UpdateGame([FromBody] UpdateGameDto updateGameDto)
        {
            var result = await _gameFacade.UpdateGame(updateGameDto);
            return Ok(result);
        }

        [HttpPost("AddUserReview")]
        [AuthorizeJwt]
        public async Task<ActionResult<ServiceResult<AddUserReviewDto>>> AddUserReview([FromBody] AddUserReviewDto userReviewDto)
        {
            var result = await _gameFacade.AddUserReview(userReviewDto);
            return Ok(result);
        }

        [HttpGet("GetAllGameUserReviews")]
        [AuthorizeJwt]
        public async Task<ActionResult<GameUserReviewsDto>> GetAllGameUserReviews([FromQuery] long gameId)
        {
            var result = await _gameFacade.GetAllGameUserReviews(gameId);
            return Ok(result);
        }
    }
}