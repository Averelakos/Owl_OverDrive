import { Component, OnInit } from '@angular/core';
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
export class GameModesComponent implements OnInit{
  gamemode = [
    {id:1, name:'Battle Royale', isChecked: false},
    {id:2, name:'Co-operative', isChecked: false},
    {id:3, name:'Massively Multiplayer Online(MMO)', isChecked: false},
    {id:4, name:'Multiplayer', isChecked: false},
    {id:5, name:'Single player', isChecked: false},
    {id:6, name:'Split screen', isChecked: false},
  ]

  constructor(public parentForm: FormGroupDirective){}

  ngOnInit(): void {
    if(this.gameModes()?.value != null && this.gameModes()?.value != undefined) {
      this.gameModes()?.value.forEach((entry) => {
        this.gamemode.forEach(element => {
          if(element.id === entry) {
            element.isChecked = true
          }
        });
      })
    }
  }

  checkBoxClicked(e: any, item) {
    let temp = this.gameModes()?.value
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
