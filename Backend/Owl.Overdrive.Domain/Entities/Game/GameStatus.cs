using Owl.Overdrive.Domain.Entities.Base;

namespace Owl.Overdrive.Domain.Entities.Game
{
    public class GameStatus : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}
