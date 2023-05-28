import { Component } from '@angular/core';
import { ResponsiveService, ResponsizeSize } from 'src/app/core/services/responsive.service';

@Component({
  selector: 'app-links',
  templateUrl: './links.component.html',
  styleUrls: ['./links.component.scss']
})
export class LinksComponent {
  twitterStyle: string = 'color:#fff; background:#00acee;'
  officialWebsiteStyle: string = 'color:#fff; background:#c15375'
  responsiveSizes = ResponsizeSize
  constructor(public responsiveService: ResponsiveService) {}
}
