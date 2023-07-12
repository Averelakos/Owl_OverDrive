import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BehaviorSubject, finalize, first } from 'rxjs';
import { ResponsiveService, ResponsizeSize } from 'src/app/core/services/responsive.service';
import { LookupsService } from 'src/app/data/services/Lookups.service';
import { CompanyService } from 'src/app/data/services/company.service';
import { SimpleCompany } from 'src/app/data/types/company/simple-company';

@Component({
  selector: 'app-company-view',
  templateUrl: './company-view.component.html',
  styleUrls: ['./company-view.component.scss']
})
export class CompanyViewComponent {
  
  company?:SimpleCompany
  twitterStyle: string = 'color:#fff; background:#00acee;'
  officialWebsiteStyle: string = 'color:#fff; background:#c15375'
  country?: string
  status?: string
  companyLogo: any
  imageSize?: string | null
  loading$ = new BehaviorSubject<boolean>(false)
  deviceType = ResponsizeSize

  constructor(
    private readonly route: ActivatedRoute, 
    private companyService: CompanyService,
    private lookUpService: LookupsService,
    private readonly router: Router,
    public responsiveService: ResponsiveService
    ){
    const companyId = this.route.snapshot.params['id']
    this.getCompany(companyId)
    responsiveService.responsiveSize
  }

  getCompany(companyId: number) {
    this.loading$.next(true)
    this.companyService.getCompany(companyId)
    .pipe(first(),finalize(()=> this.loading$.next(false)))
    .subscribe((res) => {
      this.company = res
      this.retrieveExtaInfo()
    })
  }

  retrieveExtaInfo() {
    this.country = this.lookUpService.getCountryById(this.company?.countryId)?.name
    this.status = this.lookUpService.getStatusById(this.company?.statusId)?.name
    this.convertBinaryToImage()
  }

  convertBinaryToImage() {
    if (this.company?.imageData != null) {
      var binary = atob(this.company.imageData)
      var array: any = [];
      for (var i = 0; i < binary.length; i++) {
        var byte = binary.charCodeAt(i)
          array.push(byte);
      }
      var blob =  new Blob([new Uint8Array(array)], { type: 'image/jpeg' });
      var reader = new FileReader
      reader.onloadend =() => {
        this.companyLogo = reader.result
      }

      reader.readAsDataURL(blob)
  }
}

clickToEdit() {
 this.router.navigate(['Company/edit/'+this.company?.name,{id:this.company?.id}]);   
}

}
