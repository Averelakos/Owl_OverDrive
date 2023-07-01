using Microsoft.AspNetCore.Http;
using Owl.Overdrive.Business.DTOs.CompanyDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
