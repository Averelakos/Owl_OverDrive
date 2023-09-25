using Owl.Overdrive.Domain.Enums;

namespace Owl.Overdrive.Business.DTOs.GameDtos.Update
{
    public class UpdateGameDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? Story { get; set; }
        public EGameStatus? GameStatus { get; set; }
        public long? ParentGameId { get; set; }
        public EGameType? GameType { get; set; }
        public UpdateGameCoverDto? Cover { get; set; }

    }

    public class UpdateGameCoverDto
    {
        public string ImageTitle { get; set; } = null!;
        public byte[] ImageData { get; set; } = null!;
    }
}
