using Owl.Overdrive.Domain.Entities.Base;

namespace Owl.Overdrive.Domain.Entities.Game
{
    public class Screenshot : BaseEntity
    {
        public long GameId { get; set; }
        public bool IsBackground { get; set; } = false;
        public string ImageTitle { get; set; } = null!;
        public byte[] ImageData { get; set; } = null!;

        public virtual Game Game { get; set; } = null!;
    }
}
