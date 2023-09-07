using AutoMapper;
using Owl.Overdrive.Business.Contracts;
using Owl.Overdrive.Business.Facades.Base;
using Owl.Overdrive.Repository.Contracts;
using Microsoft.AspNetCore.Http;
using Owl.Overdrive.Domain.Entities;

namespace Owl.Overdrive.Business.Facades
{
    public class ImageDraftFacade : BaseFacade, IImageDraftFacade
    {
        public ImageDraftFacade(IRepositoryUnitOfWork repoUoW, IMapper mapper) : base(repoUoW, mapper)
        {
        }

        public async Task<Guid> UpLoadImage(IFormFile imageFile)
        {
            using var ms = new MemoryStream();
            imageFile.CopyTo(ms);
            ImageDraft imageDraft = new ImageDraft()
            {
                ImageTitle = imageFile.FileName,
                ImageData = ms.ToArray()
            };

            return await _repoUoW.ImageDraftRepository.Insert(imageDraft);
        }

        public async Task DeleteImage(Guid guid)
        {
            await _repoUoW.ImageDraftRepository.DeleteImageDraft(guid);
        }
    }
}
