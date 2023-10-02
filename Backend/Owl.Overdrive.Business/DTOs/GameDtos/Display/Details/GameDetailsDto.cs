using Owl.Overdrive.Domain.Enums;

namespace Owl.Overdrive.Business.DTOs.GameDtos.Display.Details
{
    public class GameDetailsDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Story { get; set; }
        public DateTime? FirstReleaseDate { get; set; }
        public string? Publisher { get; set; }
        public GameDetailsGeneral Details { get; set; } = new();
        public List<GameDetailsMultiplayerModeDto> MultiplayerModes { get; set; } = new();
        public GameDetailsSpellingsDto Spellings { get; set; } = new();
        public List<GameDetailsWebsiteDto> Websites { get; set; } = new();
        public GameDetailsSupportedLanguageDto Supportedlanguages { get; set; } = new();
        public List<GameDetailsPlatformReleasedDatesDto> PlatformsReleaseDates { get; set; } = new();
        public GameCoverDetailsDto? Cover { get; set; }
        public GameBackgroundDetailsDto? Background { get; set; }
    }

    public class GameDetailsPlatformReleasedDatesDto
    {
        public string PlatformName { get; set; } = null!;
        public List<GameDetailsReleasedDateDto> ReleaseDates { get; set; } = new();
    }

    public class GameDetailsReleasedDateDto
    {
        public DateTime? Date { get; set; }
        public long? RegionId { get; set; }
        public EGameStatus? Status { get; set; }
    }

    
}
