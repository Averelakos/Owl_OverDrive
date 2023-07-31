import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ResponsiveService, ResponsizeSize } from 'src/app/core/services/responsive.service';
import { StandarLinkInputComponent } from 'src/app/common/standar-link-input/standar-link-input.component';

@Component({
  selector: 'app-game-websites',
  standalone: true,
  imports: [CommonModule, StandarLinkInputComponent],
  templateUrl: './game-websites.component.html',
  styleUrls: ['./game-websites.component.scss']
})
export class GameWebsitesComponent {
  deviceType = ResponsizeSize
  constructor(public responsiveService: ResponsiveService){}
}
