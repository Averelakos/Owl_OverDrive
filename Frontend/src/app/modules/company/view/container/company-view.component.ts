import { Component } from '@angular/core';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
import { ActivatedRoute } from '@angular/router';
import { resolve } from 'dns';
import { LookupsService } from 'src/app/data/services/Lookups.service';
import { CompanyService } from 'src/app/data/services/company.service';
import { SimpleCompany } from 'src/app/data/types/company/simple-company';
import { FileParameter } from 'src/app/data/types/image/file-parameter';
import { ImageCompressService } from 'src/app/shared/lib/image-compress/image-compress.service';
import { DOC_ORIENTATION } from 'src/app/shared/lib/image-compress/model/DOC_ORIENTATION';

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
    private domSanitizer: DomSanitizer,
    private imageCompress: ImageCompressService, 

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
    // this.companyLogo = URL.createObjectURL(this.company?.imageData)
    // this.companyLogo = this.company?.imageData
    if (this.company?.imageData != null) {
      console.log(this.company?.image)
      var blob = new Blob([this.company?.image['fileContents']], {type: this.company?.image.type})
      // var url = URL.createObjectURL(this.company?.imageData)
      // console.log(url)
      var reader = new FileReader()
      reader.onloadend =  () =>  {
      //  const base64String = reader.result?.toString().replace("data:", "")
      //       .replace(/^.+,/, "");

        // imageBase64Stringsep = base64String;

        // alert(imageBase64Stringsep);
        // this.companyLogo = base64String
        // console.log(base64String);
        console.log(reader.result)
        this.companyLogo = reader.result
      }
    reader.readAsDataURL(blob);
      
      // let img = new Image()
      // img.onload = () => {
      //   URL.revokeObjectURL(url)
      //   console.log('test')
      // }
      // img.src = url
      // console.log(url)
          // this.companyLogo = url
      // const image = () => {
      //   return new Promise(resolve => {
      //     const url = URL.createObjectURL(blob)
      //     let img = new Image()
      //     img.onload = () =>{
      //       URL.revokeObjectURL(url)
      //       resolve(img)
      //     }
      //     this.companyLogo = url
      //   })
      // }
      // const blobToImage = (blob) => {
      //   return new Promise(resolve => {
      //     const url = URL.createObjectURL(blob)
      //     let img = new Image()
      //     img.onload = () => {
      //       URL.revokeObjectURL(url)
      //       resolve(img)
      //     }
      //     img.src = url
      //   })
      // }
      // var reader = new FileReader()
      // reader.onloadend = () => this.compressBase64Image(blob, reader.result as string)
      // reader.readAsDataURL(blob)

      // var test = URL.createObjectURL(blob)
      // var test2 = this.domSanitizer.bypassSecurityTrustUrl(test)
      // console.log(blob)
      // this.companyLogo = test2
      // var reader = new FileReader()
      // reader.onloadend = () => {
      //   // console.log(reader.result)
      //   var test = URL.createObjectURL(blob)
      //   var test2 = this.domSanitizer.bypassSecurityTrustUrl(test)
      //   console.log(test)
      //   this.companyLogo = test2
        // this.companyLogo = `'${reader.result as string}'`
      // }
      // reader.readAsDataURL(blob)
      // console.log(reader.result)
      // console.log(blob)
      // let bytes = new Uint8Array(this.company?.imageData.length);
      // for (let i = 0; i < this.company?.imageData.length; i++) {
      //   bytes[i] = this.company?.imageData.charCodeAt(i);
      // }
      // var blob = new Blob([bytes], {type: 'image/png'})
      // // console.log(blob)
      // var reader = new FileReader()
      
      // reader.readAsDataURL(blob)
      // reader.onload = () => {
      //   var base64Image = reader.result
      //   // console.log(base64Image)
      //   this.companyLogo = base64Image
      // }
    }
    // console.log(this.company?.imageData)
  }

  compressBase64Image = (file: Blob, base64Image: string) => {
    debugger
    const size = file.size
    let ratio = 80
    let quality = 80
    // if (size > 5000000) {
    //   ratio = 20
    //   quality = 20
    // } else if (size > 2000000) {
    //   ratio = 50
    //   quality = 50
    // } else {
    //   this.imageSize = this.formatBytes(this.imageCompress.byteCount(base64Image))
    //   // this.imageForPreview.next(base64Image)
    //   this.companyLogo = base64Image
    //   const fileParameter: FileParameter = {
    //     data: file,
    //     fileName: file['name'],
    //   }
    //   // this.uploadFile(fileParameter)
    //   return
    // }
    this.imageCompress
      .compressFile(base64Image, DOC_ORIENTATION.NotDefined, ratio, quality)
      .then((result) => {
        // this.imageForPreview.next(result)
        this.imageSize = this.formatBytes(this.imageCompress.byteCount(result))
        this.companyLogo = result
        const blob = this.convertBase64ToBlob(result, file.type)
        const fileParameter: FileParameter = {
          data: blob,
          fileName: file.type,
        }
        // this.uploadFile(fileParameter)
      })
      .catch((err) => {})
  }

  formatBytes(a: any, b?: any) {
    if (0 == a) return '0 Bytes'
    var c = 1024,
      d = b || 2,
      e = ['Bytes', 'KB', 'MB', 'GB', 'TB', 'PB', 'EB', 'ZB', 'YB'],
      f = Math.floor(Math.log(a) / Math.log(c))
    return parseFloat((a / Math.pow(c, f)).toFixed(d)) + ' ' + e[f]
  }

  convertBase64ToBlob(base64String: any, mimeType: any) {
    const byteCharacters = Buffer.from(base64String,'base64').toString('binary')
    const byteNumbers = new Array(byteCharacters.length)

    for(let i = 0; i< byteCharacters.length; i++) {
      byteNumbers[i] = byteCharacters.charCodeAt(i)
    }

    const byteArray = new Uint8Array(byteNumbers)
    return new Blob([byteArray], {type: mimeType})
  }
}
