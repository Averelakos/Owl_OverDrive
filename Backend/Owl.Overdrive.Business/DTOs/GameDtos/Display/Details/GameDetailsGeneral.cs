namespace Owl.Overdrive.Business.DTOs.GameDtos.Display.Details
{
    public class GameDetailsGeneral
    {
        public string? Description { get; set; }
        public List<GameDetailsGeneralPlatformsDto> PlatformsDtos { get; set; } = new();
        public GameDetailsGeneralInvolvedCompanies Companies { get; set; } = new();
        public List<string> Themes { get; set; } = new List<string>();
        public List<string> Genres { get; set; } = new List<string>();
        public List<string> GameModes { get; set; } = new List<string>();
        public List<string> PlayerPerspectives { get; set; } = new List<string>();

    }

}
