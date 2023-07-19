import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StandarCheckBoxButtonComponent } from 'src/app/common/checkboxes-buttons/standar-checkbox-button/standar-checkbox-button.component';
import { ResponsiveService, ResponsizeSize } from 'src/app/core/services/responsive.service';
import { FormGroupDirective } from '@angular/forms';
import { StandarInputComponent } from 'src/app/common/standar-input/standar-input.component';
import { SelectSearchInputValue, StandarSelectSearchComponent } from 'src/app/common/standar-select-search/standar-select-search.component';
import { LookupsService } from 'src/app/data/services/Lookups.service';
import { CheckMarkCheckBoxButtonComponent } from 'src/app/common/checkboxes-buttons/check-mark-checkbox-button/check-mark-checkbox-button.component';

@Component({
  selector: 'app-game-edition',
  standalone: true,
  imports: [CommonModule, StandarSelectSearchComponent, StandarInputComponent, CheckMarkCheckBoxButtonComponent],
  templateUrl: './game-edition.component.html',
  styleUrls: ['./game-edition.component.scss']
})
export class GameEditionComponent {
  deviceType = ResponsizeSize
  listOfStatuses: Array<SelectSearchInputValue> = []
  isEdition: boolean = false

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

  onClick(e: boolean) {
    this.isEdition = e 
  }
}
