using Microsoft.AspNetCore.Mvc;

namespace Owl.Overdrive.Controllers
{
    public class AuthController : BaseApiController
    {
        private readonly ILogger<AuthController> _logger;

        public AuthController(ILogger<AuthController> logger) : base(logger)
        {
            _logger = logger;
        }
    }
}