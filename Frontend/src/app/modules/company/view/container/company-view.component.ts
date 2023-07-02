import { Component } from '@angular/core';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
import { ActivatedRoute, Router } from '@angular/router';
import { resolve } from 'dns';
import { LookupsService } from 'src/app/data/services/Lookups.service';
import { CompanyService } from 'src/app/data/services/company.service';
import { ImageService } from 'src/app/data/services/image.service';
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

  constructor(
    private readonly route: ActivatedRoute, 
    private companyService: CompanyService,
    private lookUpService: LookupsService,
    private readonly router: Router
    ){
    const companyId = this.route.snapshot.params['id']
    this.getCompany(companyId)
  }

  getCompany(companyId: number) {
    this.companyService.getCompany(companyId).subscribe((res) => {
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
