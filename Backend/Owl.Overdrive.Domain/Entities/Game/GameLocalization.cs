using Owl.Overdrive.Domain.Entities.Base;

namespace Owl.Overdrive.Domain.Entities.Game
{
    public class GameLocalization :  BaseEntity
    {
        public long RegionId { get; set; }
        public long GameId { get; set; }
        public string LocalizedTitle { get; set; } = null!;

        public virtual Region Region { get; set; } = null!;
        public virtual Game Game{ get; set; } = null!;
    }
}
