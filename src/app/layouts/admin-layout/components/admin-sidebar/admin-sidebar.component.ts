import { Component, Input} from '@angular/core';
import { Menu } from 'src/app/core/models/menu';
import { MenuService } from 'src/app/core/services/menu.service';
import { ResponsiveService, ResponsizeSize } from 'src/app/core/services/responsive.service';
import { runInThisContext } from 'vm';


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

  openSubMenuItems(event: any = null, item: any) {

    if (event != null) {
      let element = event.target as HTMLElement;
      if (this.activeSubMenu !== item.mainPageLabel) {
        this.closeAllSubMenus()
        element.classList.add('sub-active')
        this.activeSubMenu = item.mainPageLabel;
      } 
      else {
        this.activeSubMenu = '';
      }
    } 
    else {
      this.closeAllSubMenus()
      this.activeSubMenu = ''
    }


    // if (event != null) {
    //   let element = event.target as HTMLElement;
    //   if (element.classList.contains('sub-active') && this.activeSubMenu === item.mainPageLabel) {
    //     element.classList.remove('sub-active')
    //   } else {
    //     element.classList.add('sub-active')
    //   }
    // } else {
      
    // }

    // if (this.activeSubMenu !== item.mainPageLabel) {
    //   this.activeSubMenu = item.mainPageLabel;
    // } else {
    //   this.activeSubMenu = '';
    // }
    // console.log(this.activeSubMenu)
  }

  closeAllSubMenus() {
    const parentELement = document.getElementsByClassName('sub-active')
      let count = parentELement.length
      for (var i = 0; i<count; i++) {
        if (parentELement[i].classList.contains('sub-active')) {
          parentELement[i].classList.remove('sub-active')
        }
      }
  }

  isThisSubMenuActive(item): boolean {
    return item.mainPageLabel === this.activeSubMenu;
  }

  clickOutside(item) {
    console.log(item)
    this.activeSubMenu = '';
  }

}
