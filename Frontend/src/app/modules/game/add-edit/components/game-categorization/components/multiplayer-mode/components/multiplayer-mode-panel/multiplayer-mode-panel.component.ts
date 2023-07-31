import { Component, EventEmitter, Input, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StandarInputComponent } from 'src/app/common/standar-input/standar-input.component';
import { StandarSelectSearchComponent } from 'src/app/common/standar-select-search/standar-select-search.component';
import { FormGroup, FormGroupDirective } from '@angular/forms';
import { ResponsiveService, ResponsizeSize } from 'src/app/core/services/responsive.service';
import { CheckMarkCheckBoxButtonComponent } from 'src/app/common/checkboxes-buttons/check-mark-checkbox-button/check-mark-checkbox-button.component';

@Component({
  selector: 'app-multiplayer-mode-panel',
  standalone: true,
  imports: [CommonModule, StandarInputComponent, StandarSelectSearchComponent, CheckMarkCheckBoxButtonComponent],
  templateUrl: './multiplayer-mode-panel.component.html',
  styleUrls: ['./multiplayer-mode-panel.component.scss']
})
export class MultiplayerModePanelComponent {
  @Input() index!: number
  @Output() remove = new EventEmitter<number>
  deviceType = ResponsizeSize

  perpectives = [
    {id:1, name:'Online Co-op', control:'onlineCoOp'},
    {id:2, name:'Offline Co-op', control:'offlineCoOp'},
    {id:3, name:'LAN Co-op', control:'lanCoOp'},
    {id:4, name:'Co-op Campaign', control:'coOpCampaign'},
    {id:5, name:'Online Split-Screen', control:'onlineSplitScreen'},
    {id:6, name:'Offline Split-Screen', control:'offlineSpliteScreen'},
    {id:7, name:'Drop in/out', control:'dropInOut'},
  ]

  constructor(public parentForm: FormGroupDirective, public responsiveService: ResponsiveService){}

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
}
