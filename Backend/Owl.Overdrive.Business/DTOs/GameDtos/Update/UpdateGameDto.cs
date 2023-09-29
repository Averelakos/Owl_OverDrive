using Owl.Overdrive.Business.DTOs.GameDtos.Create;
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
        public List<UpdateAlternativeNameDto>? AlternativeNames { get; set; }
        public List<UpdateGameLocalizationDto>? GameLocalizations { get; set; }
        public List<UpdateGameGenreDto>? GameGenres { get; set; }
        public List<UpdateGameThemeDto>? GameThemes { get; set; }
        public List<UpdateGameModeDto>? GameModes { get; set; }
        public List<UpdateGamePlayerPerspectiveDto>? PlayerPerspectives { get; set; }
        public List<UpdateMultiplayerModeDto>? MultiplayerModes { get; set; }
        public List<UpdateReleaseDateDto>? ReleaseDates { get; set; }
        public List<UpdateWebsiteDto>? Websites { get; set; }
        public List<UpdateInvolvedCompanyDto>? InvolvedCompanies { get; set; }
        public List<UpdateLanguageSupportDto>? LanguageSupports { get; set; }
    }

    public class UpdateGameCoverDto
    {
        public string ImageTitle { get; set; } = null!;
        public byte[] ImageData { get; set; } = null!;
    }

    public class UpdateLanguageSupportDto
    {
        public long LanguageId { get; set; }
        public long LanguageSupportTypeId { get; set; }
    }
}
