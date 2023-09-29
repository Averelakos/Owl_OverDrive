import { EWebsites } from "src/app/core/enums/enum-websites"

export interface UpdateGameDto{
    id: number
    name: string
    description: string
    gameStatus: number
    story: string
    gameType: string | null
    parentGameId : number | null
    //gameEdition: CreateGameEditionDto | null
    alternativeNames: Array<UpdateAlternativeTitleDto>
    gameLocalizations: Array<UpdateGameLocalizationDto>
    gameGenres:Array<UpdateGameGenreDto>
    gameThemes:Array<UpdateGameThemeDto>
    gameModes:Array<UpdateGameModeDto>
    playerPerspectives:Array<UpdateGamePlayerPerspectiveDto>
    multiplayerModes:Array<UpdateMultiplayerModeDto>
    releaseDates: Array<UpdateReleaseDateDto>
    websites : Array<UpdateWebsite>
    involvedCompanies: Array<UpdateInvolvedCompanyDto>
    languageSupports:Array<UpdateLanguageSupportDto>
    cover: UpdateCoverDto
}

export interface UpdateCoverDto{
    imageTitle:string
    imageData: Array<number>
}

export interface UpdateGameEditionDto {
    editionTitle: string
    parentGameId:number
}

export interface UpdateAlternativeTitleDto {
    type: string
    alternativeName:string
}

export interface UpdateGameLocalizationDto {
    regionId: number
    localizedTitle:string
}

export interface UpdateGameGenreDto {
    genreId: number
}

export interface UpdateGameThemeDto {
    themeId: number
}

export interface UpdateGameModeDto {
    gameModeId: number
}

export interface UpdateGamePlayerPerspectiveDto {
    playerPerspectiveId: number
}

export interface UpdateMultiplayerModeDto {
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

export interface UpdateReleaseDateDto{
    platformId: number
    date: Date 
    regionId: number
    status: number
}

export interface UpdateWebsite {
    url: string
    category: EWebsites
}

export interface UpdateInvolvedCompanyDto {
    companyId: number
    developer: boolean
    porting: boolean
    publisher: boolean
    supporting: boolean
    platforms: Array<UpdateInvolvedCompanyPlatformDto>
}

export interface UpdateInvolvedCompanyPlatformDto {
    platformId: number
}

export interface UpdateLanguageSupportDto {
    languageId: number
    languageSupportTypeId: number
}