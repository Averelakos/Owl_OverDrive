import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ResponsiveService, ResponsizeSize } from 'src/app/core/services/responsive.service';
import { FormGroupDirective } from '@angular/forms';
import { StandarInputComponent } from 'src/app/common/standar-input/standar-input.component';
import { SelectSearchInputValue, StandarSelectSearchComponent } from 'src/app/common/standar-select-search/standar-select-search.component';
import { CheckMarkCheckBoxButtonComponent } from 'src/app/common/checkboxes-buttons/check-mark-checkbox-button/check-mark-checkbox-button.component';
import { CompanyService } from 'src/app/data/services/company.service';
import { GameService } from 'src/app/data/services/game.service';

@Component({
  selector: 'app-game-edition',
  standalone: true,
  imports: [CommonModule, StandarSelectSearchComponent, StandarInputComponent, CheckMarkCheckBoxButtonComponent],
  templateUrl: './game-edition.component.html',
  styleUrls: ['./game-edition.component.scss'],
  providers:[CompanyService]
})
export class GameEditionComponent {
  deviceType = ResponsizeSize
  listOfGames: Array<SelectSearchInputValue> = []
  isEdition: boolean = false

  constructor(
    public responsiveService: ResponsiveService, 
    public parentForm: FormGroupDirective, 
    private gameService: GameService,
  ){}

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

  onClick(e: boolean) {
    this.isEdition = e 
  }
}
