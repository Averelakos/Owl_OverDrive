namespace Owl.Overdrive.Business.DTOs.GameDtos.Create
{
    public class CreateGameTypeDto
    {
        public string Type { get; set; } = null!;
        public long ParentGameId { get; set; }
    }
}
