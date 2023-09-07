using AutoMapper;
using Owl.Overdrive.Business.DTOs.GameDtos.Create;
using Owl.Overdrive.Domain.Entities.Game;

namespace Owl.Overdrive.Business.MapperProfiles
{
    public partial class MapperProfile : Profile
    {
        public void MapGame()
        {
            CreateMap<CreateGameDto, Game>()//;
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

        }
    }
}
