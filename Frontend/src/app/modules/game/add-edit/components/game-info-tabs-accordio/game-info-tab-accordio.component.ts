import { Component, EventEmitter, Input, Output } from '@angular/core';
import { ResponsiveService, ResponsizeSize } from 'src/app/core/services/responsive.service';

@Component({
  selector: 'app-game-info-tab-accordio',
  templateUrl: './game-info-tab-accordio.component.html',
  styleUrls: ['./game-info-tab-accordio.component.scss']
})
export class GameInfoTabAccordioComponent {
  deviceType = ResponsizeSize
  currentElement: number = 1
  @Input()isForCreate: boolean = true
  @Output() create = new EventEmitter()
  @Output() update = new EventEmitter()
  tabInfo = {
    general: {id:1, title: 'General', active: true},
    alternative:{id: 2, title: 'Alternative Titles', active: false},
    localization: {id:3, title: 'Localiazation', active: false},
    categorization: {id:4, title: 'Categorization', active: false},
    releaseDates: {id:5, title: 'Release Dates', active: false},
    websites: {id:7, title: 'Websites', active: false},
    companies: {id:8, title: 'Companies', active: false},
    story: {id:10, title: 'Story', active: false},
    languages: {id:11, title: 'Supported Languages', active: false}
  }

  constructor(public responsiveService: ResponsiveService, ){}

  toggleActive(id: number) {
    Object.entries(this.tabInfo).forEach(element => {
      if(element[1].id === id && element[1].active === false) {
        element[1].active = true
        this.currentElement = element[1].id
      } else {
        element[1].active = false
      }
    });
  }

  clickToGoBack() {
    let currentTab = Object.entries(this.tabInfo).find(x => x[1].id == this.currentElement)
    let previewsTab = Object.entries(this.tabInfo).find(x => x[1].id == this.currentElement - 1)
    if (previewsTab != undefined && currentTab != undefined) {
      let previewsIdentifier = previewsTab[1].id
      let currentIdentifier = currentTab[1].id
      Object.entries(this.tabInfo).forEach(element => {
        if(element[1].id === previewsIdentifier) {
          element[1].active = true
          this.currentElement = element[1].id
        } 

        if(element[1].id === currentIdentifier) {
          element[1].active = false
        } 

      });
    }
  }

  clickToGoNext() {
    let currentTab = Object.entries(this.tabInfo).find(x => x[1].id == this.currentElement)
    let nextTab = Object.entries(this.tabInfo).find(x => x[1].id == this.currentElement + 1)
    if (nextTab != undefined && currentTab != undefined) {
      let nextIdentifier = nextTab[1].id
      let currentIdentifier = currentTab[1].id
      Object.entries(this.tabInfo).forEach(element => {
        if(element[1].id === nextIdentifier) {
          element[1].active = true
          this.currentElement = element[1].id
        } 

        if(element[1].id === currentIdentifier) {
          element[1].active = false
        } 

      });
    }
  }

  clickToCreate() {
    this.create.emit()
  }

  clickToUpdate() {
    this.update.emit()
  }

}
