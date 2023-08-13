import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ResponsiveService, ResponsizeSize } from 'src/app/core/services/responsive.service';
import { FormArray, FormBuilder, FormGroup, FormGroupDirective, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { StandarInputComponent } from 'src/app/common/standar-input/standar-input.component';
import { SelectSearchInputValue, StandarSelectSearchComponent } from 'src/app/common/standar-select-search/standar-select-search.component';
import { LookupsService } from 'src/app/data/services/Lookups.service';
import { CheckMarkCheckBoxButtonComponent } from 'src/app/common/checkboxes-buttons/check-mark-checkbox-button/check-mark-checkbox-button.component';
import { EAlternativeTitleType } from 'src/app/core/enums/enum-alternative-title-type';

@Component({
  selector: 'app-game-alternative-titles',
  standalone: true,
  imports: [CommonModule, StandarSelectSearchComponent, StandarInputComponent, CheckMarkCheckBoxButtonComponent, FormsModule, ReactiveFormsModule],
  templateUrl: './game-alternative-titles.component.html',
  styleUrls: ['./game-alternative-titles.component.scss']
})
export class GameAlternativeTitleComponent {
  deviceType = ResponsizeSize
  isEdition: boolean = false
  alternativeTypes = EAlternativeTitleType
  alternativeTitleTypes: Array<SelectSearchInputValue> = []

  constructor(
    public responsiveService: ResponsiveService, 
    public parentForm: FormGroupDirective, 
    private readonly formBuilder: FormBuilder
  ){   
    this.convertEnumToArray()
  }

  general() : FormGroup {
    return this.parentForm.form.controls['general'] as FormGroup
  }

  alternativeTitles() : FormArray {
    return this.parentForm.form.controls['general']?.get('gameAlternativeNames') as FormArray
  }

  newAlternativeTitle(): FormGroup {
    return this.formBuilder.group({
      alternativeName: [null],
      alternativeTitleType: [null]
    })
  }

  addNewTitle() {
    this.alternativeTitles().push(this.newAlternativeTitle())
  }

  removeTitle(index: number) {
    this.alternativeTitles().removeAt(index)
  }

  convertEnumToArray() {
    const temp = Object.keys(this.alternativeTypes).filter((x) =>isNaN(Number(x)) )
    let count = 0
    temp.forEach((item) => {
      let temp: SelectSearchInputValue = {id:count, value:EAlternativeTitleType[item]}
      this.alternativeTitleTypes.push(temp)
      count++
    })
  }
}
