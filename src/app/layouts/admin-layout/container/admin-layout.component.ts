import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-admin-layout',
  templateUrl: './admin-layout.component.html',
  styleUrls: ['./admin-layout.component.scss']
})
export class AdminLayoutComponent implements OnInit {

  sidebarIsToggled = true;
  constructor() {
    
   }

  ngOnInit(): void {
  }

  toggleSideBar(){
    this.sidebarIsToggled = !this.sidebarIsToggled;
  }

}
