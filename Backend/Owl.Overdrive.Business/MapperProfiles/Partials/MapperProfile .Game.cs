using AutoMapper;
using Owl.Overdrive.Business.DTOs.GameDtos.Create;
using Owl.Overdrive.Business.DTOs.GameDtos.Display.Simple;
using Owl.Overdrive.Domain.Entities.Game;

namespace Owl.Overdrive.Business.MapperProfiles
{
    public partial class MapperProfile : Profile
    {
        public void MapGame()
        {
            // Create Game
            CreateMap<CreateGameDto, Game>()
                .ForMember(m => m.AlternativeGameTitles, opt => opt.MapFrom(m => m.AlternativeNames))
                .ForMember(m => m.Cover, opt => opt.Ignore());
            CreateMap<CreateGameEditionDto, GameEdition>();
            CreateMap<CreativeAlternativeNameDto, AlternativeName>()
                .ForMember(m => m.Name, opt => opt.MapFrom(m => m.AlternativeName));
            CreateMap<CreateGameLocalizationDto, Localization>();
            CreateMap<CreateGameGenreDto, GameGenre>();
            CreateMap<CreateGameThemeDto, GameTheme>();
            CreateMap<CreateGameModeDto, GameGameMode>();
            CreateMap<CreateGamePlayerPerspectiveDto, GamePlayerPerspective>();
            CreateMap<CreateMultiplayerModeDto, MultiplayerMode>();
            CreateMap<CreateReleaseDateDto, ReleaseDate>();
            CreateMap<CreateWebsiteDto, Website>();
            CreateMap<CreateInvolvedCompanyDto, InvolvedCompany>();
            CreateMap<CreateLanguageSupportDto, LanguageSupport>();

            // List Game
            CreateMap<Game, GameSimpleDto>()
                .ForMember(m => m.ImageTitle, opt => opt.MapFrom(m => m.Cover != null && !string.IsNullOrEmpty( m.Cover.ImageTitle)? m.Cover.ImageTitle : null))
                .ForMember(m => m.ImageData, opt => opt.MapFrom(m => m.Cover != null && m.Cover.ImageData != null ? m.Cover.ImageData: null))
                .ForMember(m => m.ReleaseDate, opt => opt.MapFrom(m => m.ReleaseDates != null && m.ReleaseDates.Where(x => x.Date != null).OrderBy(x => x.Date).FirstOrDefault() != null? m.ReleaseDates.Where(x => x.Date != null).OrderBy(x => x.Date).FirstOrDefault().Date:null));

        }
    }
}
