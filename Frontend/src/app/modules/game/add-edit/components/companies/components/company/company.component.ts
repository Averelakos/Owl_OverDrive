import { Component, EventEmitter, Input, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DropDownOption } from 'src/app/common/dropdown-input/standar-dropdown-menu/standar-dropdown-menu.component';
import { ResponsiveService, ResponsizeSize } from 'src/app/core/services/responsive.service';
import { SelectSearchInputValue, StandarSelectSearchComponent } from 'src/app/common/standar-select-search/standar-select-search.component';
import { FormArray, FormBuilder, FormGroup, FormGroupDirective } from '@angular/forms';
import { PlatformService } from 'src/app/data/services/platform.service';
import { LookupsService } from 'src/app/data/services/Lookups.service';
import { CompanyService } from 'src/app/data/services/company.service';
import { CheckMarkCheckBoxButtonComponent } from 'src/app/common/checkboxes-buttons/check-mark-checkbox-button/check-mark-checkbox-button.component';

@Component({
  selector: 'app-company',
  standalone: true,
  imports: [CommonModule, StandarSelectSearchComponent, CheckMarkCheckBoxButtonComponent], 
  templateUrl: './company.component.html',
  styleUrls: ['./company.component.scss'],
  providers:[PlatformService, CompanyService]
})
export class CompanyComponent {
  @Input() index!: number
  @Output() remove = new EventEmitter<number>
  deviceType = ResponsizeSize
  listOfPlatforms: Array<SelectSearchInputValue> = []
  listOfCompanies: Array<SelectSearchInputValue> = []

  types = [
    {id:1, name:'Publisher', control:'publisher'},
    {id:2, name:'Main Developer', control:'mainDeveloper'},
    {id:3, name:'Supporting Developer', control:'supportingDeveloper'},
    {id:4, name:'Porting Developer', control:'Porting Developer'},
  ]

  constructor(
    private readonly formBuilder: FormBuilder,
    public parentForm: FormGroupDirective, 
    public responsiveService: ResponsiveService, 
    private platformService: PlatformService,
    private companyService: CompanyService,
    )
    {}

  

    removeCompany() {
    this.remove.emit(this.index)
  }

  companies() {
    return this.parentForm.control.get('companies.' + this.index) as FormGroup
  }

  searchCompanies(input){
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

  searchPlatform(input){
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


  checkBoxClicked($event, item){
    let currentValue = this.companies()?.get(item.control)?.value
    this.companies()?.get(item.control)?.patchValue(!currentValue)
  }
}
