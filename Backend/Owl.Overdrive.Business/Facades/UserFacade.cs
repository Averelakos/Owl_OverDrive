using AutoMapper;
using Owl.Overdrive.Business.Contracts;
using Owl.Overdrive.Business.DTOs.User.Display;
using Owl.Overdrive.Business.Facades.Base;
using Owl.Overdrive.Repository.Contracts;

namespace Owl.Overdrive.Business.Facades
{
    public class UserFacade : BaseFacade, IUserFacade
    {
        public UserFacade(IRepositoryUnitOfWork repoUoW, IMapper mapper) : base(repoUoW, mapper)
        {
        }
  
        public async Task<List<UserSimpleDto>> GetAllUserWithRoles()
        {
            var listUser = await _repoUoW.UserRepository.GetAllUserWithRoles();

            return _mapper.Map<List<UserSimpleDto>>(listUser);
        }
    }
}
