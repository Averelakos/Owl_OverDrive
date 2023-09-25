import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { GameService } from 'src/app/data/services/game.service';
import { GameDetailsDto } from 'src/app/data/types/game/game-details-dto';

@Component({
  selector: 'app-game-details',
  templateUrl: './game-details.component.html',
  styleUrls: ['./game-details.component.scss']
})
export class GameDetailsComponent {
  gameModel: GameDetailsDto

  constructor(private readonly route: ActivatedRoute, private gameService: GameService){
    const gameId = this.route.snapshot.params['id']
    this.fetchGame(gameId)
  }

  fetchGame(gameId: number) {
    this.gameService
    .getGameById(gameId).subscribe((response) => {
      console.log(response)
      this.gameModel = response
    })
  }
}
