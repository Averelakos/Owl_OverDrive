import { CommonModule } from '@angular/common';
import { AfterViewInit, Component, EventEmitter, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { FormGroup, FormGroupDirective } from '@angular/forms';
import { BehaviorSubject, finalize } from 'rxjs';
import { StandarInputComponent } from 'src/app/common/standar-input/standar-input.component';
import { StandarTextareaComponent } from 'src/app/common/standar-textarea/standar-textarea.component';
import { ResponsiveService, ResponsizeSize } from 'src/app/core/services/responsive.service';
import { CompanyService } from 'src/app/data/services/company.service';
import { ImageService } from 'src/app/data/services/image.service';
import { FileParameter } from 'src/app/data/types/image/file-parameter';
import { ImageCompressService } from 'src/app/shared/lib/image-compress/image-compress.service';
import { DOC_ORIENTATION } from 'src/app/shared/lib/image-compress/model/DOC_ORIENTATION';

@Component({
  selector: 'app-company-general-details',
  templateUrl: './company-general-details.component.html',
  styleUrls: ['./company-general-details.component.scss'],
  standalone:true,
  imports:[CommonModule, StandarInputComponent, StandarTextareaComponent],
  providers: [ImageCompressService, ImageService]
})
export class CompanyGeneralDetailsComponent implements OnInit, OnChanges {
  responsiveSizes = ResponsizeSize
  uploading$ = new BehaviorSubject<boolean>(false)
  @Input() companyLogoData?: string | null = null
  @Input() imageData?: string | null = null
  
  constructor(
    public responsiveService: ResponsiveService, 
    public parentForm: FormGroupDirective, 
    private imageCompress: ImageCompressService, 
    private imageService: ImageService,
    ) {}
  
  ngOnInit(): void {
    let generalDetails: FormGroup = this.parentForm.form.controls['generalDetails'] as FormGroup
    this.imageGuid.subscribe((x) => generalDetails.patchValue({image: x}))
  }

  ngOnChanges(changes: SimpleChanges): void {
      if (changes['companyLogoData'] != null && changes['companyLogoData'].previousValue == null && changes['companyLogoData'].currentValue != null) {
        this.convertBinaryToImage(changes['companyLogoData'].currentValue)
      }
  }

  imageB64?: string | null
  imageSize?: string | null
  imageGuid = new EventEmitter<string | null>()

  @Input() companyLogo?: number
  companyLogoUrlService?:string

  convertBase64ToBlob(base64String: any, mimeType: any) {
    const byteCharacters = Buffer.from(base64String,'base64').toString('binary')
    const byteNumbers = new Array(byteCharacters.length)

    for(let i = 0; i< byteCharacters.length; i++) {
      byteNumbers[i] = byteCharacters.charCodeAt(i)
    }

    const byteArray = new Uint8Array(byteNumbers)
    return new Blob([byteArray], {type: mimeType})
  }
  
  clear(fileUploadInput: any) {
    fileUploadInput.value = ''
    this.imageB64 = null
    this.imageSize = null
    this.imageGuid.next(null)
  }

  fileSelected(e: any) {
    const file = e.target.files[0]
    this.convertFileToBase64(file)
  }

  public convertFileToBase64(file: File) {
    const reader = new FileReader()
    reader.onloadend = () => this.compressBase64Image(file, reader.result as string)
    reader.readAsDataURL(file)
  }

  compressBase64Image = (file: Blob, base64Image: string) => {
    const size = file.size
    let ratio = 80
    let quality = 80
    if (size > 5000000) {
      ratio = 20
      quality = 20
    } else if (size > 2000000) {
      ratio = 50
      quality = 50
    } else {
      this.imageSize = this.formatBytes(this.imageCompress.byteCount(base64Image))
      // this.imageForPreview.next(base64Image)
      this.imageB64 = base64Image
      const fileParameter: FileParameter = {
        data: file,
        fileName: file['name'],
      }
      this.uploadFile(fileParameter)
      return
    }
    this.imageCompress
      .compressFile(base64Image, DOC_ORIENTATION.NotDefined, ratio, quality)
      .then((result) => {
        // this.imageForPreview.next(result)
        this.imageSize = this.formatBytes(this.imageCompress.byteCount(result))
        this.imageB64 = result
        const blob = this.convertBase64ToBlob(result, file.type)
        const fileParameter: FileParameter = {
          data: blob,
          fileName: file.type,
        }
        this.uploadFile(fileParameter)
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

  uploadFile = (fileParameter: FileParameter) => {
    this.uploading$.next(true)
    this.imageService
      .uploadImages(fileParameter)
      .pipe(finalize(() => this.uploading$.next(false)))
      .subscribe((response) => {
        this.imageGuid.emit(response)
      })
  }

  convertBinaryToImage(imageData) {
    if (imageData != null) {
      var binary = atob(imageData)
      var array: any = [];
      for (var i = 0; i < binary.length; i++) {
        var byte = binary.charCodeAt(i)
          array.push(byte);
      }
      var blob =  new Blob([new Uint8Array(array)], { type: 'image/jpeg' });
      var reader = new FileReader
      reader.onloadend =() => {
        this.imageB64 = reader.result?.toString()
      }

      reader.readAsDataURL(blob)
    }
  }
}
