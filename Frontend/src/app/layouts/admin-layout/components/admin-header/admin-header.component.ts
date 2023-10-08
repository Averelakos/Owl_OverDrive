import { Component, EventEmitter, HostListener, Input, OnInit, Output } from '@angular/core';
import { AuthService } from 'src/app/core/auth/auth.service';

@Component({
  selector: 'app-admin-header',
  templateUrl: './admin-header.component.html',
  styleUrls: ['./admin-header.component.scss']
})
export class AdminHeaderComponent implements OnInit {


  @Input() isSideBarOpen: boolean;
  @Output() toggle = new EventEmitter<boolean>();
  constructor(private readonly authService: AuthService) { }

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

  logout(){
    this.authService.logout()
  }

}
