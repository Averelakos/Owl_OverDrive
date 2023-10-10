import { AfterContentInit, Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GameUserReviewsDto } from 'src/app/data/types/game/game-user-review';
import { Router } from '@angular/router';

@Component({
  selector: 'app-review-header',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './review-header.component.html',
  styleUrls: ['./review-header.component.scss']
})
export class ReviewHeaderComponent implements OnChanges {

  @Input() gameModel: GameUserReviewsDto
  cover!:any

  constructor(private readonly router: Router){}
  ngOnChanges(changes: SimpleChanges): void {
    this.convertBinaryToImage()
  }

  convertBinaryToImage() {
    if (this.gameModel?.cover?.imageData != null) {
      console.log('test')
      var binary = atob(this.gameModel?.cover?.imageData)
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
    this.router.navigate(['Game/view/' + this.gameModel.name, {id:this.gameModel.id} ])
  }
}
