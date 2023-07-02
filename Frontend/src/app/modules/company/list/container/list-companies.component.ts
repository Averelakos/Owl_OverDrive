import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CompanyService } from 'src/app/data/services/company.service';
import { ListCompanyDto } from 'src/app/data/types/company/list-companies';

@Component({
  selector: 'app-list-companies',
  templateUrl: './list-companies.component.html',
  styleUrls: ['./list-companies.component.scss']
})
export class ListCompaniesComponent implements OnInit {
  listOfCompanies!: Array<ListCompanyDto>;
  constructor(private readonly companyService: CompanyService, private router: Router){}
  
  ngOnInit(): void {
    this.fetchCompany();  
  }

  fetchCompany() {
    this.companyService.getAllCompanies().subscribe((res) => {
      this.listOfCompanies = res
    })
  }

  clickNewCompany() {
    this.router.navigate(['Company/add']);
  }

  clickToViewCompany(item: ListCompanyDto) {
    this.router.navigate(['Company/view/' + item.name, {id:item.id} ])
    
  }
}
