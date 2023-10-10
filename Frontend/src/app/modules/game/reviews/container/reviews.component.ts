import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BehaviorSubject, finalize, first } from 'rxjs';
import { ResponsiveService, ResponsizeSize } from 'src/app/core/services/responsive.service';
import { GameService } from 'src/app/data/services/game.service';
import { GameDetailsDto } from 'src/app/data/types/game/game-details-dto';
import { GameUserReviewReviewDto, GameUserReviewsDto } from 'src/app/data/types/game/game-user-review';

@Component({
  selector: 'app-reviews',
  templateUrl: './reviews.component.html',
  styleUrls: ['./reviews.component.scss']
})
export class ReviewsComponent {
  gameModel: GameUserReviewsDto
  userRevies: Array<GameUserReviewReviewDto> = []
  loading$ = new BehaviorSubject<boolean>(false)
  responsiveSizes = ResponsizeSize

  constructor(private readonly route: ActivatedRoute, private gameService: GameService, public responsiveService: ResponsiveService,){
    const gameId = this.route.snapshot.params['id']
    this.fetchGame(gameId)
  }

  fetchGame(gameId: number) {
    this.loading$.next(true)
    this.gameService
    .getAllGameUserReviews(gameId)
    .pipe(first(),finalize(()=> this.loading$.next(false)))
    .subscribe((response) => {
      this.gameModel = response
      this.userRevies = response.usersReviews
      console.log(this.userRevies)
    })
  }
}
