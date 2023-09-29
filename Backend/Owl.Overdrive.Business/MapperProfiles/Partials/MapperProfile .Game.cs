﻿using AutoMapper;
using Owl.Overdrive.Business.DTOs.GameDtos;
using Owl.Overdrive.Business.DTOs.GameDtos.Create;
using Owl.Overdrive.Business.DTOs.GameDtos.Display.Details;
using Owl.Overdrive.Business.DTOs.GameDtos.Display.Simple;
using Owl.Overdrive.Business.DTOs.GameDtos.Update;
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

            // Search 
            CreateMap<Game, SearchParentGameDto>();

            // List Game
            CreateMap<Game, GameSimpleDto>()
                .ForMember(m => m.ImageTitle, opt => opt.MapFrom(m => m.Cover != null && !string.IsNullOrEmpty( m.Cover.ImageTitle)? m.Cover.ImageTitle : null))
                .ForMember(m => m.ImageData, opt => opt.MapFrom(m => m.Cover != null && m.Cover.ImageData != null ? m.Cover.ImageData: null))
                .ForMember(m => m.ReleaseDate, opt => opt.MapFrom(m => m.ReleaseDates != null && m.ReleaseDates.Where(x => x.Date != null).OrderBy(x => x.Date).FirstOrDefault() != null? m.ReleaseDates.Where(x => x.Date != null).OrderBy(x => x.Date).FirstOrDefault().Date:null));

            // Details
            CreateMap<Game, GameDetailsDto>()
                .ForMember(m => m.FirstReleaseDate, opt => opt.MapFrom(m => m.ReleaseDates != null && m.ReleaseDates.Where(x => x.Date != null).OrderBy(x => x.Date).FirstOrDefault() != null ? m.ReleaseDates.Where(x => x.Date != null).OrderBy(x => x.Date).FirstOrDefault().Date : null));
            CreateMap<Cover, GameCoverDetailsDto>();
            CreateMap<Cover, GameBackgroundDetailsDto>();

            //Game => Update Game Dto
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

            //Update Game Dto => Game
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
        }
    }
}
