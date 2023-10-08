using Microsoft.AspNetCore.Mvc;
using Owl.Overdrive.Business.Contracts;
using Owl.Overdrive.Business.DTOs.User.Display;

namespace Owl.Overdrive.Controllers
{
    public class UserController : BaseApiController
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserFacade _userFacade;

        public UserController(ILogger<UserController> logger, IUserFacade userFacade) : base(logger)
        {
            _logger = logger;
            _userFacade = userFacade;
        }

        [HttpGet("GetAllUsersWithRoles")]
        public async Task<ActionResult<List<UserSimpleDto>>> GetAllUsersWithRoles()
        {
            var result = await _userFacade.GetAllUserWithRoles();
            return Ok(result);
        }

    }
}