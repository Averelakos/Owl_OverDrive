using Owl.Overdrive.Domain.Entities.Base;
using Owl.Overdrive.Domain.Enums;

namespace Owl.Overdrive.Domain.Entities.Game
{
    public class Websites : BaseEntity
    {
        public long GameId { get; set; }
        public string Url { get; set; } = null!;
        public EWebsiteCategory Category { get; set; }
        //public long? GameStoreLinksId { get; set; }
        //public long? GameSocialLinksId { get; set; }

        public virtual Game Game { get; set; } = null!;
        //public virtual GameStoreLinks? GameStoreLinks { get; set; }
        //public virtual GameSocialLinks? GameSocialLinks { get; set; }
    }
}
