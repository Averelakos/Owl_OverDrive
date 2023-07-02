using Microsoft.EntityFrameworkCore;
using Owl.Overdrive.Domain.Entities;
using Owl.Overdrive.Infrastructure.Persistence.DbContexts;
using Owl.Overdrive.Repository.Contracts;

namespace Owl.Overdrive.Repository.Repositories
{
    public class ImageDraftRepository : BaseRepository<ImageDraft>, IImageDraftRepository
    {
        public ImageDraftRepository(OwlOverdriveDbContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// Inserts the specified company.
        /// </summary>
        /// <param name="company">The company.</param>
        /// <returns></returns>
        public async Task<Guid> Insert(ImageDraft imageDraft)
        {
            var result =  await base.Insert(imageDraft);
            return result.GuiId;
        }

        public async Task<ImageDraft?> GetImageByGuid(Guid guid)
        {
            try
            {
                var result = await _DbSet.FirstOrDefaultAsync(x => x.GuiId == guid);
                if (result is null)
                    throw new ArgumentNullException(nameof(result), message: "Image draft entrie doesn't exits");
                return result;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(message: $"An error occured in the Image draft repo {ex.Message}");
            } 
            
        }

        public async Task DeleteImageDraft(Guid guid)
        {
            var entry = await _DbSet.FirstOrDefaultAsync(x => x.GuiId == guid);

            if (entry is null)
                return;

            _dbContext.Remove(entry);
            await _dbContext.SaveChangesAsync();
            
        }

    }
}
