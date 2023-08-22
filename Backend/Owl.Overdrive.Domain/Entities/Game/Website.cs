using Owl.Overdrive.Domain.Entities.Base;
using Owl.Overdrive.Domain.Enums;

namespace Owl.Overdrive.Domain.Entities.Game
{
    public class Website : BaseEntity
    {
        public long GameId { get; set; }
        public string Url { get; set; } = null!;
        public EWebsiteCategory Category { get; set; }


        public virtual Game Game { get; set; } = null!;
    }
}
