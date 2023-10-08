import { AfterContentChecked, ChangeDetectorRef, Component, OnDestroy } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LogoLoader } from 'src/app/common/loaders/logo-loader/logo-loader';
import { BehaviorSubject, Subscription, finalize, first } from 'rxjs';
import { DataLoaderOptions } from 'src/app/data/types/data-loader/data-loader-options';
import { ToastrService } from 'src/app/lib/toastr/toastr.service';
import { BannerResultActionService } from 'src/app/core/services/result-banner-action.service';
import { ServiceSearchResultData } from 'src/app/data/types/service-results/service-searc-result-data';
import { ResponsiveService, ResponsizeSize } from 'src/app/core/services/responsive.service';
import { ServiceResultBase } from 'src/app/data/types/service-results/service-result-base';
import { Router } from '@angular/router';
import { CompanyPaginationComponent } from './components/company-pagination/company-pagination.component';
import { CompanyService } from 'src/app/data/services/company.service';
import { CompanySimpleDto } from 'src/app/data/types/company/company-simple-dto';
import { CompanyListComponent } from './components/company-list/company-list.component';

@Component({
  selector: 'app-queryable-company-list',
  standalone: true,
  imports: [CommonModule,CompanyPaginationComponent, LogoLoader, CompanyListComponent],
  templateUrl: './queryable-company-list.component.html',
  styleUrls: ['./queryable-company-list.component.scss']
})
export class QueryableCompanyListComponent implements AfterContentChecked, OnDestroy {
  deviceType = ResponsizeSize
  companyList: Array<CompanySimpleDto>
  loading$ = new BehaviorSubject<boolean>(false)
  options: DataLoaderOptions
  pageSize: number = 20
  totalPages: number
  currentPage: number = 1
  searchInputSubscription: Subscription
  constructor(
    private companyService: CompanyService,
    private toastr: ToastrService,
    private resultBannerActionService: BannerResultActionService,
    public responsiveService: ResponsiveService,
    private changeDetector: ChangeDetectorRef,
    private router: Router
    )
  {
   this.options = {
    take: this.pageSize,
    skip: 0,
    searchString:null
   }
   this.fetchGame()

  //  this.searchInputSubscription =  this.companyService.searchString.subscribe((x) => {
  //   if(x) {
  //     this.options =  {
  //       take: this.pageSize,
  //       skip: 0,
  //       searchString: x
  //      }
  //      this.fetchGame()
  //   } else {
  //     this.options =  {
  //       take: this.pageSize,
  //       skip: 0,
  //       searchString: null
  //      }
  //      this.fetchGame()
  //   }
  //  })
  }

  ngAfterContentChecked(): void {
    this.changeDetector.detectChanges();
  }

  ngOnDestroy() {
    // this.searchInputSubscription.unsubscribe()
}

  changePage(event: any) {
    this.options.skip = this.pageSize * (event - 1)
    this.currentPage = event
    this.fetchGame()
  }

  fetchGame() {
    this.loading$.next(true)
    this.companyService
    .listCompanies(this.options)
    .pipe(first(),finalize(()=> this.loading$.next(false)))
    .subscribe({
      next:(response: ServiceSearchResultData<Array<CompanySimpleDto>>) => {
        if (response.success) {
          if(response.totalCount > 0) {
            this.companyList = response.result!
            this.totalPages = response.totalPages
          }
        } else {
          if (this.responsiveService.responsiveSize.value === this.deviceType.Desktop) {
            this.toastr.error(`$ There was a fail in the game search. Error: ${response.error}.`, 'Game Search List')
          } else {
            this.resultBannerActionService.error('Game Search List', `$ There was a fail in the game search. Error: ${response.error}.`)
          }
        }
      },
      error: (error: ServiceResultBase) => {
        if (this.responsiveService.responsiveSize.value === this.deviceType.Desktop) {
          this.toastr.error( `${error.error}`, 'Error')
        } else {
          this.resultBannerActionService.error('Error', `${error.error}`)
        }
      }
    })
  }

  openDetails(company: CompanySimpleDto) {
    this.router.navigate(['Company/view/' + company.name, {id:company.id} ])
  }
}
