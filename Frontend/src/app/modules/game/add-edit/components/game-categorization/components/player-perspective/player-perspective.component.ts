import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CheckMarkCheckBoxButtonComponent } from 'src/app/common/checkboxes-buttons/check-mark-checkbox-button/check-mark-checkbox-button.component';
import { FormGroupDirective, FormsModule, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-player-perspective',
  standalone: true,
  imports: [CommonModule, CheckMarkCheckBoxButtonComponent, ReactiveFormsModule, FormsModule],
  templateUrl: './player-perspective.component.html',
  styleUrls: ['./player-perspective.component.scss']
})
export class PlayerPerspectiveComponent {
  perpectives = [
    {id:1, name:'Auditory'},
    {id:2, name:'Bird view / Isometric'},
    {id:3, name:'First person'},
    {id:4, name:'Side view'},
    {id:5, name:'Text'},
    {id:6, name:'Third person'},
    {id:7, name:'Virtual Reality'},
  ]

  constructor(public parentForm: FormGroupDirective){}

  checkBoxClicked(e: any, item) {
    let temp = this.playerPerspectives()?.value
    console.log(temp)
    let valueExists = false 
    if (temp != null) {
      temp.forEach(element => {
        if (element === item.id) {
          valueExists = true
        }
      });
    } else {
      temp = []
    }

    if (valueExists) {
      const changedTemp = temp.filter((value) => {
        return value !== item.id 
      }
      )

      console.log(changedTemp)
      this.playerPerspectives()?.patchValue(changedTemp)
    } else {
      temp.push(item.id)
      this.playerPerspectives()?.patchValue(temp)
    }
    
  }

  playerPerspectives() {
    return this.parentForm.control.get('categorization.perspectives')
  }
}
