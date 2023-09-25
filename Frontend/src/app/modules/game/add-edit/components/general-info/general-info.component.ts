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
import { CreateImageDto } from 'src/app/data/types/game/create-game';

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

  constructor(
    public responsiveService: ResponsiveService, 
    public parentForm: FormGroupDirective,
  ){
    let image = this.parentForm.form.get('general')?.get('test')?.value
  }


  imageB64?: string | null
  fileSelected(e: any) {
    const file = e.target.files[0]
    this.convertFileToByteArray(file)

    const reader = new FileReader()
    reader.onloadend = () => {
      this.imageB64 = reader.result as string
    }
    reader.readAsDataURL(file)
  }


  convertFileToByteArray(file: File) {
    const reader = new FileReader()
    let fileByteArray: any = []

    reader.onloadend = (evt) => {
      if (evt?.target?.readyState == FileReader.DONE) {
        
        let arrayBuffer = evt.target.result as ArrayBuffer,
            array = new Uint8Array(arrayBuffer);
        for (let byte of array) {
            fileByteArray.push(byte);
        }

        const fileParameter: CreateImageDto = {
          imageData: fileByteArray,
          imageTitle: file['name'],
        }

      this.parentForm.form.get('general')?.get('cover')?.patchValue(fileParameter)
      }
    }

    reader.readAsArrayBuffer(file)
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

  // convertBinaryToImage() {
  //   if (this.item?.imageData != null) {
  //     var binary = atob(this.item.imageData)
  //     var array: any = [];
  //     for (var i = 0; i < binary.length; i++) {
  //       var byte = binary.charCodeAt(i)
  //         array.push(byte);
  //     }
  //     var blob =  new Blob([new Uint8Array(array)], { type: 'image/jpeg' });
  //     var reader = new FileReader
  //     reader.onloadend =() => {
  //       this.cover = reader.result
  //       console.log(this.cover)
  //       console.log('api', this.item?.imageData)
  //       this.renderer.setStyle(
  //         this.containerElement.nativeElement,
  //         'backgroundImage',
  //         `url(${this.cover})`
  //     );

  //     }
  //     reader.readAsDataURL(blob)
  //   }
}
