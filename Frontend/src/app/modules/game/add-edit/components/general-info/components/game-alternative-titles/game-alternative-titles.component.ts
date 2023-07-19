import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ResponsiveService, ResponsizeSize } from 'src/app/core/services/responsive.service';
import { FormArray, FormBuilder, FormGroup, FormGroupDirective, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { StandarInputComponent } from 'src/app/common/standar-input/standar-input.component';
import { SelectSearchInputValue, StandarSelectSearchComponent } from 'src/app/common/standar-select-search/standar-select-search.component';
import { LookupsService } from 'src/app/data/services/Lookups.service';
import { CheckMarkCheckBoxButtonComponent } from 'src/app/common/checkboxes-buttons/check-mark-checkbox-button/check-mark-checkbox-button.component';

@Component({
  selector: 'app-game-alternative-titles',
  standalone: true,
  imports: [CommonModule, StandarSelectSearchComponent, StandarInputComponent, CheckMarkCheckBoxButtonComponent, FormsModule, ReactiveFormsModule],
  templateUrl: './game-alternative-titles.component.html',
  styleUrls: ['./game-alternative-titles.component.scss']
})
export class GameAlternativeTitleComponent {
  deviceType = ResponsizeSize
  listOfStatuses: Array<SelectSearchInputValue> = []
  isEdition: boolean = false
  listOfAlternativeTitles

  gameTitleType: Array<SelectSearchInputValue> = [
    {id:1, value: 'Abbreviation'},
    {id:2, value: 'Acronym'},
    {id:3, value: 'Alternative spelling'},
    {id:4, value: 'Alternative title'},
    {id:5, value: 'Chinese title - simplified'},
    {id:6, value: 'Chinese title - traditional'},
    {id:7, value: 'European title'},
    {id:8, value: 'French title'},
    {id:9, value: 'German title'},
    {id:10, value: 'Italian title'},
    {id:11, value: 'Japanese title - original'},
    {id:12, value: 'Japanese title - romanization'},
    {id:13, value: 'Japanese title - stylized'},
    {id:14, value: 'Japanese title - translated'},
    {id:15, value: 'Korean title'},
    {id:16, value: 'Korean title - romanization'},
    {id:17, value: 'Korean title - translated'},
    {id:18, value: 'Polish title'},
    {id:19, value: 'Portuguese title'},
    {id:20, value: 'Russian title'},
    {id:21, value: 'Spanish title'},
    {id:22, value: 'Stylized title'},
    {id:23, value: 'Working title'},
  ]

  constructor(
    public responsiveService: ResponsiveService, 
    public parentForm: FormGroupDirective, 
    private readonly lookupService: LookupsService,
    private readonly formBuilder: FormBuilder
  ){   
    this.convertForSearchSelect()
  }

  convertForSearchSelect() {
    this.gameTitleType.forEach((item) => {
      let newItem: SelectSearchInputValue = {
        id: item.id,
        value: item.value
      } 
      this.listOfStatuses.push(newItem)
    })
  }

  general() : FormGroup {
    return this.parentForm.form.controls['general'] as FormGroup
  }

  alternativeTitles() : FormArray {
    return this.parentForm.form.controls['general']?.get('gameAlternativeNames') as FormArray
  }

  newAlternativeTitle(): FormGroup {
    return this.formBuilder.group({
      title: [null],
      type: [null]
    })
  }

  addNewTitle() {
    this.alternativeTitles().push(this.newAlternativeTitle())
  }

  removeTitle(index: number) {
    this.alternativeTitles().removeAt(index)
  }
}
