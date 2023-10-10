import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GameDetailsDto } from 'src/app/data/types/game/game-details-dto';
import { ReviewCardComponent } from 'src/app/common/reusable-cards/review-card/review-card.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-reviews',
  standalone: true,
  imports: [CommonModule, ReviewCardComponent],
  templateUrl: './reviews.component.html',
  styleUrls: ['./reviews.component.scss']
})
export class ReviewsComponent {
  @Input()gameModel: GameDetailsDto
  constructor(private router: Router){}

  openReviews() {
    this.router.navigate(['Game/reviews/' + this.gameModel.name, {id:this.gameModel.id} ])
  }
}
