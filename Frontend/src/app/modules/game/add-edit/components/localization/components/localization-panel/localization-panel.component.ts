import { Component, EventEmitter, Input, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StandarInputComponent } from 'src/app/common/standar-input/standar-input.component';
import { SelectSearchInputValue, StandarSelectSearchComponent } from 'src/app/common/standar-select-search/standar-select-search.component';
import { FormGroupDirective } from '@angular/forms';
import { ResponsiveService, ResponsizeSize } from 'src/app/core/services/responsive.service';
import { LookupsService } from 'src/app/data/services/Lookups.service';

@Component({
  selector: 'app-localization-panel',
  standalone: true,
  imports: [CommonModule, StandarInputComponent, StandarSelectSearchComponent],
  templateUrl: './localization-panel.component.html',
  styleUrls: ['./localization-panel.component.scss']
})
export class LocalizationPanelComponent {
  @Input() index!: number
  @Output() remove = new EventEmitter<number>
  deviceType = ResponsizeSize
  regions:Array<SelectSearchInputValue> = []

  constructor(public parentForm: FormGroupDirective, public responsiveService: ResponsiveService, private lookUpService: LookupsService){this.convertRegionToArray()}

  removeLocalization() {
    this.remove.emit(this.index)
  }

  convertRegionToArray(){
    this.lookUpService.regions.forEach((item) => {
      console.log(item)
      let temp: SelectSearchInputValue = {
        id: item.id,
        value: item.name
      }
      this.regions.push(temp)
    })
  }
}
