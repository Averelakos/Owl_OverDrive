import { Component, EventEmitter, HostListener, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-admin-header-mobile',
  templateUrl: './admin-header-mobile.component.html',
  styleUrls: ['./admin-header-mobile.component.scss']
})
export class AdminHeaderMobileComponent implements OnInit {


  @Input() isSideBarOpen: boolean;
  @Output() toggle = new EventEmitter<boolean>();
  constructor() { }

  ngOnInit(): void {
  }

  @HostListener('toggleSideBar')
  toggleSideBar() {
    this.isSideBarOpen = !this.isSideBarOpen;
    this.toggle.emit(this.isSideBarOpen);
    this.changeTogglerIcon();
  }

  changeTogglerIcon(){
    const iconElement = document.getElementById('toggleButtonIcon');
    
    if (this.isSideBarOpen) {
      iconElement?.classList.remove('fa-bars')
      iconElement?.classList.add('fa-ellipsis-vertical');
    } else {
      iconElement?.classList.remove('fa-ellipsis-vertical')
      iconElement?.classList.add('fa-bars');
    }
  }

}
