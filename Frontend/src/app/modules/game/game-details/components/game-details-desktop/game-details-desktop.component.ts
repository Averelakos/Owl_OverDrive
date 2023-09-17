import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderInfoComponent } from './components/header-info/header-info.component';

@Component({
  selector: 'app-game-details-desktop',
  standalone: true,
  imports: [CommonModule, HeaderInfoComponent],
  templateUrl: './game-details-desktop.component.html',
  styleUrls: ['./game-details-desktop.component.scss']
})
export class GameDetailsDesktopComponent {

}
