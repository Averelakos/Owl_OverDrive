import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SearchComponent } from '../search/search.component';
import { ResponsiveService, ResponsizeSize } from 'src/app/core/services/responsive.service';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/core/auth/auth.service';
import { EPermission } from 'src/app/core/enums/enum-permissions';

@Component({
  selector: 'app-search-filter-header',
  standalone: true,
  imports: [CommonModule, SearchComponent],
  templateUrl: './search-filter-header.component.html',
  styleUrls: ['./search-filter-header.component.scss']
})
export class SearchFilterHeaderComponent {
  deviceType = ResponsizeSize
  canCreateCompany!:boolean
  constructor(public responsiveService: ResponsiveService, private router: Router, private readonly authService: AuthService){
    this.canCreateCompany = this.authService.hasPermission(EPermission.Create_Company)
  }
  clickAddGame() {
    this.router.navigate(['Company/add']);
  }
}
