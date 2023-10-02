namespace Owl.Overdrive.Business.DTOs.GameDtos.Display.Details
{
    public class GameDetailsSupportedLanguageDto
    {
        public List<long> Audio { get; set; } = new();
        public List<long> Subtitles { get; set; } = new();
        public List<long> Interface { get; set; } = new();
    }

    
}
