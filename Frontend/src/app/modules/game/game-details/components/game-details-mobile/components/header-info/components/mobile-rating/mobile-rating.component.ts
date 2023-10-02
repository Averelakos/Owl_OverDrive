import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CicleScoreProgressComponent } from 'src/app/common/score-progress/circle-score-progress/circle-score-progress';

@Component({
  selector: 'app-mobile-rating',
  standalone: true,
  imports: [CommonModule, CicleScoreProgressComponent],
  templateUrl: './mobile-rating.component.html',
  styleUrls: ['./mobile-rating.component.scss']
})
export class MobileRatingComponent {

}
