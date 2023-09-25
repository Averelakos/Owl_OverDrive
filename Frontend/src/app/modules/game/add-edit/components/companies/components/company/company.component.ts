import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DropDownOption, StandarDropdownMenuComponent } from 'src/app/common/dropdown-input/standar-dropdown-menu/standar-dropdown-menu.component';
import { ResponsiveService, ResponsizeSize } from 'src/app/core/services/responsive.service';
import { SelectSearchInputValue, StandarSelectSearchComponent } from 'src/app/common/standar-select-search/standar-select-search.component';
import { FormArray, FormBuilder, FormGroup, FormGroupDirective } from '@angular/forms';
import { PlatformService } from 'src/app/data/services/platform.service';
import { LookupsService } from 'src/app/data/services/Lookups.service';
import { CompanyService } from 'src/app/data/services/company.service';
import { CheckMarkCheckBoxButtonComponent } from 'src/app/common/checkboxes-buttons/check-mark-checkbox-button/check-mark-checkbox-button.component';
import { StadarInputPillOption, StandartPillSelectComponent } from 'src/app/common/pill-select/standart-pill-select/standart-pill-select.component';
import { BehaviorSubject } from 'rxjs';

@Component({
  selector: 'app-company',
  standalone: true,
  imports: [CommonModule, StandarSelectSearchComponent, CheckMarkCheckBoxButtonComponent, StandartPillSelectComponent], 
  templateUrl: './company.component.html',
  styleUrls: ['./company.component.scss'],
  providers:[PlatformService, CompanyService]
})
export class CompanyComponent implements OnInit{
  @Input() index!: number
  @Output() remove = new EventEmitter<number>
  deviceType = ResponsizeSize
  listOfPlatforms: Array<StadarInputPillOption> = []
  listOfCompanies: Array<SelectSearchInputValue> = []
  company$: BehaviorSubject<SelectSearchInputValue | null> =  new BehaviorSubject<SelectSearchInputValue | null>(null)
  platform$: BehaviorSubject<StadarInputPillOption | null> =  new BehaviorSubject<StadarInputPillOption | null>(null)

  types = [
    {id:1, name:'Publisher', control:'publisher', isChecked: false},
    {id:2, name:'Main Developer', control:'mainDeveloper', isChecked: false},
    {id:3, name:'Supporting Developer', control:'supportingDeveloper', isChecked: false},
    {id:4, name:'Porting Developer', control:'portingDeveloper', isChecked: false},
  ]

  constructor(
    public parentForm: FormGroupDirective, 
    public responsiveService: ResponsiveService, 
    private platformService: PlatformService,
    private companyService: CompanyService,
  )
  {}

  ngOnInit(): void {
    this.types.forEach((entry) => {
      if(this.companies()?.get(entry.control)?.value != null) {
        entry.isChecked = this.companies().get(entry.control)?.value
      }
    })
  }



  removeCompany() {
  this.remove.emit(this.index)
  }

  companies() {
    return this.parentForm.control.get('companies.' + this.index) as FormGroup
  }

  searchPlatforms(input){
    if (input.length > 0) {
      this.platformService
      .searchPlatform(input)
      .subscribe((response) => {
        this.listOfPlatforms.length = 0
        if (response.length > 0) {
          response.forEach(element => {
            this.listOfPlatforms.push({
              id:element.id,
              value: element.name,
              isVisible: true
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
          isVisible: true
        })
      })
    
  }

  searchCompanies(input){
    if (input.length > 0) {
      this.companyService
      .searchParentCompany(input)
      .subscribe((response) => {
        this.listOfCompanies.length = 0
        if (response.length > 0) {
          response.forEach(element => {
            this.listOfCompanies.push({
              id:element.id,
              value: element.name
            })
          });
        } 
      })
    } else {
      this.listOfCompanies.length = 0
    }
  }

  retrieveSearchCompany(input){
    this.companyService
    .retrieveSearchCompany(input)
    .subscribe((response) => {
      this.listOfCompanies.length = 0
this.company$.next({
  id:response.id,
  value: response.name
})
          // this.listOfCompanies.push({
          //   id:response.id,
          //   value: response.name
          // })
    })
}


  checkBoxClicked($event, item){
    let currentValue = this.companies()?.get(item.control)?.value
    this.companies()?.get(item.control)?.patchValue(!currentValue)
  }
}
