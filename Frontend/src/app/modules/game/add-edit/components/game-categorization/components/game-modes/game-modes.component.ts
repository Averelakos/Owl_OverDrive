import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormGroupDirective } from '@angular/forms';
import { CheckMarkCheckBoxButtonComponent } from 'src/app/common/checkboxes-buttons/check-mark-checkbox-button/check-mark-checkbox-button.component';

@Component({
  selector: 'app-game-modes',
  standalone: true,
  imports: [CommonModule, CheckMarkCheckBoxButtonComponent],
  templateUrl: './game-modes.component.html',
  styleUrls: ['./game-modes.component.scss']
})
export class GameModesComponent {
  gamemode = [
    {id:1, name:'Battle Royale'},
    {id:2, name:'Co-operative'},
    {id:3, name:'Massively Multiplayer Online(MMO)'},
    {id:4, name:'Multiplayer'},
    {id:5, name:'Single player'},
    {id:6, name:'Split screen'},
  ]

  constructor(public parentForm: FormGroupDirective){}

  checkBoxClicked(e: any, item) {
    let temp = this.gameModes()?.value
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
      this.gameModes()?.patchValue(changedTemp)
    } else {
      temp.push(item.id)
      this.gameModes()?.patchValue(temp)
    }
  }

  gameModes() {
    return this.parentForm.control.get('categorization.gameMode')
  }
}
