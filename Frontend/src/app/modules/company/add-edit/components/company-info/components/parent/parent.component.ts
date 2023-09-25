import { Component } from '@angular/core';
import { SelectSearchInputValue } from 'src/app/common/standar-select-search/standar-select-search.component';
import { CompanyService } from 'src/app/data/services/company.service';

@Component({
  selector: 'app-parent',
  templateUrl: './parent.component.html',
  styleUrls: ['./parent.component.scss']
})
export class ParentComponent {
  title: string = 'Parent company'
  listOfparentCompanies: Array<SelectSearchInputValue> = []


  constructor( private readonly companyService: CompanyService) {}

  searchParentCompany(input){
    if (input.length > 0) {
      this.companyService
      .searchParentCompany(input)
      .subscribe((response) => {
        this.listOfparentCompanies.length = 0
        if (response.length > 0) {
          response.forEach(element => {
            this.listOfparentCompanies.push({
              id:element.id,
              value: element.name
            })
          });
        } 
      })
    } else {
      this.listOfparentCompanies.length = 0
    }
  }

  retrieveSearchCompany(input){
      this.companyService
      .retrieveSearchCompany(input)
      .subscribe((response) => {
        this.listOfparentCompanies.length = 0
            this.listOfparentCompanies.push({
              id:response.id,
              value: response.name
            })
      })
  }
}
