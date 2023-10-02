using AutoMapper;
using Owl.Overdrive.Business.DTOs.GameDtos;
using Owl.Overdrive.Business.DTOs.GameDtos.Create;
using Owl.Overdrive.Business.DTOs.GameDtos.Display.Details;
using Owl.Overdrive.Business.DTOs.GameDtos.Display.Simple;
using Owl.Overdrive.Business.DTOs.GameDtos.Update;
using Owl.Overdrive.Domain.Entities;
using Owl.Overdrive.Domain.Entities.Company;
using Owl.Overdrive.Domain.Entities.Game;
using Owl.Overdrive.Domain.Enums;
using Owl.Overdrive.Domain.Utilities;
using Owl.Overdrive.Infrastructure.Helpers;
using System.ComponentModel;
using System.Reflection.Metadata;

namespace Owl.Overdrive.Business.MapperProfiles
{
    public partial class MapperProfile : Profile
    {
        public void MapGame()
        {
            #region Create Game
            CreateMap<CreateGameDto, Game>()
                .ForMember(m => m.AlternativeGameTitles, opt => opt.MapFrom(m => m.AlternativeNames))
                .ForMember(m => m.Cover, opt => opt.MapFrom(m => m.Cover))
                .ForMember(m => m.Localizations, opt => opt.MapFrom(m => m.GameLocalizations))
                .ForMember(m => m.GameGameModes, opt => opt.MapFrom(m => m.GameModes))
                .ForMember(m => m.GamePlayerPerspectives, opt => opt.MapFrom(m => m.PlayerPerspectives));
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
            CreateMap<CreateInvolvedCompanyDto, InvolvedCompany>()
                .ForMember(m => m.GameInvolvedCompanyPlatforms, opt => opt.MapFrom(m => m.Platforms));
            CreateMap<CreateInvolvedCompanyPlatformDto, InvolvedCompanyPlatform>();
            CreateMap<CreateLanguageSupportDto, LanguageSupport>();
            CreateMap<CreateImageDto, Cover>();
            #endregion Create Game

            # region Game => Update Game Dto
            CreateMap<Game, UpdateGameDto>()
                .ForMember(m => m.AlternativeNames, opt => opt.MapFrom(m => m.AlternativeGameTitles))
                .ForMember(m => m.GameLocalizations, opt => opt.MapFrom(m => m.Localizations))
                .ForMember(m => m.GameModes, opt => opt.MapFrom(m => m.GameGameModes))
                .ForMember(m => m.PlayerPerspectives, opt => opt.MapFrom(m => m.GamePlayerPerspectives));
            CreateMap<Cover, UpdateGameCoverDto>();
            CreateMap<AlternativeName, UpdateAlternativeNameDto>()
                .ForMember(m => m.AlternativeName, opt => opt.MapFrom(m => m.Name));
            CreateMap<Localization, UpdateGameLocalizationDto>();
            CreateMap<GameGenre, UpdateGameGenreDto>();
            CreateMap<GameTheme, UpdateGameThemeDto>();
            CreateMap<GameGameMode, UpdateGameModeDto>();
            CreateMap<GamePlayerPerspective, UpdateGamePlayerPerspectiveDto>();
            CreateMap<MultiplayerMode, UpdateMultiplayerModeDto>();
            CreateMap<ReleaseDate, UpdateReleaseDateDto>();
            CreateMap<Website, UpdateWebsiteDto>();
            CreateMap<InvolvedCompany, UpdateInvolvedCompanyDto>()
                .ForMember(m => m.Platforms, opt => opt.MapFrom(m => m.GameInvolvedCompanyPlatforms));
            CreateMap<InvolvedCompanyPlatform, UpdateInvolvedCompanyPlatformDto>();
            CreateMap<LanguageSupport, UpdateLanguageSupportDto>();
            CreateMap<Cover, UpdateGameCoverDto>();
            #endregion Game => Update Game Dto

            # region Update Game Dto => Game
            CreateMap<UpdateGameDto, Game>()
                .ForMember(m => m.AlternativeGameTitles, opt => opt.MapFrom(m => m.AlternativeNames))
                .ForMember(m => m.Localizations, opt => opt.MapFrom(m => m.GameLocalizations))
                .ForMember(m => m.GameGameModes, opt => opt.MapFrom(m => m.GameModes))
                .ForMember(m => m.GamePlayerPerspectives, opt => opt.MapFrom(m => m.PlayerPerspectives));
            CreateMap<UpdateGameCoverDto, Cover>();
            CreateMap<UpdateAlternativeNameDto, AlternativeName>()
                .ForMember(m => m.Name, opt => opt.MapFrom(m => m.AlternativeName));
            CreateMap<UpdateGameLocalizationDto, Localization>();
            CreateMap<UpdateGameGenreDto, GameGenre>();
            CreateMap<UpdateGameThemeDto, GameTheme>();
            CreateMap<UpdateGameModeDto, GameGameMode>();
            CreateMap<UpdateGamePlayerPerspectiveDto, GamePlayerPerspective>();
            CreateMap<UpdateMultiplayerModeDto, MultiplayerMode>();
            CreateMap<UpdateReleaseDateDto, ReleaseDate>();
            CreateMap<UpdateWebsiteDto, Website>();
            CreateMap<UpdateInvolvedCompanyDto, InvolvedCompany>()
                .ForMember(m => m.GameInvolvedCompanyPlatforms, opt => opt.MapFrom(m => m.Platforms));
            CreateMap<UpdateInvolvedCompanyPlatformDto, InvolvedCompanyPlatform>();
            CreateMap<UpdateLanguageSupportDto, LanguageSupport>();
            CreateMap<UpdateGameCoverDto, Cover>();
            # endregion Update Game Dto => Game

            # region Search 
            CreateMap<Game, SearchParentGameDto>();
            # endregion Search 

            # region List Game
            CreateMap<Game, GameSimpleDto>()
                .ForMember(m => m.ImageTitle, opt => opt.MapFrom(m => m.Cover != null && !string.IsNullOrEmpty(m.Cover.ImageTitle) ? m.Cover.ImageTitle : null))
                .ForMember(m => m.ImageData, opt => opt.MapFrom(m => m.Cover != null && m.Cover.ImageData != null ? m.Cover.ImageData : null))
                .ForMember(m => m.ReleaseDate, opt => opt.MapFrom(m => m.ReleaseDates != null && m.ReleaseDates.Where(x => x.Date != null).OrderBy(x => x.Date).FirstOrDefault() != null ? m.ReleaseDates.Where(x => x.Date != null).OrderBy(x => x.Date).FirstOrDefault().Date : null));
            # endregion List Game

            # region Details
            CreateMap<Game, GameDetailsDto>()
                .ForMember(dest => dest.Publisher, opt => opt.MapFrom(m => m.InvolvedCompanies.Where(x => x.Publisher).Select(x => x.Company.Name).FirstOrDefault()))
                .ForMember(m => m.FirstReleaseDate, opt => opt.MapFrom(m => m.ReleaseDates != null && m.ReleaseDates.Where(x => x.Date != null).OrderBy(x => x.Date).FirstOrDefault() != null ? m.ReleaseDates.Where(x => x.Date != null).OrderBy(x => x.Date).FirstOrDefault().Date : null))
                .ForPath(m => m.Details.Companies.Developer, opt => opt.MapFrom(m => m.InvolvedCompanies.Where(x =>x.Developer).Select(x => x.Company).ToList()))
                .ForPath(m => m.Details.Companies.Publisher, opt => opt.MapFrom(m => m.InvolvedCompanies.Where(x => x.Publisher).Select(x => x.Company).ToList()))
                .ForPath(m => m.Details.Companies.Supporting, opt => opt.MapFrom(m => m.InvolvedCompanies.Where(x => x.Supporting).Select(x => x.Company).ToList()))
                .ForPath(m => m.Details.Companies.Porting, opt => opt.MapFrom(m => m.InvolvedCompanies.Where(x => x.Porting).Select(x => x.Company).ToList()))
                .ForPath(dest => dest.Details.PlatformsDtos, opt => opt.MapFrom(m => m.ReleaseDates.Select(x =>x.Platform).ToList()))
                .ForPath(dest => dest.Details.Themes, opt => opt.MapFrom(m => m.GameThemes.Select(x => x.Theme.Name).ToList()))
                .ForPath(dest => dest.Details.Genres, opt => opt.MapFrom(m => m.GameGenres.Select(x => x.Genre.Name).ToList()))
                .ForPath(dest => dest.Details.Description, opt => opt.MapFrom(m => m.Description))
                .ForPath(dest => dest.Details.GameModes, opt => opt.MapFrom(m => m.GameGameModes.Select(x => x.GameMode.Name).ToList()))
                .ForPath(dest => dest.Details.PlayerPerspectives, opt => opt.MapFrom(m => m.GamePlayerPerspectives.Select(x => x.PlayerPerspective.Name).ToList()))
                
                //.ForPath(dest => dest.MultiplayerModes, opt => opt.MapFrom(m => m.MultiplayerModes.ToList()))
                //.ForPath(dest => dest.Spellings.LocalizedTitles, opt => opt.MapFrom(m => m.Localizations.ToList()))
                //.ForPath(dest => dest.Spellings.AlternativeTitles, opt => opt.MapFrom(m => m.AlternativeGameTitles.ToList()))
                .ForMember(dest => dest.Websites, opt => opt.MapFrom(m => m.Websites))
                //.ForPath(dest => dest.Supportedlanguages.Audio, opt => opt.MapFrom(m => m.LanguageSupports.Where(x => x.LanguageSupportTypeId == 1).Select(x => x.Language.Name)))
                //.ForPath(dest => dest.Supportedlanguages.Subtitles, opt => opt.MapFrom(m => m.LanguageSupports.Where(x => x.LanguageSupportTypeId == 2).Select(x => x.Language.Name)))
                //.ForPath(dest => dest.Supportedlanguages.Interface, opt => opt.MapFrom(m => m.LanguageSupports.Where(x => x.LanguageSupportTypeId == 3).Select(x => x.Language.Name)))
                ;
            CreateMap<Company, GameDetailsGeneralCompany>();
            CreateMap<Platform, GameDetailsGeneralPlatformsDto>();
            CreateMap<MultiplayerMode, GameDetailsMultiplayerModeDto>()
                .ForMember(dest => dest.PlatformName, opt => opt.MapFrom(m => m.Platform.Name))
                ;
            CreateMap<Localization, GameDetailsTitlesDto>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(m => m.LocalizedTitle))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(m => m.Region.Name))
                ;
            CreateMap<AlternativeName, GameDetailsTitlesDto>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(m => m.Name))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(m => m.Type))
                ;
            CreateMap<List<LanguageSupport>, GameDetailsSupportedLanguageDto>()
                .ForMember(dest => dest.Audio, opt =>
                {
                    //opt.PreCondition(m => m.Where() == 1);
                    opt.MapFrom(m => m.Where(x => x.LanguageSupportTypeId == 1).Select(x => x.LanguageId).ToList());
                })
                .ForMember(dest => dest.Subtitles, opt => opt.MapFrom(m => m.Where(x => x.LanguageSupportTypeId == 2).Select(x => x.LanguageId).ToList()))
                .ForMember(dest => dest.Interface, opt => opt.MapFrom(m => m.Where(x => x.LanguageSupportTypeId == 3).Select(x => x.LanguageId).ToList()))
                ;
            CreateMap<Website, GameDetailsWebsiteDto>();
            CreateMap<Cover, GameCoverDetailsDto>();
            CreateMap<Cover, GameBackgroundDetailsDto>();
            # endregion Details
        }
    }
}
