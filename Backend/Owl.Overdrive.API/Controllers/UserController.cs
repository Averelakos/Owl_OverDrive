using Microsoft.AspNetCore.Mvc;
using Owl.Overdrive.Business.Contracts;
using Owl.Overdrive.Business.DTOs.ServiceResults;
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

        [HttpPost("GetAllUsersWithRoles")]
        public async Task<ActionResult<ServiceSearchResultData<List<UserSimpleDto>>>> GetAllUsersWithRoles([FromBody] RequestGetUserByRole request)
        {
            var result = await _userFacade.GetAllUserWithRoles(request);
            return Ok(result);
        }

        [HttpGet("GetUserById")]
        public async Task<ActionResult<UserSimpleDto>> GetUserById([FromQuery] long userId)
        {
            var result = await _userFacade.GetUserById(userId);
            return Ok(result);
        }

        [HttpPost("UpdateUserRole")]
        public async Task<ActionResult<UserSimpleDto>> UpdateUserRole([FromBody] UserSimpleDto userSimpleDto)
        {
            var result = await _userFacade.UpdateUserRole(userSimpleDto);
            return Ok(result);
        }

    }
}