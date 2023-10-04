using Owl.Overdrive.Business.DTOs.Auth;

namespace Owl.Overdrive.Business.Contracts
{
    public interface IAuthFacade
    {
        Task<string> RegisterUser(RegisterDto registerDto);
        Task<string> Login(LoginDto loginDto);
    }
}
