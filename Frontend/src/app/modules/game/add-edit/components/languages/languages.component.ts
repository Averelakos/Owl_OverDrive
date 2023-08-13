import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StadarInputPillOption, StandartPillSelectComponent } from 'src/app/common/pill-select/standart-pill-select/standart-pill-select.component';
import { FormGroupDirective, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LookupsService } from 'src/app/data/services/Lookups.service';

@Component({
  selector: 'app-languages',
  standalone: true,
  imports: [CommonModule, StandartPillSelectComponent, FormsModule, ReactiveFormsModule],
  templateUrl: './languages.component.html',
  styleUrls: ['./languages.component.scss']
})
export class LanguagesComponent {
  languagesList: Array<StadarInputPillOption> = []
  constructor(public parentForm: FormGroupDirective, private readonly lookupsService: LookupsService){
    this.convertForInputPill()
  }

  convertForInputPill() {
    this.lookupsService.languages.forEach((item) => {
      var tempItem: StadarInputPillOption = {
        id:item.id,
        value: item.name,
        isVisible: true
      }

      this.languagesList.push(tempItem)
    })
  }
}
