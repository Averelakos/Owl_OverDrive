import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GameService } from 'src/app/data/services/game.service';
import { GameSimpleDto } from 'src/app/data/types/game/GameSimpleDto';
import { GameCardComponent } from './components/game-card/game-card.component';
import { GamePaginationComponent } from './components/game-pagination/game-pagination.component';
import { LogoLoader } from 'src/app/common/loaders/logo-loader/logo-loader';
import { BehaviorSubject } from 'rxjs';

@Component({
  selector: 'app-queryable-game-list',
  standalone: true,
  imports: [CommonModule, GameCardComponent, GamePaginationComponent, LogoLoader],
  templateUrl: './queryable-game-list.component.html',
  styleUrls: ['./queryable-game-list.component.scss']
})
export class QueryableGameListComponent {
  gameList: Array<GameSimpleDto>
  loading$ = new BehaviorSubject<boolean>(false)
  constructor(private gameService: GameService){
    this.loading$.next(true)
    gameService.listGame().subscribe((response) => {
      this.loading$.next(false)
      this.gameList = response
    })
  }

  changePage(event: any) {
    // console.log(event)
  }
}
