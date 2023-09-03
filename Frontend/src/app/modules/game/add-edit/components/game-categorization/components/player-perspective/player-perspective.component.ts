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
    {id:1, name:'Auditory', isChecked: false},
    {id:2, name:'Bird view / Isometric', isChecked: false},
    {id:3, name:'First person', isChecked: false},
    {id:4, name:'Side view', isChecked: false},
    {id:5, name:'Text', isChecked: false},
    {id:6, name:'Third person', isChecked: false},
    {id:7, name:'Virtual Reality', isChecked: false},
  ]

  constructor(public parentForm: FormGroupDirective){}

  ngOnInit(): void {
    if(this.playerPerspectives()?.value != null && this.playerPerspectives()?.value != undefined) {
      this.playerPerspectives()?.value.forEach((entry) => {
        this.perpectives.forEach(element => {
          if(element.id === entry) {
            element.isChecked = true
          }
        });
      })
    }
  }

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
