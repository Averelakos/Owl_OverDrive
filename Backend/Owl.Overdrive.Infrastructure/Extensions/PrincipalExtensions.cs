using System.Security.Claims;

namespace Owl.Overdrive.Infrastructure.Extensions
{
    public static class PrincipalExtensions
    {
        public static string? FindFirstValue(this ClaimsPrincipal principal, string claimType)
        {
            if(principal is null)
            {
                throw new ArgumentNullException(nameof(principal));
            }

            var claim = principal.FindFirst(claimType);
            return claim?.Value;
        }
    }
}
