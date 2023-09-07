using Owl.Overdrive.Domain.Entities.Base;

namespace Owl.Overdrive.Domain.Entities.Game
{
    public class Cover : BaseEntity
    {
        public string ImageTitle { get; set; } = null!;
        public byte[] ImageData { get; set; } = null!;

    }
}
