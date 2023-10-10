export interface GameUserReviewsDto
{
    id: number
    name :string
    cover: GameUsersReviewsCoverDto
    usersReviews: Array<GameUserReviewReviewDto>
}

export interface GameUsersReviewsCoverDto
{
    imageTitle: string
    imageData: string
}

export interface GameUserReviewReviewDto
{
    review: string
    score: number
    username: string
    postDate: Date
}