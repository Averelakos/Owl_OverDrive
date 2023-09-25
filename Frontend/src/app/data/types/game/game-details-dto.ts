export interface GameDetailsDto {
    id: number
    name: string 
    firstReleaseDate: Date 
    story: string 
    description : string
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