using Microsoft.AspNetCore.Mvc;
using Owl.Overdrive.Business.Contracts;
using Owl.Overdrive.Business.DTOs.Auth;

namespace Owl.Overdrive.Controllers
{
    public class AuthController : BaseApiController
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IAuthFacade _authFacade;

        public AuthController(ILogger<AuthController> logger, IAuthFacade authFacade) : base(logger)
        {
            _logger = logger;
            _authFacade = authFacade;
        }

        [HttpPost("register")]
        public async Task<ActionResult<string>> Register([FromBody] RegisterDto registerDto)
        {
            var result = await  _authFacade.RegisterUser(registerDto);
            return Ok(new { Token = result });
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> login([FromBody] LoginDto loginDto)
        {
            var result = await _authFacade.Login(loginDto);

            if(string.IsNullOrWhiteSpace(result))
            {
                return BadRequest();
            }

            return Ok(new { Token = result });
        }
    }
}