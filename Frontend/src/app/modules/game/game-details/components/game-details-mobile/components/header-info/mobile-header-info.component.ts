import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GameDetailsDto } from 'src/app/data/types/game/game-details-dto';
import { MobileInfoComponent } from './components/mobile-info/mobile-info.component';
import { MobileLogoComponent } from './components/mobile-logo/mobile-logo.component';
import { MobileRatingComponent } from './components/mobile-rating/mobile-rating.component';


@Component({
  selector: 'app-mobile-header-info',
  standalone: true,
  imports: [CommonModule, MobileInfoComponent, MobileLogoComponent, MobileRatingComponent],
  templateUrl: './mobile-header-info.component.html',
  styleUrls: ['./mobile-header-info.component.scss']
})
export class MobileHeaderInfoComponent {
  @Input()gameModel: GameDetailsDto
}
