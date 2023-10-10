import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CicleScoreProgressComponent } from 'src/app/common/score-progress/circle-score-progress/circle-score-progress';
import { GameCoverDetailsDto } from 'src/app/data/types/game/game-details-dto';
import { GameService } from 'src/app/data/services/game.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-mobile-rating',
  standalone: true,
  imports: [CommonModule, CicleScoreProgressComponent],
  templateUrl: './mobile-rating.component.html',
  styleUrls: ['./mobile-rating.component.scss']
})
export class MobileRatingComponent {

  @Input()gameId
  @Input() gameCover: GameCoverDetailsDto
  @Input() gameTitle: string
  @Input() score: number

  constructor(private router: Router, private readonly gameService: GameService){}

  addMyReview(){
    this.gameService.addGameReviewDetails(this.gameId, this.gameCover, this.gameTitle)
    this.router.navigate([`Game/add-review/` + this.gameTitle, {id:this.gameId, name: this.gameTitle}])
  }

  setColorScore(){
    switch(this.score){
        case 1:
            return 'red'
            break
        case 2:
            return 'red'
            break
        case 3:
        return 'red'
        break
        case 4:
            return 'orange'
            break
        case 5:
            return 'orange'
            break
        case 6:
        return 'orange'
        break
        case 7:
            return 'green'
            break
        case 8:
            return 'green'
            break
        case 9:
        return 'green'
        break
        case 10:
        return 'green'
        break
        default:
        return 'white'
    }
}
}
