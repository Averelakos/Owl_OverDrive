using Microsoft.AspNetCore.Http;

namespace Owl.Overdrive.Business.Contracts
{
    public interface IImageDraftFacade
    {
        /// <summary>
        /// Ups the load image.
        /// </summary>
        /// <param name="imageFile">The image file.</param>
        /// <returns></returns>
        Task<Guid> UpLoadImage(IFormFile imageFile);
        Task DeleteImage(Guid guid);
    }
}
