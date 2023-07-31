import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GameModesComponent } from './components/game-modes/game-modes.component';
import { GenreThemeComponent } from './components/genre-theme/genre-theme.component';
import { MultiplayerModeComponent } from './components/multiplayer-mode/multiplayer-mode.component';
import { PlayerPerspectiveComponent } from './components/player-perspective/player-perspective.component';
import { ResponsiveService, ResponsizeSize } from 'src/app/core/services/responsive.service';

@Component({
  selector: 'app-game-categorization',
  standalone: true,
  imports: [CommonModule, GameModesComponent, GenreThemeComponent, MultiplayerModeComponent,PlayerPerspectiveComponent],
  templateUrl: './game-categorization.component.html',
  styleUrls: ['./game-categorization.component.scss']
})
export class GameCategorizationComponent {
  deviceType = ResponsizeSize
  constructor(public responsiveService: ResponsiveService){}
}
