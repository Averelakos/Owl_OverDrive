using Owl.Overdrive.Domain.Entities.Auth;
using System.Security.Claims;

namespace Owl.Overdrive.Infrastructure.Contracts
{
    public interface ITokenProviderService
    {
        public string Create(User user, List<string> roles, List<string> permissions);
        ClaimsPrincipal? Validate(string token);
    }
}
