using Owl.Overdrive.Business.DTOs.CompanyDtos;
using Owl.Overdrive.Business.DTOs.GameDtos;
using Owl.Overdrive.Business.DTOs.GameDtos.Create;
using Owl.Overdrive.Business.DTOs.GameDtos.Display.Simple;
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
    public interface IGameFacade
    {
        /// <summary>
        /// Creates the specified game dto.
        /// </summary>
        /// <param name="createGameDto">The create game dto.</param>
        /// <returns></returns>
        Task<ServiceResult<CreateGameDto>> Create(CreateGameDto createGameDto);
        /// <summary>
        /// Searches the specified game based on  search input.
        /// </summary>
        /// <param name="searchInput">The search input.</param>
        /// <returns></returns>
        Task<List<SearchGameDto>> Search(string searchInput);
        /// <summary>
        /// Lists this instance.
        /// </summary>
        /// <returns></returns>
        Task<ServiceSearchResultData<List<GameSimpleDto>>> List(DataLoaderOptions options);

    }
}
