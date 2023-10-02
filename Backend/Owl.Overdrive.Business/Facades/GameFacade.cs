using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Owl.Overdrive.Business.Contracts;
using Owl.Overdrive.Business.DTOs.GameDtos;
using Owl.Overdrive.Business.DTOs.GameDtos.Create;
using Owl.Overdrive.Business.DTOs.GameDtos.Display.Details;
using Owl.Overdrive.Business.DTOs.GameDtos.Display.Simple;
using Owl.Overdrive.Business.DTOs.GameDtos.Responses;
using Owl.Overdrive.Business.DTOs.GameDtos.Update;
using Owl.Overdrive.Business.DTOs.ServiceResults;
using Owl.Overdrive.Business.Facades.Base;
using Owl.Overdrive.Business.Services;
using Owl.Overdrive.Business.Services.Models;
using Owl.Overdrive.Domain.Entities.Game;
using Owl.Overdrive.Repository.Contracts;

namespace Owl.Overdrive.Business.Facades
{
    public class GameFacade : BaseFacade, IGameFacade
    {
        public GameFacade(IRepositoryUnitOfWork repoUoW, IMapper mapper) : base(repoUoW, mapper)
        {
        }
        #region Create
        /// <summary>
        /// Creates the specified game dto.
        /// </summary>
        /// <param name="createGameDto">The create game dto.</param>
        /// <returns></returns>
        public async Task<ServiceResult<CreateGameResponseDto>> Create(CreateGameDto createGameDto)
        {
            ServiceResult<CreateGameResponseDto> response = new();
            
            await _repoUoW.GameRepository.BeginTransactionAsync();
            try
            {

                var newGame = _mapper.Map<Game>(createGameDto);

                if ( newGame is null)
                {
                    throw new ArgumentNullException(paramName:nameof(newGame), message:"The new game entry cannot be null.");
                }

                var result = await _repoUoW.GameRepository.Insert(newGame);

                await _repoUoW.GameRepository.CommitTransactionAsync();

                response.Result = new CreateGameResponseDto(result.Id, result.Name);

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
        #endregion Create

        #region Update
        public async Task<UpdateGameDto?> GetGameForUpdate(long gameId)
        {
            var result = await _repoUoW.GameRepository
                    .QueryGame()
                    .AsNoTracking()
                    .ProjectTo<UpdateGameDto>(_mapper.ConfigurationProvider)
                    .FirstAsync(x => x.Id == gameId);

            return result;
        }

        public async Task<ServiceResult<UpdateGameDto>> UpdateGame(UpdateGameDto updateGameDto)
        {
            ServiceResult<UpdateGameDto> response = new()
            {
                Result = updateGameDto
            };

            await _repoUoW.CompanyRepository.BeginTransactionAsync();
            try
            {
                //var game = await _repoUoW.GameRepository.GetById(updateGameDto.Id);
                Game? game = await UpdateGameInternal(updateGameDto);

                // TODO: REMOVE IMAGE
                await _repoUoW.GameRepository.UpdateGame(game);
                await _repoUoW.GameRepository.CommitTransactionAsync();

                //TODO: RETURN SUCCESS RESPONSE
                return response;
            }
            catch (Exception ex)
            {
                await _repoUoW.GameRepository.RollBackTransactionAsync();
                //TODO: RETURN ERROR RESPONSE
                response.Success = false;
                response.Error = ex.Message;
                return response;
            }
        }

        private async Task<Game> UpdateGameInternal(UpdateGameDto updateGameDto)
        {
            var game = await _repoUoW.GameRepository.QueryGame()
                                .Include(x => x.AlternativeGameTitles)
                                .Include(x => x.Localizations)
                                .Include(x => x.ReleaseDates)
                                .Include(x => x.MultiplayerModes)
                                .Include(x => x.GameGenres)
                                .Include(x => x.GameThemes)
                                .Include(x => x.GamePlayerPerspectives)
                                .Include(x => x.GameGameModes)
                                .Include(x => x.Websites)
                                .Include(x =>x.InvolvedCompanies)
                                .ThenInclude(c => c.GameInvolvedCompanyPlatforms)
                                .Include(x => x.LanguageSupports)
                                .FirstOrDefaultAsync(x => x.Id == updateGameDto.Id);

            if (game is null)
            {
                throw new Exception();
            }

            if (game.AlternativeGameTitles?.Count > 0)
            {
                await _repoUoW.GameRepository.RemoveRangeAltTitles(game.AlternativeGameTitles);
            }

            if ( game.Localizations?.Count > 0)
            {
                await _repoUoW.GameRepository.RemoveRangeLocalizations(game.Localizations);
            }

            if (game.ReleaseDates?.Count > 0)
            {
                await _repoUoW.GameRepository.RemoveRangeReleaseDates(game.ReleaseDates);
            }

            if (game.MultiplayerModes?.Count > 0)
            {
                await _repoUoW.GameRepository.RemoveRangeMultiplayerModes(game.MultiplayerModes);
            }

            if (game.GameGenres?.Count > 0)
            {
                await _repoUoW.GameRepository.RemoveRangeGameGenres(game.GameGenres);
            }

            if (game.GameThemes?.Count > 0)
            {
                await _repoUoW.GameRepository.RemoveRangeGameThemes(game.GameThemes);
            }

            if (game.GameGameModes?.Count > 0)
            {
                await _repoUoW.GameRepository.RemoveRangeGameModes(game.GameGameModes);
            }

            if (game.GamePlayerPerspectives?.Count > 0)
            {
                await _repoUoW.GameRepository.RemoveRangeGamePerspectives(game.GamePlayerPerspectives);
            }

            if (game.Websites?.Count > 0)
            {
                await _repoUoW.GameRepository.RemoveRangeWebsites(game.Websites);
            }

            if (game.InvolvedCompanies?.Count > 0)
            {
                await _repoUoW.GameRepository.RemoveRangeInvolvedCompanies(game.InvolvedCompanies);
            }

            if (game.LanguageSupports?.Count > 0)
            {
                await _repoUoW.GameRepository.RemoveRangeSupportedLanguagess(game.LanguageSupports);
            }

            _mapper.Map<UpdateGameDto, Game>(updateGameDto, game);

            return game;
        }
        #endregion Update

        #region List
        public async Task<ServiceSearchResultData<List<GameSimpleDto>>> List(DataLoaderOptions options)
        {
            IQueryable<GameSimpleDto> source;

            if (options.SearchString is not null && options.SearchString.Length > 0)
            {
                source = await SearchFilter(options.SearchString);
            }
            else
            {
                source = List<GameSimpleDto>();
            }


            var dataDesult = await new DataLoaderService<GameSimpleDto>(source, options).LoadResult();

            ServiceSearchResultData<List<GameSimpleDto>> result = new();

            if (dataDesult.Data is not null)
            {
                result.Result = dataDesult.Data.ToList();
                result.TotalCount = dataDesult.TotalCount;
                result.TotalPages = dataDesult.TotalPages;
                return result;
            }
            else
            {
                result.Result = new List<GameSimpleDto>();
                return result;
            }
        }

        private async Task<IQueryable<GameSimpleDto>> SearchFilter(string searchInput)
        {
            List<GameSimpleDto> results = new();
            var resultExact = await _repoUoW.GameRepository
                    .QueryGame()
                    .Where(x => x.Name.Equals(searchInput))
                    .AsNoTracking()
                    .ProjectTo<GameSimpleDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();
            ;

            results.AddRange(resultExact);

            var resultStartsWith = await _repoUoW.GameRepository
                    .QueryGame()
                    .AsNoTracking()
                    .Where(x => x.Name.StartsWith(searchInput) && !results.Select(r => r.Id).Contains(x.Id))
                    .ProjectTo<GameSimpleDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();

            results.AddRange(resultStartsWith);

            var resultContains = await _repoUoW.GameRepository
                    .QueryGame()
                    .AsNoTracking()
                    .Where(x => x.Name.Contains(searchInput) && !results.Select(r => r.Id).Contains(x.Id))
                    .ProjectTo<GameSimpleDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();

            results.AddRange(resultContains);

            return results.AsQueryable<GameSimpleDto>();
        }

        #endregion List

        #region UI Helper
        /// <summary>
        /// Searches the specified game based on  search input.
        /// </summary>
        /// <param name="searchInput">The search input.</param>
        /// <returns></returns>
        public async Task<List<SearchParentGameDto>> Search(string searchInput)
        {
            List<SearchParentGameDto> result = new List<SearchParentGameDto>();
            if (!string.IsNullOrWhiteSpace(searchInput) && searchInput.Length > 2)
            {
                var list = await _repoUoW.GameRepository.Search(searchInput);
                result = _mapper.Map<List<SearchParentGameDto>>(list);
            }

            return result;
        }
        private IQueryable<T> List<T>()
        {
            return _repoUoW.GameRepository
                    .QueryGame()
                    .AsNoTracking()
                    .ProjectTo<T>(_mapper.ConfigurationProvider);
        }
        #endregion UI Helper

        #region Details
        public async Task<GameDetailsDto?> GetGameById(long gameId)
        {
            var game = await _repoUoW.GameRepository.GetGameByIdNoTacking(gameId);
            var result = _mapper.Map<GameDetailsDto>(game);
            await SetGameDetaulsSpelling(gameId, result);

            await SetGameDetailsMultiplayerModes(gameId, result);
            await GetGameDetailsLanguageSupport(gameId, result);
            await SetPlatformsReleaseDates(gameId, result);
            await GetGameDetailsCoverAndBackground(game, result);
            return result;

        }

        private async Task SetGameDetaulsSpelling(long gameId, GameDetailsDto result)
        {
            var altTitles = await _repoUoW.GameRepository
                            .QueryGame()
                            .Include(x => x.AlternativeGameTitles)
                            .Where(x => x.Id == gameId)
                            .Select(x => x.AlternativeGameTitles)
                            .AsNoTracking()
                            .FirstOrDefaultAsync();

            if (altTitles is not null && altTitles.Any())
            {
                var temp = _mapper.Map<List<GameDetailsTitlesDto>>(altTitles);

                result.Spellings.AlternativeTitles = temp;
            }

            var localizedTitle = await _repoUoW.GameRepository
                .QueryGame()
                .Include(x => x.Localizations)
                .ThenInclude(x => x.Region)
                .Where(x => x.Id == gameId)
                .Select(x => x.Localizations)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (localizedTitle is not null && localizedTitle.Any())
            {
                var temp = _mapper.Map<List<GameDetailsTitlesDto>>(localizedTitle);

                result.Spellings.LocalizedTitles = temp;
            }
        }

        private async Task SetGameDetailsMultiplayerModes(long gameId, GameDetailsDto result)
        {
            var multiplayerModes = await _repoUoW.GameRepository
                            .QueryGame()
                            .Include(x => x.MultiplayerModes)
                            .ThenInclude(x => x.Platform)
                            .Where(x => x.Id == gameId)
                            .Select(x => x.MultiplayerModes)
                            .AsNoTracking()
                            .FirstOrDefaultAsync();

            if (multiplayerModes is not null && multiplayerModes.Any())
            {
                var temp = _mapper.Map<List<GameDetailsMultiplayerModeDto>>(multiplayerModes);

                result.MultiplayerModes = temp;

            }
        }

        private async Task SetPlatformsReleaseDates(long gameId, GameDetailsDto result)
        {
            var platformReleaseDates = await _repoUoW.GameRepository
                            .QueryGame()
                            .Include(x => x.ReleaseDates)
                            .ThenInclude(x => x.Platform)
                            .Where(x => x.Id == gameId)
                            .Select(x => x.ReleaseDates)
                            .AsNoTracking()
                            .FirstOrDefaultAsync();

            if (platformReleaseDates is not null && platformReleaseDates.Count() > 0)
            {
                List<GameDetailsPlatformReleasedDatesDto> listPlatformsReleaseDates = new();

                foreach (var releaseDate in platformReleaseDates)
                {
                    if (listPlatformsReleaseDates.Any(x => x.PlatformName == releaseDate.Platform.Name))
                    {
                        var temp = listPlatformsReleaseDates.Where(x => x.PlatformName == releaseDate.Platform.Name).First();
                        listPlatformsReleaseDates.Remove(temp);
                        temp.ReleaseDates.Add(new GameDetailsReleasedDateDto
                        {
                            Date = releaseDate.Date,
                            RegionId = releaseDate.RegionId,
                            Status = releaseDate.Status,
                        });

                        listPlatformsReleaseDates.Add(temp);
                    }
                    else
                    {
                        var temp = new GameDetailsPlatformReleasedDatesDto()
                        {
                            PlatformName = releaseDate.Platform.Name,
                            ReleaseDates = new()
                        };

                        temp.ReleaseDates.Add(new GameDetailsReleasedDateDto
                        {
                            Date = releaseDate.Date,
                            RegionId = releaseDate.RegionId,
                            Status = releaseDate.Status,
                        });

                        listPlatformsReleaseDates.Add(temp);
                    }
                }
                result.PlatformsReleaseDates = listPlatformsReleaseDates;
            }
        }

        private async Task GetGameDetailsCoverAndBackground(Game? game, GameDetailsDto result)
        {
            if (game?.CoverId is not null)
            {
                var coverResult = await _repoUoW.CoverRepository.GetCover((long)game.CoverId);
                if (coverResult is not null)
                {
                    var cover = _mapper.Map<GameCoverDetailsDto>(coverResult);
                    var background = _mapper.Map<GameBackgroundDetailsDto>(coverResult);

                    result.Cover = cover;
                    result.Background = background;
                }
            }
        }

        private async Task GetGameDetailsLanguageSupport(long gameId, GameDetailsDto result)
        {
            var languages = await _repoUoW.GameRepository
                            .QueryGame()
                            .Include(x => x.LanguageSupports)
                            .ThenInclude(x => x.LanguageSupportType)
                            .AsNoTracking()
                            .Where(x => x.Id == gameId)
                            .Select(x => x.LanguageSupports)
                            .FirstOrDefaultAsync();

            var mapLanguages = _mapper.Map<GameDetailsSupportedLanguageDto>(languages);

            if (mapLanguages is not null)
            {
                result.Supportedlanguages = mapLanguages;
            }
        }
        #endregion Details


    }
}
