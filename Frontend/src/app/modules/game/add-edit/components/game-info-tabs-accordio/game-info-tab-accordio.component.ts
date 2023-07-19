import { Component } from '@angular/core';
import { ResponsiveService, ResponsizeSize } from 'src/app/core/services/responsive.service';

@Component({
  selector: 'app-game-info-tab-accordio',
  templateUrl: './game-info-tab-accordio.component.html',
  styleUrls: ['./game-info-tab-accordio.component.scss']
})
export class GameInfoTabAccordioComponent {
  deviceType = ResponsizeSize
  tabInfo = {
    general: {id:1, title: 'General', active: true},
    localization: {id:2, title: 'Localiazation', active: false},
    categorization: {id:3, title: 'Categorization', active: false}
  }

  constructor(public responsiveService: ResponsiveService, ){}

  toggleActive(id: number) {
    Object.entries(this.tabInfo).forEach(element => {
      if(element[1].id === id && element[1].active === false) {
        element[1].active = true
      } else {
        element[1].active = false
      }
    });
  }

}
