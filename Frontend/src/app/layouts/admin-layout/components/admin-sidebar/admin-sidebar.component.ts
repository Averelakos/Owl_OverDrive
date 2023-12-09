import { Component, Input} from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/core/auth/auth.service';
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
  activeSubMenu: string = '';
  responsiveSizes = ResponsizeSize

  @Input()sideBarClosed: boolean = false;
  constructor(public menuService: MenuService, public responsiveService: ResponsiveService , public router: Router, public authService: AuthService) {
    this.menuItems = menuService.getMenu();
    this.menuItems = this.menuItems.filter((item) => item.permision? authService.hasPermission(item.permision!) : true)

    this.menuItems.forEach((item) => {
      if (item.subMenu?.length !== 0) {
        item.subMenu?.forEach((x) => {
          if(x.route === router.url) {
            this.activeSubMenu = item.mainPageLabel!
          }
        })
      }
    })

  }


  sidebarIsClosed(responsive: boolean) : boolean {
    if (responsive) {
      return responsive
    } 
    else {
      return this.sideBarClosed
    }
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

  toggleSubMenuClick(event: Event) {
    event.preventDefault();

    const currentTarget = event.currentTarget as HTMLElement;

    // check if parent elment has sub menu items
    const parentElement = currentTarget.parentElement;
    const childrenElement = parentElement?.getElementsByTagName('ul');

    if (childrenElement !== undefined && childrenElement?.length > 0) {
      if (!currentTarget.classList.contains('selected')) {
        this.closeOpenSubNavs();
       currentTarget.classList.add('selected');
      } else {
        currentTarget.classList.remove('selected');
      }
    } else {
      this.closeOpenSubNavs();
      this.activeSubMenu = ''
    }
  }

  closeOpenSubNavs(){
    let openNav = document.querySelectorAll('.selected');

    openNav.forEach((items) => {
      if (items.classList.contains('selected')) {
        items.classList.remove('selected');
      }
    });
  }

  subButtonActive(item: any) {
    this.activeSubMenu = item.mainPageLabel
  }

}
