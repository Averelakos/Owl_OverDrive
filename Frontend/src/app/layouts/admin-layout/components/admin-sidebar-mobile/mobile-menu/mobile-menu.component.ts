import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MenuService } from 'src/app/core/services/menu.service';
import { Menu } from 'src/app/core/models/menu';

@Component({
  selector: 'app-mobile-menu',
  standalone: true,
  imports: [CommonModule, RouterModule,],
  templateUrl: './mobile-menu.component.html',
  styleUrls: ['./mobile-menu.component.scss']
})
export class MobileMenuComponent {

  menuItems: Array<Menu>
  constructor(public menuService: MenuService,){
    this.menuItems = menuService.getMenu();
  }
  clicked(link){

  }

  clickedAbout(){

  }


  clickToOpenSubMenu(e){
    // e.preventDefault();
    const currentTarget = e.currentTarget as HTMLElement
    console.log(currentTarget.parentElement?.classList)
    const isSubMenuOpen = currentTarget.parentElement?.classList.contains('open-subMenu')
    const allSubMenuEl = document.querySelectorAll('.menu-navigation-item')
    allSubMenuEl.forEach(element => {
      if (element.classList.contains('open-subMenu')) {
        element.classList.remove('open-subMenu')
      }
    });

    if (!isSubMenuOpen) {
      currentTarget.parentElement?.classList.add('open-subMenu')
    }
  }

  clickToCloseSubMenu(){
    
    const allSubMenuEl = document.querySelectorAll('.menu-navigation-item')
    allSubMenuEl.forEach(element => {
      if (element.classList.contains('open-subMenu')) {
        element.classList.remove('open-subMenu')
      }
    });
    // this.layoutService.sidebarMobileMenuTrigger.next(false)
  }
}
