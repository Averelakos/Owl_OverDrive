import { Component } from '@angular/core';
import { ResponsiveService, ResponsizeSize } from 'src/app/core/services/responsive.service';

@Component({
  selector: 'app-founded',
  templateUrl: './founded.component.html',
  styleUrls: ['./founded.component.scss']
})
export class FoundedComponent {
  responsiveSizes = ResponsizeSize
  constructor(public responsiveService: ResponsiveService) {}
}
