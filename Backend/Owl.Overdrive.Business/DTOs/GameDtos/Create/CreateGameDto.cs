using Owl.Overdrive.Domain.Enums;

namespace Owl.Overdrive.Business.DTOs.GameDtos.Create
{
    public class CreateGameDto
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? Story { get; set; }
        public EGameStatus? GameStatus { get; set; }
        public long? ParentGameId { get; set; }
        public EGameType? GameType { get; set; }
        public CreateGameEditionDto? GameEdition { get; set; }
        public List<CreativeAlternativeNameDto>? AlternativeNames{ get; set; }
        public List<CreateGameLocalizationDto>? GameLocalizations { get; set; }
        public List<CreateGameGenreDto>? GameGenres { get; set; }
        public List<CreateGameThemeDto>? GameThemes { get; set; }
        public List<CreateGameModeDto>? GameModes { get; set; }
        public List<CreateGamePlayerPerspectiveDto>? PlayerPerspectives { get; set; }
        public List<CreateMultiplayerModeDto>? MultiplayerModes { get; set; }
        public List<CreateReleaseDateDto>? ReleaseDates { get; set; }
        public List<CreateWebsiteDto>? Websites { get; set; }
        public List<CreateInvolvedCompanyDto>? InvolvedCompanies { get; set; }
        public List<CreateLanguageSupportDto>? LanguageSupports { get; set; }
        //public Guid? Cover { get; set; }

        public CreateImageDto? Cover { get; set; }
    }

    public class CreateImageDto 
    {
        public string ImageTitle { get; set; } = null!;
        public byte[] ImageData { get; set; } = null!;
    }
}
