using Microsoft.AspNetCore.Mvc;
using Owl.Overdrive.Infrastructure.Filters;

namespace Owl.Overdrive.Infrastructure.Attributes
{
    public class AuthorizeJwtAttribute : TypeFilterAttribute
    {
        public AuthorizeJwtAttribute() : base(typeof(AuthorizeJwtFilter))
        {
        }
    }
}
