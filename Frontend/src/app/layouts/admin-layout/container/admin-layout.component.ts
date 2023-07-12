import { Breakpoints } from '@angular/cdk/layout';
import { Component, OnInit } from '@angular/core';
import { LayoutService } from 'src/app/core/services/layout.service';
import { ResponsiveService, ResponsizeSize } from 'src/app/core/services/responsive.service';
import { LookupsService } from 'src/app/data/services/Lookups.service';
import { ToastrService } from 'src/app/lib/toastr/toastr.service';

@Component({
  selector: 'app-admin-layout',
  templateUrl: './admin-layout.component.html',
  styleUrls: ['./admin-layout.component.scss'],
})
export class AdminLayoutComponent implements OnInit {

  sidebarIsToggled = false;
  responsiveSizes = ResponsizeSize
  constructor(public responsiveService: ResponsiveService, public layoutService: LayoutService, private readonly lookupsService: LookupsService, private toastr: ToastrService) {
    this.lookupsService.init()
    this.layoutService.sidebarMenuTrigger.next(false)
  }

  ngOnInit(): void {
    this.layoutService.sidebarMenuTrigger
    // console.log(Breakpoints.Tablet)
    // console.log(this.responsiveService.Desktop)
  }

  toggleSideBar(){
    this.sidebarIsToggled = !this.sidebarIsToggled;
  }

  show(){
    this.toastr.success('Hello world!', 'Toastr fun!');
  }

}
