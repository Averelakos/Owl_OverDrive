namespace Owl.Overdrive.Business.DTOs.GameDtos.Create
{
    public class CreateGameEditionDto
    {
        public long ParentGameId { get; set; }
        public string EditionTitle { get; set; } = null!;
    }
}
