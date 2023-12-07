using Microsoft.AspNetCore.Mvc;
using Owl.Overdrive.Domain.Enums;
using Owl.Overdrive.Infrastructure.Filters;

namespace Owl.Overdrive.Infrastructure.Attributes
{
    public class AuthorizeJwtAttribute : TypeFilterAttribute
    {
        public AuthorizeJwtAttribute(params EPermission[] permissions) : base(typeof(AuthorizeJwtFilter))
        {
            Arguments = new object[] { permissions };
        }
    }
}
