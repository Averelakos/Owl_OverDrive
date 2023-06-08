using Microsoft.AspNetCore.Mvc;

namespace Owl.Overdrive.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        
        public BaseApiController(ILogger<BaseApiController> logger)
        {
        }
    }
}