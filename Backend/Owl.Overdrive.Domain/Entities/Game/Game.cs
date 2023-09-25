using Owl.Overdrive.Domain.Entities.Base;
using Owl.Overdrive.Domain.Enums;

namespace Owl.Overdrive.Domain.Entities.Game
{
    public class Game : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? Story { get; set; }
        public long? ParentGameId { get; set; }
        public EGameType? GameType{ get; set; }
        public EGameStatus? GameStatus { get; set; }
        public long? CoverId { get; set; }

        public virtual Game? ParentGame { get; set; }
        public virtual List<AlternativeName> AlternativeGameTitles { get; set; } = new();
        public virtual List<Localization> Localizations { get; set; } = new();
        public virtual List<ReleaseDate> ReleaseDates { get; set; } = new();
        public virtual List<Website> Websites { get; set; } = new();
        public virtual List<InvolvedCompany> InvolvedCompanies { get; set;} = new();
        public virtual List<LanguageSupport> LanguageSupports { get; set; } = new();
        public virtual List<GameGameMode> GameGameModes { get; set; } = new();
        public virtual List<GamePlayerPerspective> GamePlayerPerspectives { get; set; } = new();
        public virtual List<MultiplayerMode> MultiplayerModes { get; set; } = new();
        public virtual List<GameTheme> GameThemes { get; set; } = new();
        public virtual List<GameGenre> GameGenres { get; set; } = new();
        public virtual Cover? Cover { get; set; }
    }
}
