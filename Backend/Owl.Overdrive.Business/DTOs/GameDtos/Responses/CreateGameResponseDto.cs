namespace Owl.Overdrive.Business.DTOs.GameDtos.Responses
{
    public class CreateGameResponseDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;

        public CreateGameResponseDto(long id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
