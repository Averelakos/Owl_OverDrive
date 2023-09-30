namespace Owl.Overdrive.Business.DTOs.GameDtos.Display.Details
{
    public class GameDetailsSpellingsDto
    {
        public List<GameDetailsTitlesDto> LocalizedTitles { get; set; } = new();
        public List<GameDetailsTitlesDto> AlternativeTitles { get; set; } = new();
    }
}
