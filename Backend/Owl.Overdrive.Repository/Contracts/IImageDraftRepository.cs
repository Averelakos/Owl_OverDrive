using Owl.Overdrive.Domain.Entities;

namespace Owl.Overdrive.Repository.Contracts
{
    public interface IImageDraftRepository
    {
        /// <summary>
        /// Inserts the specified company.
        /// </summary>
        /// <param name="company">The company.</param>
        /// <returns></returns>
        Task<Guid> Insert(ImageDraft imageDraft);
        Task<ImageDraft?> GetImageByGuid(Guid? guid);
        Task DeleteImageDraft(Guid? guid);

    }
}
