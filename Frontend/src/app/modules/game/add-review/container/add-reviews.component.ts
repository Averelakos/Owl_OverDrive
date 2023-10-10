import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BehaviorSubject, finalize, first } from 'rxjs';
import { ResponsiveService, ResponsizeSize } from 'src/app/core/services/responsive.service';
import { GameService } from 'src/app/data/services/game.service';
import { GameDetailsDto } from 'src/app/data/types/game/game-details-dto';

@Component({
  selector: 'app-add-reviews',
  templateUrl: './add-reviews.component.html',
  styleUrls: ['./add-reviews.component.scss']
})
export class AddReviewsComponent {
  gameModel: GameDetailsDto
  loading$ = new BehaviorSubject<boolean>(false)
  responsiveSizes = ResponsizeSize
  game!: any

  constructor(private gameService: GameService, public responsiveService: ResponsiveService, private readonly route: ActivatedRoute, private readonly router: Router){
    const gameId = this.route.snapshot.params['id']
    const gameName = this.route.snapshot.params['Name']
    this.game = gameService.returnGameReviewDetails()
    if(this.game == null) {
      this.router.navigate(['Game/view/' + gameName, {id:gameId} ])
    }
  }

  fetchGame(gameId: number) {
    this.loading$.next(true)
    this.gameService
    .getGameById(gameId).pipe(first(),finalize(()=> this.loading$.next(false))).subscribe((response) => {
      this.gameModel = response
    })
  }
}
