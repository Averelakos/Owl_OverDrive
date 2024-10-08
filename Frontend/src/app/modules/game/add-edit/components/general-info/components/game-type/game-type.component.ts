import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StandarCheckBoxButtonComponent } from 'src/app/common/checkboxes-buttons/standar-checkbox-button/standar-checkbox-button.component';
import { ResponsiveService, ResponsizeSize } from 'src/app/core/services/responsive.service';
import { FormGroupDirective } from '@angular/forms';
import { SelectSearchInputValue, StandarSelectSearchComponent } from 'src/app/common/standar-select-search/standar-select-search.component';
import { EGameType } from 'src/app/core/enums/enum-game-type';
import { GameService } from 'src/app/data/services/game.service';
import { BehaviorSubject } from 'rxjs';

@Component({
  selector: 'app-game-type',
  standalone: true,
  imports: [CommonModule, StandarCheckBoxButtonComponent, StandarSelectSearchComponent],
  templateUrl: './game-type.component.html',
  styleUrls: ['./game-type.component.scss']
})
export class GameTypeComponent {
  listOfGames: Array<SelectSearchInputValue> = []
  game$: BehaviorSubject<SelectSearchInputValue | null> =  new BehaviorSubject<SelectSearchInputValue | null>(null)
  deviceType = ResponsizeSize
  gameType = EGameType
  gameTypeOptions: Array<any> = []

  main: any = {id:0, type:EGameType.Main,checked: true}

  constructor(
    public responsiveService: ResponsiveService, 
    public parentForm: FormGroupDirective, 
    private gameService: GameService,
  ){
    this.convertEnumToArray() 
    if (this.parentForm.form.get('general')?.get('updateGameType')?.value != null) {
      this.gameTypeOptions.forEach((item) => {
        if (item.type === this.parentForm.form.get('general')?.get('updateGameType')?.value) {
          this.onClick(item)
        }
      })
    } else {
      this.clickMainGame()
    }
  }

  clickMainGame() {
    this.main.checked = true
    this.gameTypeOptions.forEach((item) => {
      item.isChecked = false
    })
    this.parentForm.form.get('general')?.get('updateGameType')?.patchValue(0)
    this.parentForm.form.get('general')?.get('updatedGameId')?.patchValue(null)
  }

  onClick(option: any){
    this.main.checked = false
      this.gameTypeOptions.forEach((item) => {
        if (item.id === option.id) {
          item.isChecked = true  
          this.parentForm.form.get('general')?.get('updateGameType')?.patchValue(item.type)
        } else {
          item.isChecked = false
        }
      })
  }

  convertEnumToArray() {
    const temp = Object.keys(this.gameType).filter((x) =>isNaN(Number(x)) && EGameType[x] !== EGameType.Main)
    let count = 1
    temp.forEach((item) => {
      let temp = {id:count, type:EGameType[item],checked: false}
      this.gameTypeOptions.push(temp)
      count++
    })
  }

  searchGames(input){
    if (input.length > 0) {
      this.gameService
      .searchParentGame(input)
      .subscribe((response) => {
        this.listOfGames.length = 0
        if (response.length > 0) {
          response.forEach(element => {
            this.listOfGames.push({
              id:element.id,
              value: element.name
            })
          });
        } 
      })
    } else {
      this.listOfGames.length = 0
    }
  }

  retrieveSearchGames(input){
    
    this.gameService
    .getGameById(input)
    .subscribe((response) => {
      this.listOfGames.length = 0
      this.game$.next({
        id:response.id,
        value: response.name,
      })
    })
  
}
}
