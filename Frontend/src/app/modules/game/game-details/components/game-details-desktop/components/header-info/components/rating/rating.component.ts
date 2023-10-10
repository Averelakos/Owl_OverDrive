import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CicleScoreProgressComponent } from 'src/app/common/score-progress/circle-score-progress/circle-score-progress';
import { GameCoverDetailsDto, GameDetailsDto } from 'src/app/data/types/game/game-details-dto';
import { Router } from '@angular/router';
import { GameService } from 'src/app/data/services/game.service';

@Component({
  selector: 'app-rating',
  standalone: true,
  imports: [CommonModule, CicleScoreProgressComponent],
  templateUrl: './rating.component.html',
  styleUrls: ['./rating.component.scss']
})
export class RatingComponent {
  @Input()gameId
  @Input() gameCover: GameCoverDetailsDto
  @Input() gameTitle: string
  @Input() score: number

  constructor(private router: Router, private readonly gameService: GameService){}
  
  addMyReview(){
    this.gameService.addGameReviewDetails(this.gameId, this.gameCover, this.gameTitle)
    this.router.navigate([`Game/add-review/` + this.gameTitle, {id:this.gameId, name: this.gameTitle}])
  }
}
