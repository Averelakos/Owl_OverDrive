import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GameCardComponent } from './components/result-card/game-card.component';
import { GameService } from 'src/app/data/services/game.service';
import { GameSimpleDto } from 'src/app/data/types/game/GameSimpleDto';

@Component({
  selector: 'app-queryable-game-list',
  standalone: true,
  imports: [CommonModule, GameCardComponent],
  templateUrl: './queryable-game-list.component.html',
  styleUrls: ['./queryable-game-list.component.scss']
})
export class QueryableGameListComponent {
  gameList: Array<GameSimpleDto>
  constructor(private gameService: GameService){
    gameService.listGame().subscribe((response) => {
      this.gameList = response
    })
  }
}
