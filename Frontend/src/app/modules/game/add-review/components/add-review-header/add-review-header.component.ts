import { Component, Input, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Route, Router } from '@angular/router';

@Component({
  selector: 'app-add-review-header',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './add-review-header.component.html',
  styleUrls: ['./add-review-header.component.scss']
})
export class AddReviewHeaderComponent implements OnInit {
  @Input()gameData
  cover

  constructor(private readonly router: Router){}
  ngOnInit(): void {
    this.convertBinaryToImage()
  }
  
  convertBinaryToImage() {
    if (this.gameData?.cover?.imageData != null) {
      var binary = atob(this.gameData?.cover?.imageData)
      var array: any = [];
      for (var i = 0; i < binary.length; i++) {
        var byte = binary.charCodeAt(i)
          array.push(byte);
      }
      var blob =  new Blob([new Uint8Array(array)], { type: 'image/jpeg' });
      var reader = new FileReader
      reader.onloadend =() => {
        this.cover = reader.result
        // this.renderer.setStyle(
        //   this.headerImage.nativeElement,
        //   'backgroundImage',
        //   `url(${this.background})`
      // );
      }
      reader.readAsDataURL(blob)
    }
  }

  clickToCancel(){
    this.router.navigate(['Game/view/' + this.gameData.name, {id:this.gameData.id} ])
  }
}
