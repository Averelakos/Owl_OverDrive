import { Component, Input, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GameCoverDetailsDto, GameDetailsDto } from 'src/app/data/types/game/game-details-dto';

@Component({
  selector: 'app-mobile-logo',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './mobile-logo.component.html',
  styleUrls: ['./mobile-logo.component.scss']
})
export class MobileLogoComponent implements OnInit{
  @Input()gameCover: GameCoverDetailsDto
  @Input() gameModel:GameDetailsDto
  cover: any;

  ngOnInit(): void {
   this.convertBinaryToImage()
  }

  convertBinaryToImage() {
    if (this.gameCover?.imageData != null) {
      var binary = atob(this.gameCover?.imageData)
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
}
