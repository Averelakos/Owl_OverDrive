using Owl.Overdrive.Domain.Entities.Auth;
using Owl.Overdrive.Domain.Entities.Base;

namespace Owl.Overdrive.Domain.Entities.Game
{
    public class UserReview: BaseEntity
    {
        public string? Review { get; set; }
        public long Score { get; set; }
        public long UserId { get; set; }
        public long GameId { get; set; }

        public virtual User User{ get; set; } = null!;
        public virtual Game Game { get; set; } = null!;
    }
}
