using Owl.Overdrive.Business.DTOs.GameDtos;
using Owl.Overdrive.Business.DTOs.GameDtos.Create;
using Owl.Overdrive.Business.DTOs.GameDtos.Display.Details;
using Owl.Overdrive.Business.DTOs.GameDtos.Display.Simple;
using Owl.Overdrive.Business.DTOs.GameDtos.Responses;
using Owl.Overdrive.Business.DTOs.GameDtos.Update;
using Owl.Overdrive.Business.DTOs.ServiceResults;
using Owl.Overdrive.Business.Services.Models;

namespace Owl.Overdrive.Business.Contracts
{
    public interface IGameFacade
    {
        /// <summary>
        /// Creates the specified game dto.
        /// </summary>
        /// <param name="createGameDto">The create game dto.</param>
        /// <returns></returns>
        Task<ServiceResult<CreateGameResponseDto>> Create(CreateGameDto createGameDto);
        Task<ServiceResult<UpdateGameDto>> UpdateGame(UpdateGameDto updateGameDto);
        /// <summary>
        /// Searches the specified game based on  search input.
        /// </summary>
        /// <param name="searchInput">The search input.</param>
        /// <returns></returns>
        Task<List<SearchParentGameDto>> Search(string searchInput);
        /// <summary>
        /// Lists this instance.
        /// </summary>
        /// <returns></returns>
        Task<ServiceSearchResultData<List<GameSimpleDto>>> List(DataLoaderOptions options);
        Task<GameDetailsDto?> GetGameById(long gameId);
        Task<UpdateGameDto?> GetGameForUpdate(long gameId);

    }
}
