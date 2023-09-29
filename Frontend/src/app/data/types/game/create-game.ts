import { EWebsites } from "src/app/core/enums/enum-websites"
import { FileParameter } from "../image/file-parameter"

export interface CreateGameDto{
    name: string
    description: string
    gameStatus: number
    story: string
    gameType: string | null
    parentGameId : number | null
    //gameEdition: CreateGameEditionDto | null
    alternativeNames: Array<CreateAlternativeTitleDto>
    gameLocalizations: Array<CreateGameLocalizationDto>
    gameGenres:Array<CreateGameGenreDto>
    gameThemes:Array<CreateGameThemeDto>
    gameModes:Array<CreateGameModeDto>
    playerPerspectives:Array<CreateGamePlayerPerspectiveDto>
    multiplayerModes:Array<CreateMultiplayerModeDto>
    releaseDates: Array<CreateReleaseDateDto>
    websites : Array<CreateWebsite>
    involvedCompanies: Array<CreateInvolvedCompanyDto>
    languageSupports:Array<CreateLanguageSupportDto>
    cover: CreateImageDto | null
}

export interface CreateImageDto{
    imageTitle:string
    imageData: Array<number>
}

export interface CreateGameEditionDto {
    editionTitle: string
    parentGameId:number
}

export interface CreateAlternativeTitleDto {
    type: string
    alternativeName:string
}

export interface CreateGameLocalizationDto {
    regionId: number
    localizedTitle:string
}

export interface CreateGameGenreDto {
    genreId: number
}

export interface CreateGameThemeDto {
    themeId: number
}

export interface CreateGameModeDto {
    gameModeId: number
}

export interface CreateGamePlayerPerspectiveDto {
    playerPerspectiveId: number
}

export interface CreateMultiplayerModeDto {
    campaignCoop: boolean
    dropIn: boolean
    lanCoop: boolean
    offlineCoop: boolean
    offlineCoopMax: number
    offlineMax : number
    onlineCoop: boolean
    onlineCoopMax: number
    onlineMax : number
    splitScreen: boolean
    splitScreenOnline : boolean
    platformId : number
}

export interface CreateReleaseDateDto{
    platformId: number
    date: Date 
    regionId: number
    status: number
}

export interface CreateWebsite {
    url: string
    category: EWebsites
}

export interface CreateInvolvedCompanyDto {
    companyId: number
    developer: boolean
    porting: boolean
    publisher: boolean
    supporting: boolean
    platforms: Array<CreateInvolvedCompanyPlatformDto>
}

export interface CreateInvolvedCompanyPlatformDto {
    platformId: number
}

export interface CreateLanguageSupportDto {
    languageId: number
    languageSupportTypeId: number
}