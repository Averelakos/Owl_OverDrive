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
  audiosList: Array<StadarInputPillOption> = []
  subtitlessList: Array<StadarInputPillOption> = []
  interfacesList: Array<StadarInputPillOption> = []
  constructor(public parentForm: FormGroupDirective, private readonly lookupsService: LookupsService){
    this.convertForInputPill()
  }

  convertForInputPill() {
    this.lookupsService.languages.forEach((item) => {
      var audioItem: StadarInputPillOption = {
        id:item.id,
        value: item.name,
        isVisible: true
      }

      var interItem: StadarInputPillOption = {
        id:item.id,
        value: item.name,
        isVisible: true
      }

      var subItem: StadarInputPillOption = {
        id:item.id,
        value: item.name,
        isVisible: true
      }

      this.audiosList.push(audioItem)
      this.interfacesList.push(interItem)
      this.subtitlessList.push(subItem)
    })

  }
}
