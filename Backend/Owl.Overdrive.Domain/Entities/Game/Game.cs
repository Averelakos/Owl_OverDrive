using Owl.Overdrive.Domain.Entities.Base;
using Owl.Overdrive.Domain.Enums;

namespace Owl.Overdrive.Domain.Entities.Game
{
    public class Game : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? Story { get; set; }
        public long? UpdatedGameId { get; set; }
        public EGameType? UpdateGameType{ get; set; }
        public EGameStatus? GameStatus { get; set; }

        public virtual GameEdition? GameEdition { get; set; }
        public virtual Game? UpdatedGame { get; set; }
        public virtual List<AlternativeName> AlternativeGameTitles { get; set; } = new ();
        public virtual List<LanguageSupport> LanguageSupports { get; set; } = new ();
    }
}
