using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Owl.Overdrive.Domain.Enums;
using Owl.Overdrive.Infrastructure.Contracts;

namespace Owl.Overdrive.Infrastructure.Filters
{
    public class AuthorizeJwtFilter : IAuthorizationFilter
    {
        private readonly ITokenProviderService _tokenProviderService;
        readonly List<EPermission> _requiredPermissions;

        public AuthorizeJwtFilter(ITokenProviderService tokenProviderService, EPermission[] requiredPermissions)
        {
            _tokenProviderService = tokenProviderService;
            _requiredPermissions = requiredPermissions?.ToList() ?? new List<EPermission>();
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string token;
            string? authHeader = context.HttpContext.Request.Headers["Authorization"];

            if ( authHeader != null && authHeader.StartsWith("Bearer ") )
            {
                token = authHeader[7..];
                var userPrincipal = _tokenProviderService.Validate(token, _requiredPermissions);

                if (userPrincipal is not null)
                {
                    context.HttpContext.User = userPrincipal;
                }
                else
                {
                    // bug : ForbidResult returns 500
                    context.Result = new StatusCodeResult(403);
                }
            }
            else
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
