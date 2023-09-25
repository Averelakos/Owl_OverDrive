import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InfoComponent } from './components/info/info.component';
import { LogoComponent } from './components/logo/logo.component';
import { RatingComponent } from './components/rating/rating.component';
import { GameDetailsDto } from 'src/app/data/types/game/game-details-dto';

@Component({
  selector: 'app-header-info',
  standalone: true,
  imports: [CommonModule, InfoComponent, LogoComponent, RatingComponent],
  templateUrl: './header-info.component.html',
  styleUrls: ['./header-info.component.scss']
})
export class HeaderInfoComponent {
  @Input()gameModel: GameDetailsDto
}
