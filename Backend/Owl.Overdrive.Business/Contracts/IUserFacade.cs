using Owl.Overdrive.Business.DTOs.User.Display;

namespace Owl.Overdrive.Business.Contracts
{
    public interface IUserFacade
    {
        Task<List<UserSimpleDto>> GetAllUserWithRoles();
    }
}
