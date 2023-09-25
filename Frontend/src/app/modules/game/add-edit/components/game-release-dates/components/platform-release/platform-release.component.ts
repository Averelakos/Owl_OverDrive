import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ResponsiveService, ResponsizeSize } from 'src/app/core/services/responsive.service';
import { FormArray, FormBuilder, FormGroup, FormGroupDirective, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { StandarInputComponent } from 'src/app/common/standar-input/standar-input.component';
import { SelectSearchInputValue, StandarSelectSearchComponent } from 'src/app/common/standar-select-search/standar-select-search.component';
import { ReleaseComponent } from '../release/release.component';
import { PlatformService } from 'src/app/data/services/platform.service';
import { DropDownOption } from 'src/app/common/dropdown-input/standar-dropdown-menu/standar-dropdown-menu.component';
import { LookupsService } from 'src/app/data/services/Lookups.service';
import { BehaviorSubject } from 'rxjs';

@Component({
  selector: 'app-platform-release',
  standalone: true,
  imports: [CommonModule, StandarInputComponent, StandarSelectSearchComponent, ReleaseComponent, FormsModule, ReactiveFormsModule],
  templateUrl: './platform-release.component.html',
  styleUrls: ['./platform-release.component.scss'],
  providers: [PlatformService]
})
export class PlatformReleaseComponent {
  @Input() index!: number
  @Output() remove = new EventEmitter<number>
  deviceType = ResponsizeSize
  listOfPlatforms: Array<SelectSearchInputValue> = []
  listOfRegions: Array<DropDownOption> = []
  listOfGameStatues: Array<DropDownOption> = []
  platform$: BehaviorSubject<SelectSearchInputValue | null> =  new BehaviorSubject<SelectSearchInputValue | null>(null)

  constructor(
    private readonly formBuilder: FormBuilder,
    public parentForm: FormGroupDirective, 
    public responsiveService: ResponsiveService, 
    private platformService: PlatformService,
    private readonly lookupsService: LookupsService
    )
    {
      this.convertRegionList()
      this.convertGameStatusesList()
    }

  

  removePlatformRelease() {
    this.remove.emit(this.index)
  }

  releaseDates() {
    return this.parentForm.control.get('releaseDates.' + this.index) as FormGroup
  }

  release() {
    return this.releaseDates().get('releases') as FormArray
  }

  searchPlatform(input){
    if (input.length > 0) {
      this.platformService
      .searchPlatform(input)
      .subscribe((response) => {
        this.listOfPlatforms.length = 0
        if (response.length > 0) {
          response.forEach(element => {
            this.listOfPlatforms.push({
              id:element.id,
              value: element.name
            })
          });
        } 
      })
    } else {
      this.listOfPlatforms.length = 0
    }
  }

  retrieveSearchPlatforms(input){
    
    this.platformService
    .getPlatformById(input)
    .subscribe((response) => {
      this.listOfPlatforms.length = 0
      this.platform$.next({
        id:response.id,
        value: response.name,
      })
    })
  
}

  releaseForm(): FormGroup {
    return this.formBuilder.group({
      date:[null],
      region:[null],
      status:[null],
    })
  }

  addNewIndex() {
    this.release().push(this.releaseForm())
  }

  removeIndex(index: number) {
    this.release().removeAt(index)
  }

  convertRegionList() {
    this.lookupsService.regions.forEach( (item) => {
      let temp: DropDownOption = {
        id: item.id,
        value: item.name + ' ['+ item.regionCode + ']'
      }
      this.listOfRegions.push(temp)
    })
  }

  convertGameStatusesList() {
    this.lookupsService.gameStatuses.forEach( (item) => {
      let temp: DropDownOption = {
        id: item.id,
        value: item.name
      }
      this.listOfGameStatues.push(temp)
    })
  }

}
