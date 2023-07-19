import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StandarCheckBoxButtonComponent } from 'src/app/common/checkboxes-buttons/standar-checkbox-button/standar-checkbox-button.component';
import { ResponsiveService, ResponsizeSize } from 'src/app/core/services/responsive.service';
import { FormGroupDirective } from '@angular/forms';
import { StandarInputComponent } from 'src/app/common/standar-input/standar-input.component';
import { StandarSelectSearchComponent } from 'src/app/common/standar-select-search/standar-select-search.component';

@Component({
  selector: 'app-game-type',
  standalone: true,
  imports: [CommonModule, StandarCheckBoxButtonComponent, StandarSelectSearchComponent],
  templateUrl: './game-type.component.html',
  styleUrls: ['./game-type.component.scss']
})
export class GameTypeComponent {
  deviceType = ResponsizeSize
  gameTypeOptions: Array<any> = [
    {id:1, type:'Bundle',checked: false},
    {id:2, type:'DLC',checked: false},
    {id:3, type:'Episode',checked: false},
    {id:4, type:'Expanded game',checked: false},
    {id:5, type:'Expansion',checked: false},
    {id:6, type:'Fork',checked: false},
    {id:7, type:'Mod',checked: false},
    {id:8, type:'Pack / Addon',checked: false},
    {id:9, type:'Port',checked: false},
    {id:10, type:'Remake',checked: false},
    {id:11, type:'Remaster',checked: false},
    {id:12, type:'Season',checked: false},
    {id:13, type:'Standalone Expansion',checked: false},
    {id:14, type:'Update',checked: false},
  ]

  main: any = {id:0, type:'Main game',checked: true}

  constructor(
    public responsiveService: ResponsiveService, 
    public parentForm: FormGroupDirective, 
  ){}

  clickMainGame() {
    this.main.checked = true
    this.gameTypeOptions.forEach((item) => {
      item.isChecked = false
    })

    this.parentForm.form.get('general')?.get('gameType')?.get('typeId')?.patchValue(null)
    this.parentForm.form.get('general')?.get('gameType')?.get('baseGame')?.patchValue(null)
  }

  onClick(option: any, e: any){
    this.main.checked = false
      this.gameTypeOptions.forEach((item) => {
        if (item.id === option.id) {
          item.isChecked = true  
          this.parentForm.form.get('general')?.get('gameType')?.get('typeId')?.patchValue(item.id)
        } else {
          item.isChecked = false
        }
      })
  }
}
