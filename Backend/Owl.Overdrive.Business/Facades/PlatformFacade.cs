using AutoMapper;
using Owl.Overdrive.Business.Contracts;
using Owl.Overdrive.Business.DTOs.CompanyDtos;
using Owl.Overdrive.Business.DTOs.PlatformDtos;
using Owl.Overdrive.Business.Facades.Base;
using Owl.Overdrive.Repository.Contracts;

namespace Owl.Overdrive.Business.Facades
{
    public class PlatformFacade : BaseFacade, IPlatformFacade
    {
        public PlatformFacade(IRepositoryUnitOfWork repoUoW, IMapper mapper) : base(repoUoW, mapper)
        {
        }

        public async Task<List<SearchPlatformDto>> SearchPlatform(string? searchInput)
        {
            List<SearchPlatformDto> result = new List<SearchPlatformDto>();
            if (!string.IsNullOrWhiteSpace(searchInput) && searchInput.Length > 2)
            {
                var platforms = await _repoUoW.PlatformRepository.GetAllPlatforms();

                var searchResult = platforms.Where(x => x.Name.ToUpper().Contains(searchInput.ToUpper()));
                
                result = _mapper.Map<List<SearchPlatformDto>>(searchResult);
            }

            return result;
        }

        public async Task<SearchPlatformDto> RetrieveSearchValue(long searchInput)
        {
            var result = _mapper.Map<SearchPlatformDto>(await _repoUoW.PlatformRepository.GetPlatformById(searchInput));

            return result;
        }

        public async Task<SearchPlatformDto?> GetPlatform(long input)
        {
            var platform = await _repoUoW.PlatformRepository.GetPlatformById(input);
            var result = _mapper.Map<SearchPlatformDto>(platform);
            return result;
        }

    }
}
