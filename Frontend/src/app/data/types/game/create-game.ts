export interface CreateGameDto{
    name: string
    description: string
    gameStatus: number
    gameEdition: CreateGameEditionDto | null
    alternativeNames: Array<CreateAlternativeTitleDto>
    updateGameType: string | null
    updatedGameId : number | null
}

export interface CreateGameEditionDto {
    editionTitle: string
    parentGameId:number
}

export interface CreateAlternativeTitleDto {
    type: string
    alternativeName:string
}