import { Component, Input} from '@angular/core';
import { Menu } from 'src/app/core/models/menu';
import { MenuService } from 'src/app/core/services/menu.service';
import { ResponsiveService, ResponsizeSize } from 'src/app/core/services/responsive.service';


@Component({
  selector: 'app-admin-sidebar',
  templateUrl: './admin-sidebar.component.html',
  styleUrls: ['./admin-sidebar.component.scss']
})
export class AdminSidebarComponent {
 
  menuItems: Array<Menu>
  activeSubMenu: string = 'Home';
  responsiveSizes = ResponsizeSize
  @Input()sideBarClosed: boolean = false;
  constructor(public menuService: MenuService, public responsiveService: ResponsiveService) {
    this.menuItems = menuService.getMenu();
  }


  sidebarIsClosed(responsive: boolean) : boolean {
    if (responsive) {
      return responsive
    } 
    else {
      return this.sideBarClosed
    }
  }

  openSubMenuItems(item) {
    if (this.activeSubMenu !== item.mainPageLabel) {
      this.activeSubMenu = item.mainPageLabel;
    } else {
      this.activeSubMenu = 'Home';
    }
  }



  isThisSubMenuActive(item): boolean {
    return item.mainPageLabel === this.activeSubMenu;
  }

  clickOutside() {
    this.activeSubMenu = '';
  }

}
