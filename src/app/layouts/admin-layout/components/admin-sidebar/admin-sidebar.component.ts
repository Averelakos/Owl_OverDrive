import { AfterViewInit, Component, Directive, ElementRef, HostListener, Input, OnInit, ViewChild } from '@angular/core';
import { Menu } from 'src/app/core/models/menu';
import { MenuService } from 'src/app/core/services/menu.service';


@Component({
  selector: 'app-admin-sidebar',
  templateUrl: './admin-sidebar.component.html',
  styleUrls: ['./admin-sidebar.component.scss']
})
export class AdminSidebarComponent {
 
  menuItems: Array<Menu>
  activeSubMenu: string = 'Home';
  @Input()sideBarOpen: boolean = true;
  constructor(public menuService: MenuService) {
    this.menuItems = menuService.getMenu();
  }

  openSubMenuItems(item) {
    if (this.activeSubMenu !== item.mainPageLabel) {
      this.activeSubMenu = item.mainPageLabel;
    } else {
      this.activeSubMenu = 'Home';
    }
  }

  isThisSubMenuActive(item): boolean {
    console.log(item.mainPageLabel === this.activeSubMenu)
    return item.mainPageLabel === this.activeSubMenu;
  }

  clickOutside() {
    this.activeSubMenu = 'Home';
    console.log('test')
  }

}
