import { EWebsites } from "src/app/core/enums/enum-websites"

export interface GameDetailsDto {
    id: number
    name: string 
    firstReleaseDate: Date 
    story: string 
    details: GameDetailsGeneral
    multiplayerModes: Array<GameDetailsMultiplayerModeDto>
    spellings: GameDetailsSpellingsDto
    websites: Array<GameDetailsWebsiteDto>
    cover: GameCoverDetailsDto
    background: GameBackgroundDetailsDto
}

export interface GameCoverDetailsDto {
    imageTitle: string 
    imageData : string
}

export interface GameBackgroundDetailsDto {
    imageTitle: string 
    imageData : string
}

export interface GameDetailsGeneral
{
    description: string
    platformsDtos: Array<GameDetailsGeneralPlatformsDto>
    companies: GameDetailsGeneralInvolvedCompanies
    themes: Array<string>
    genres: Array<string>
    gameModes: Array<string>
    playerPerspectives: Array<string>
}

export interface GameDetailsGeneralPlatformsDto
{
    id: number
    name: string
}

export interface GameDetailsGeneralInvolvedCompanies
{
    developer: Array<GameDetailsGeneralCompany>
    publisher: Array<GameDetailsGeneralCompany>
    porting: Array<GameDetailsGeneralCompany>
    supporting: Array<GameDetailsGeneralCompany>
}

export interface GameDetailsGeneralCompany
{
    id: number
    name: string
}

export interface GameDetailsMultiplayerModeDto {
    platformName: string
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

export interface GameDetailsSpellingsDto
{
    localizedTitles: Array<GameDetailsTitlesDto>
    alternativeTitles: Array<GameDetailsTitlesDto>
}

export interface GameDetailsTitlesDto
{
    type: string
    title: string
}

export interface GameDetailsWebsiteDto {
    url: string
    category: EWebsites
}