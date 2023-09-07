import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input } from '@angular/core';
import { FormGroup, FormGroupDirective } from '@angular/forms';
import { StandarInputComponent } from 'src/app/common/standar-input/standar-input.component';
import { StandarTextareaComponent } from 'src/app/common/standar-textarea/standar-textarea.component';
import { ResponsiveService, ResponsizeSize } from 'src/app/core/services/responsive.service';
import { GameTypeComponent } from './components/game-type/game-type.component';
import { GameStatusComponent } from './components/game-status/game-status.component';
import { GameEditionComponent } from './components/game-edition/game-edition.component';
import { ImageCompressService } from 'src/app/shared/lib/image-compress/image-compress.service';
import { ImageService } from 'src/app/data/services/image.service';
import { FileParameter } from 'src/app/data/types/image/file-parameter';
import { DOC_ORIENTATION } from 'src/app/shared/lib/image-compress/model/DOC_ORIENTATION';
import { BehaviorSubject, finalize } from 'rxjs';

@Component({
  selector: 'app-general-info',
  standalone:true,
  imports:[CommonModule, StandarInputComponent, StandarTextareaComponent, GameTypeComponent, GameStatusComponent, GameEditionComponent],
  templateUrl: './general-info.component.html',
  styleUrls: ['./general-info.component.scss']
})
export class GeneralInfoComponent {
  uploading$ = new BehaviorSubject<boolean>(false)
  deviceType = ResponsizeSize
  formGroup!: FormGroup
  imageSize?: string | null
  imageGuid = new EventEmitter<string | null>()
  constructor(
    public responsiveService: ResponsiveService, 
    public parentForm: FormGroupDirective,
    private imageCompress: ImageCompressService, 
    private imageService: ImageService,
  ){}


  imageB64?: string | null
  fileSelected(e: any) {
    const file = e.target.files[0]
    this.convertFileToBase64(file)
  }

  convertFileToBase64(file: File) {
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
      console.log(fileParameter)
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
        this.parentForm.form.get('general')?.get('cover')?.patchValue(response)
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
