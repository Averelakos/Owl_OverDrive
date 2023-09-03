import { Component, EventEmitter, Input, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StandarInputComponent } from 'src/app/common/standar-input/standar-input.component';
import { SelectSearchInputValue, StandarSelectSearchComponent } from 'src/app/common/standar-select-search/standar-select-search.component';
import { FormBuilder, FormGroup, FormGroupDirective } from '@angular/forms';
import { ResponsiveService, ResponsizeSize } from 'src/app/core/services/responsive.service';
import { CheckMarkCheckBoxButtonComponent } from 'src/app/common/checkboxes-buttons/check-mark-checkbox-button/check-mark-checkbox-button.component';
import { PlatformService } from 'src/app/data/services/platform.service';

@Component({
  selector: 'app-multiplayer-mode-panel',
  standalone: true,
  imports: [CommonModule, StandarInputComponent, StandarSelectSearchComponent, CheckMarkCheckBoxButtonComponent],
  templateUrl: './multiplayer-mode-panel.component.html',
  styleUrls: ['./multiplayer-mode-panel.component.scss'],
  providers:[PlatformService]
})
export class MultiplayerModePanelComponent {
  @Input() index!: number
  @Output() remove = new EventEmitter<number>
  deviceType = ResponsizeSize
  listOfPlatforms: Array<SelectSearchInputValue> = []

  perpectives = [
    {id:1, name:'Online Co-op', control:'onlineCoOp', isChecked: false},
    {id:2, name:'Offline Co-op', control:'offlineCoOp', isChecked: false},
    {id:3, name:'LAN Co-op', control:'lanCoOp', isChecked: false},
    {id:4, name:'Co-op Campaign', control:'coOpCampaign', isChecked: false},
    {id:5, name:'Online Split-Screen', control:'onlineSplitScreen', isChecked: false},
    {id:6, name:'Offline Split-Screen', control:'offlineSpliteScreen', isChecked: false},
    {id:7, name:'Drop in/out', control:'dropInOut', isChecked: false},
  ]

  constructor(public parentForm: FormGroupDirective, public responsiveService: ResponsiveService, private platformService: PlatformService){}

  ngOnInit(): void {
    if(this.MultiplayerMode()?.value != null && this.MultiplayerMode()?.value != undefined) {
      console.log(this.MultiplayerMode()?.value)
      this.perpectives[0].isChecked = this.MultiplayerMode()?.value.onlineCoOp
      this.perpectives[1].isChecked = this.MultiplayerMode()?.value.offlineCoOp
      this.perpectives[2].isChecked = this.MultiplayerMode()?.value.lanCoOp
      this.perpectives[3].isChecked = this.MultiplayerMode()?.value.coOpCampaign
      this.perpectives[4].isChecked = this.MultiplayerMode()?.value.onlineSplitScreen
      this.perpectives[5].isChecked = this.MultiplayerMode()?.value.offlineSpliteScreen
      this.perpectives[6].isChecked = this.MultiplayerMode()?.value.dropInOut
    }
  }

  removeLocalization() {
    this.remove.emit(this.index)
  }

  MultiplayerMode() {
    return this.parentForm.control.get('multiplayerModes.' + this.index) as FormGroup
  }

  checkBoxClicked($event, item){
    let currentValue = this.MultiplayerMode()?.get(item.control)?.value
    this.MultiplayerMode()?.get(item.control)?.patchValue(!currentValue)
  }


  searchPlatform(input){
    if (input.length > 0) {
      this.platformService
      .searchPlatform(input)
      .subscribe((response) => {
        this.listOfPlatforms.length = 0
        if (response.length > 0) {
          response.forEach(element => {
            this.listOfPlatforms.push({
              id:element.id,
              value: element.name
            })
          });
        } 
      })
    } else {
      this.listOfPlatforms.length = 0
    }
  }
}
