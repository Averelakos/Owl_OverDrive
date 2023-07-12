import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject, finalize, first } from 'rxjs';
import { ResponsiveService, ResponsizeSize } from 'src/app/core/services/responsive.service';
import { CompanyService } from 'src/app/data/services/company.service';
import { ListCompanyDto } from 'src/app/data/types/company/list-companies';

@Component({
  selector: 'app-list-companies',
  templateUrl: './list-companies.component.html',
  styleUrls: ['./list-companies.component.scss']
})
export class ListCompaniesComponent implements OnInit {
  listOfCompanies!: Array<ListCompanyDto>;
  loading$ = new BehaviorSubject<boolean>(false)
  deviceType = ResponsizeSize
  constructor(private readonly companyService: CompanyService, private router: Router, public responsiveService: ResponsiveService){}
  
  ngOnInit(): void {
    this.fetchCompany();  
  }

  fetchCompany() {
    this.loading$.next(true)
    this.companyService
    .getAllCompanies()
    .pipe(first(),finalize(()=> this.loading$.next(false)))
    .subscribe((res) => {
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
