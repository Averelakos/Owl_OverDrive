using Owl.Overdrive.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace Owl.Overdrive.Domain.Entities
{
    public class ImageDraft : BaseEntity
    {

        public new Guid Id { get; set; }
        /// <summary>
        /// Image File name.
        /// </summary>
        public string ImageTitle { get; set; } = null!;
        /// <summary>
        /// Image data.
        /// </summary>
        public byte[] ImageData { get; set; } = null!;

    }
}
