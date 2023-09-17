import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CicleScoreProgressComponent } from 'src/app/common/score-progress/circle-score-progress/circle-score-progress';

@Component({
  selector: 'app-rating',
  standalone: true,
  imports: [CommonModule, CicleScoreProgressComponent],
  templateUrl: './rating.component.html',
  styleUrls: ['./rating.component.scss']
})
export class RatingComponent {

}
