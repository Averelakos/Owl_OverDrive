using Microsoft.AspNetCore.Http;
using Owl.Overdrive.Infrastructure.Contracts;
using Owl.Overdrive.Infrastructure.Extensions;
using System.Security.Claims;

namespace Owl.Overdrive.Infrastructure.Services
{
    public sealed class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;  
        }

        public string? Username => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Upn);

        public long UserId
        {
            get
            {
                var result = long.TryParse(_httpContextAccessor?.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value, out long userId);
                if (result)
                {
                    return userId;
                }
                else
                {
                    throw new Exception("Could not parse userId from token");
                }
            }
        }
    }
}
