import { Breakpoints } from '@angular/cdk/layout';
import { Component, OnInit } from '@angular/core';
import { ResponsiveService } from 'src/app/core/services/responsive.service';

@Component({
  selector: 'app-admin-layout',
  templateUrl: './admin-layout.component.html',
  styleUrls: ['./admin-layout.component.scss']
})
export class AdminLayoutComponent implements OnInit {

  sidebarIsToggled = false;
  constructor(private responsiveService: ResponsiveService) {
    
   }

  ngOnInit(): void {
    // console.log(Breakpoints.Tablet)
    // console.log(this.responsiveService.Desktop)
  }

  toggleSideBar(){
    this.sidebarIsToggled = !this.sidebarIsToggled;
  }

}
