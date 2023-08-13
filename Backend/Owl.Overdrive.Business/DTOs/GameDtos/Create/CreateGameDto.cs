using Owl.Overdrive.Domain.Enums;

namespace Owl.Overdrive.Business.DTOs.GameDtos.Create
{
    public class CreateGameDto
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? Story { get; set; }
        //public Guid GameCover { get; set; }
        public EGameStatus? GameStatus { get; set; }
        public long? UpdatedGameId { get; set; }
        public EGameType? UpdateGameType { get; set; }
        public CreateGameEditionDto? GameEdition { get; set; }
        public List<CreativeAlternativeTitleDto>? AlternativeNames{ get; set; }
    }
}
