import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GameDetailsDto } from 'src/app/data/types/game/game-details-dto';
import { ReviewsComponent } from './components/reviews/reviews.component';

@Component({
  selector: 'app-body-info',
  standalone: true,
  imports: [CommonModule, ReviewsComponent],
  templateUrl: './body-info.component.html',
  styleUrls: ['./body-info.component.scss']
})
export class BodyInfoComponent {
  @Input()gameModel: GameDetailsDto
}
