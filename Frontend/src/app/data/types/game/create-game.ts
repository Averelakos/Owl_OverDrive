import { EWebsites } from "src/app/core/enums/enum-websites"

export interface CreateGameDto{
    name: string
    description: string
    gameStatus: number
    gameEdition: CreateGameEditionDto | null
    alternativeNames: Array<CreateAlternativeTitleDto>
    updateGameType: string | null
    updatedGameId : number | null
    releaseDates: Array<CreateReleaseDateDto>
    websites : Array<CreateWebsite>
}

export interface CreateGameEditionDto {
    editionTitle: string
    parentGameId:number
}

export interface CreateAlternativeTitleDto {
    type: string
    alternativeName:string
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