import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ResponsiveService, ResponsizeSize } from 'src/app/core/services/responsive.service';
import { FormGroupDirective } from '@angular/forms';
import { SelectSearchInputValue, StandarSelectSearchComponent } from 'src/app/common/standar-select-search/standar-select-search.component';
import { LookupsService } from 'src/app/data/services/Lookups.service';
import { EGameStatus } from 'src/app/core/enums/enum-games-status';

@Component({
  selector: 'app-game-status',
  standalone: true,
  imports: [CommonModule, StandarSelectSearchComponent],
  templateUrl: './game-status.component.html',
  styleUrls: ['./game-status.component.scss']
})
export class GameStatusComponent {
  deviceType = ResponsizeSize
  gameStatus = EGameStatus
  listOfStatuses: Array<SelectSearchInputValue> = []

  constructor(
    public responsiveService: ResponsiveService, 
    public parentForm: FormGroupDirective, 
    // private readonly lookupService: LookupsService
  ){   this.convertEnumToArray()
  }

  // convertForSearchSelect() {
  //   this.lookupService.gameStatuses.forEach((item) => {
  //     let newItem: SelectSearchInputValue = {
  //       id: item.id,
  //       value: item.name
  //     } 
  //     this.listOfStatuses.push(newItem)
  //   })
  // }


  convertEnumToArray() {
    const temp = Object.keys(this.gameStatus).filter((x) =>isNaN(Number(x)))
    let count = 0
    temp.forEach((item) => {
      let temp: SelectSearchInputValue = {id:count, value:EGameStatus[item]}
      this.listOfStatuses.push(temp)
      count++
    })
  }
}
