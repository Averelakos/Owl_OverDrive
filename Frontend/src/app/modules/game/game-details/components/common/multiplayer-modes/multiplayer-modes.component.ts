import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GameDetailsMultiplayerModeDto } from 'src/app/data/types/game/game-details-dto';
import { TabComponent, TabsComponent } from 'src/app/common/tabs/tabs';

@Component({
  selector: 'app-multiplayer-modes',
  standalone: true,
  imports: [CommonModule, TabComponent, TabsComponent],
  templateUrl: './multiplayer-modes.component.html',
  styleUrls: ['./multiplayer-modes.component.scss']
})
export class MultiplayerModesComponent {
  @Input() multiplayerModes: Array<GameDetailsMultiplayerModeDto>
}
