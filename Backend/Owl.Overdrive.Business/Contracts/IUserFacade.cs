using Owl.Overdrive.Business.DTOs.ServiceResults;
using Owl.Overdrive.Business.DTOs.User.Display;

namespace Owl.Overdrive.Business.Contracts
{
    public interface IUserFacade
    {
        Task<ServiceSearchResultData<List<UserSimpleDto>>> GetAllUserWithRoles(RequestGetUserByRole request);
        Task<UserSimpleDto> GetUserById(long userId);
        Task<UserSimpleDto> UpdateUserRole(UserSimpleDto userSimpleDto);
    }
}
