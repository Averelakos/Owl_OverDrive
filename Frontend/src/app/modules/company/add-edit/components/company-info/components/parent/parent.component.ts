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
    this.companyService
    .searchParentCompany(input)
    .subscribe((response) => {
      console.log(response)
      this.listOfparentCompanies = response
    })
  }
}
