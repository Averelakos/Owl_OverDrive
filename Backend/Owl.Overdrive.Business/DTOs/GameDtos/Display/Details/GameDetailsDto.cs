namespace Owl.Overdrive.Business.DTOs.GameDtos.Display.Details
{
    public class GameDetailsDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? Story { get; set; }
        public DateTime? FirstReleaseDate { get; set; }
        public string? Publisher { get; set; }

        public GameCoverDetailsDto? Cover { get; set; }
        public GameBackgroundDetailsDto? Background { get; set; }
    }
}
