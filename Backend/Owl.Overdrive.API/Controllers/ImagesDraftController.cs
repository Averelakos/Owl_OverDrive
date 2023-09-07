using Microsoft.AspNetCore.Mvc;
using Owl.Overdrive.Business.Contracts;

namespace Owl.Overdrive.Controllers
{
    public class ImagesDraftController : BaseApiController
    {
        private readonly ILogger<ImagesDraftController> _logger;
        private readonly IImageDraftFacade _imageDraftFacade;

        public ImagesDraftController(ILogger<ImagesDraftController> logger, IImageDraftFacade imageDraftFacade) : base(logger)
        {
            _logger = logger;
            _imageDraftFacade = imageDraftFacade;
        }

        [HttpPost("UploadImage")]
        public async Task<ActionResult<Guid>> Upload(IFormFile image)
        {
            var result = await _imageDraftFacade.UpLoadImage(image);
            return Ok(result);
        }

        [HttpPost("DeleteImage")]
        public async Task<ActionResult<Guid>> Delete(Guid guid)
        {
            await _imageDraftFacade.DeleteImage(guid);
            return Ok();
        }
    }
}