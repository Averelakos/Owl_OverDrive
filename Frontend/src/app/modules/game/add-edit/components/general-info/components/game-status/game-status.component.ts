import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ResponsiveService, ResponsizeSize } from 'src/app/core/services/responsive.service';
import { FormGroupDirective } from '@angular/forms';
import { SelectSearchInputValue, StandarSelectSearchComponent } from 'src/app/common/standar-select-search/standar-select-search.component';
import { LookupsService } from 'src/app/data/services/Lookups.service';

@Component({
  selector: 'app-game-status',
  standalone: true,
  imports: [CommonModule, StandarSelectSearchComponent],
  templateUrl: './game-status.component.html',
  styleUrls: ['./game-status.component.scss']
})
export class GameStatusComponent {
  deviceType = ResponsizeSize
  listOfStatuses: Array<SelectSearchInputValue> = []

  gameStatus = [
    {id:1, name: 'ALPHA'},
    {id:2, name: 'BETA'},
    {id:3, name: 'Early Access'},
    {id:4, name: 'Offline'},
    {id:5, name: 'Cancelled'},
    {id:6, name: 'Rumored'},
    {id:7, name: 'Delisted'},
  ]

  constructor(
    public responsiveService: ResponsiveService, 
    public parentForm: FormGroupDirective, 
    private readonly lookupService: LookupsService
  ){   this.convertForSearchSelect()
  }

  convertForSearchSelect() {
    this.gameStatus.forEach((item) => {
      let newItem: SelectSearchInputValue = {
        id: item.id,
        value: item.name
      } 
      this.listOfStatuses.push(newItem)
    })
  }
}
