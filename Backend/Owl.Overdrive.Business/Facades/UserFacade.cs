using AutoMapper;
using Owl.Overdrive.Business.Contracts;
using Owl.Overdrive.Business.DTOs.ServiceResults;
using Owl.Overdrive.Business.DTOs.User.Display;
using Owl.Overdrive.Business.Facades.Base;
using Owl.Overdrive.Business.Services;
using Owl.Overdrive.Domain.Entities.Auth;
using Owl.Overdrive.Repository.Contracts;

namespace Owl.Overdrive.Business.Facades
{
    public class UserFacade : BaseFacade, IUserFacade
    {
        public UserFacade(IRepositoryUnitOfWork repoUoW, IMapper mapper) : base(repoUoW, mapper)
        {
        }
  
        public async Task<ServiceSearchResultData<List<UserSimpleDto>>> GetAllUserWithRoles(RequestGetUserByRole request)
        {
            List<UserSimpleDto> source = new List<UserSimpleDto>();
            var listUser = await _repoUoW.UserRepository.GetAllUserWithRoles();

            source =  _mapper.Map<List<UserSimpleDto>>(listUser);

            if (request.Role is not null)
            {
                source = source.Where(x => x.RoleId == (long)request.Role).ToList();
            }

            var queryableSource = source.AsQueryable();

            var dataDesult = await new DataLoaderService<UserSimpleDto>(queryableSource, request.Options).LoadResult();

            ServiceSearchResultData<List<UserSimpleDto>> result = new();

            if (dataDesult.Data is not null)
            {
                result.Result = dataDesult.Data.ToList();
                result.TotalCount = dataDesult.TotalCount;
                result.TotalPages = dataDesult.TotalPages;
                return result;
            }
            else
            {
                result.Result = new List<UserSimpleDto>();
                return result;
            }
        }

        public async Task<UserSimpleDto> GetUserById(long userId)
        {
            var user = await _repoUoW.UserRepository.GetUserWithRoleAsNo(userId);

            return _mapper.Map<UserSimpleDto>(user);
        }

        public async Task<UserSimpleDto> UpdateUserRole(UserSimpleDto userSimpleDto)
        {
            var user = await _repoUoW.UserRepository.GetUserWithRole(userSimpleDto.Id);

            //if (user is null)
            //    return null;

            //_mapper.Map<UserSimpleDto, User>(userSimpleDto, user);

            user.Roles[0].RoleId = userSimpleDto.RoleId;

            await _repoUoW.UserRepository.SaveChangesAsync();

            return userSimpleDto;
        }
    }
}
