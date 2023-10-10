import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GameDetailsDto } from 'src/app/data/types/game/game-details-dto';
import { ReviewsComponent } from './components/reviews/reviews.component';

@Component({
  selector: 'app-mobile-body-info',
  standalone: true,
  imports: [CommonModule, ReviewsComponent],
  templateUrl: './mobile-body-info.component.html',
  styleUrls: ['./mobile-body-info.component.scss']
})
export class MobileBodyInfoComponent {
  @Input()gameModel: GameDetailsDto
}
