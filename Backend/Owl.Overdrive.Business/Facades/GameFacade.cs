using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Owl.Overdrive.Business.Contracts;
using Owl.Overdrive.Business.DTOs.CompanyDtos;
using Owl.Overdrive.Business.DTOs.GameDtos;
using Owl.Overdrive.Business.DTOs.GameDtos.Create;
using Owl.Overdrive.Business.DTOs.GameDtos.Display.Details;
using Owl.Overdrive.Business.DTOs.GameDtos.Display.Simple;
using Owl.Overdrive.Business.DTOs.GameDtos.Update;
using Owl.Overdrive.Business.DTOs.ServiceResults;
using Owl.Overdrive.Business.Facades.Base;
using Owl.Overdrive.Business.Services;
using Owl.Overdrive.Business.Services.Models;
using Owl.Overdrive.Domain.Entities;
using Owl.Overdrive.Domain.Entities.Game;
using Owl.Overdrive.Repository.Contracts;
using System.Text;

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

                //if(createGameDto.Image is not null && result is not null) 
                //{
                //var imageResult = await _repoUoW.ImageDraftRepository.GetImageByGuid(createGameDto.Cover);

                //if (imageResult is null)
                //    throw new ArgumentNullException();
                //    if (imageFile is not null)
                //{
                //    Cover newCover = new Cover
                //    {
                //        ImageData = imageFile as byte[],
                //        ImageTitle = createGameDto.Image.FileName,
                //    };
                //}
                //Cover newCover = new Cover
                //{
                //    ImageData = imageFile,
                //    ImageTitle = createGameDto.Image.FileName,
                //};

                //await _repoUoW.CoverRepository.Insert(newCover);

                //result.CoverId = newCover.Id;

                //await _repoUoW.GameRepository.SaveChangesAsync();
                ////}

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
                var list = await _repoUoW.CompanyRepository.Search(searchInput);
                result = _mapper.Map<List<SearchGameDto>>(list);
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

        public async Task<GameDetailsDto?> GetGameById(long gameId)
        {
            var game = await _repoUoW.GameRepository.GetGameByIdNoTacking(gameId);
            var result = _mapper.Map<GameDetailsDto>(game);

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
                return result;

        }

        public async Task<UpdateGameDto?> GetGameForUpdate(long gameId)
        {
            var result = await _repoUoW.GameRepository
                    .QueryGame()
                    .AsNoTracking()
                    .ProjectTo<UpdateGameDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(x => x.Id == gameId);

            return result;
        }
    }
}
