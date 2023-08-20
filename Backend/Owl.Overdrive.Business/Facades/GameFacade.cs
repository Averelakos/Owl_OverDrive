using AutoMapper;
using Owl.Overdrive.Business.Contracts;
using Owl.Overdrive.Business.DTOs.GameDtos;
using Owl.Overdrive.Business.DTOs.GameDtos.Create;
using Owl.Overdrive.Business.DTOs.ServiceResults;
using Owl.Overdrive.Business.Facades.Base;
using Owl.Overdrive.Domain.Entities.Game;
using Owl.Overdrive.Repository.Contracts;

namespace Owl.Overdrive.Business.Facades
{
    public class GameFacade : BaseFacade, IGameFacade
    {
        public GameFacade(IRepositoryUnitOfWork repoUoW, IMapper mapper) : base(repoUoW, mapper)
        {
        }

        /// <summary>
        /// Creates the specified game dto.
        /// </summary>
        /// <param name="createGameDto">The create game dto.</param>
        /// <returns></returns>
        public async Task<ServiceResult<CreateGameDto>> Create(CreateGameDto createGameDto)
        {
            ServiceResult<CreateGameDto> response = new();
            response.Result = createGameDto;
            await _repoUoW.GameRepository.BeginTransactionAsync();
            try
            {
                
                var newGame = _mapper.Map<Game>(createGameDto);

                if ( newGame is null)
                {
                    throw new ArgumentNullException(paramName:nameof(newGame), message:"The new game entry cannot be null.");
                }

                var result = await _repoUoW.GameRepository.Insert(newGame);

                // Add alternative names if they exists
                //if (createGameDto.AlternativeNames is not null && createGameDto.AlternativeNames.Any())
                //{
                //    var altNames = _mapper.Map<List<AlternativeGameTitle>>(createGameDto.AlternativeNames);

                //    altNames.ForEach(x => x.GameId = newGame.Id);

                //    await _repoUoW.AlternativeGameTitleRepository.InsertRange(altNames);
                //}

                //if (createGameDto.GameLocalizations is not null && createGameDto.GameLocalizations.Any())
                //{
                //    var localNames = _mapper.Map<List<GameLocalization>>(createGameDto.GameLocalizations);

                //    localNames.ForEach(x => x.GameId = newGame.Id);

                //    await _repoUoW.GameLocalizationRepository.InsertRange(localNames);
                //}

                await _repoUoW.GameRepository.CommitTransactionAsync();

                return response;
            }
            catch (Exception ex)
            {
                await _repoUoW.GameRepository.RollBackTransactionAsync();
                // logger and responce message
                response.Success = false;
                response.Error = ex.Message;
                return response;
            }

        }

        /// <summary>
        /// Searches the specified game based on  search input.
        /// </summary>
        /// <param name="searchInput">The search input.</param>
        /// <returns></returns>
        public async Task<List<SearchGameDto>> Search(string searchInput)
        {
            List<SearchGameDto> result = new List<SearchGameDto>();
            if (!string.IsNullOrWhiteSpace(searchInput) && searchInput.Length > 2)
            {
                //var list = await _repoUoW.CompanyRepository.Search(searchInput);
                //result = _mapper.Map<List<SearchParentCompanyDto>>(list);
            }

            return result;
        }
    }
}
