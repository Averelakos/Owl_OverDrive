using AutoMapper;
using Owl.Overdrive.Business.Contracts;
using Owl.Overdrive.Business.Facades.Base;
using Owl.Overdrive.Repository.Contracts;

namespace Owl.Overdrive.Business.Facades
{
    public class PlatformFacade : BaseFacade, IPlatformFacade
    {
        public PlatformFacade(IRepositoryUnitOfWork repoUoW, IMapper mapper) : base(repoUoW, mapper)
        {
        }

        public async Task<List<dynamic>> SearchPlatform(string searchInput)
        {
            List<dynamic> result = new List<dynamic>();
            if (!string.IsNullOrWhiteSpace(searchInput) && searchInput.Length > 2)
            {
                var list = await _repoUoW.CompanyRepository.Search(searchInput);
                //result = _mapper.Map<List<SearchParentCompanyDto>>(list);
            }

            return result;
        }

    }
}
