import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReviewCardComponent } from 'src/app/common/reusable-cards/review-card/review-card.component';
import { LogoLoader } from 'src/app/common/loaders/logo-loader/logo-loader';
import { GameUserReviewReviewDto } from 'src/app/data/types/game/game-user-review';

@Component({
  selector: 'app-review-body',
  standalone: true,
  imports: [CommonModule, ReviewCardComponent, LogoLoader],
  templateUrl: './review-body.component.html',
  styleUrls: ['./review-body.component.scss']
})
export class ReviewBodyComponent {
  @Input() userRevies: Array<GameUserReviewReviewDto> = [] 
}
