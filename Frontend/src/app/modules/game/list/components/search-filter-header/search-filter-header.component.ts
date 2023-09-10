import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SearchComponent } from '../search/search.component';
import { ResponsiveService, ResponsizeSize } from 'src/app/core/services/responsive.service';

@Component({
  selector: 'app-search-filter-header',
  standalone: true,
  imports: [CommonModule, SearchComponent],
  templateUrl: './search-filter-header.component.html',
  styleUrls: ['./search-filter-header.component.scss']
})
export class SearchFilterHeaderComponent {
  deviceType = ResponsizeSize
  constructor(public responsiveService: ResponsiveService){}
}
