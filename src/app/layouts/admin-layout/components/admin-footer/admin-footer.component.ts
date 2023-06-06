import { Component, EventEmitter, HostListener, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-admin-footer',
  templateUrl: './admin-footer.component.html',
  styleUrls: ['./admin-footer.component.scss']
})
export class AdminFooterComponent implements OnInit {


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
