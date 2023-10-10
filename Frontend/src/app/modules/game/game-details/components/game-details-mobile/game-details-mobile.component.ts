import { Component, ElementRef, Input, Renderer2, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GameDetailsDto } from 'src/app/data/types/game/game-details-dto';
import { MobileHeaderInfoComponent } from './components/header-info/mobile-header-info.component';
import { MobileBodyInfoComponent } from './components/body-info/mobile-body-info.component';

@Component({
  selector: 'app-game-details-mobile',
  standalone: true,
  imports: [CommonModule, MobileHeaderInfoComponent, MobileBodyInfoComponent],
  templateUrl: './game-details-mobile.component.html',
  styleUrls: ['./game-details-mobile.component.scss']
})
export class GameDetailsMobileComponent {
  @ViewChild('headerImage') headerImage: ElementRef
  @Input()gameModel: GameDetailsDto
  background: any
  constructor(private renderer: Renderer2){}

  ngOnInit(): void {
    this.convertBinaryToImage()
  }
  

  convertBinaryToImage() {
    if (this.gameModel.background?.imageData != null) {
      var binary = atob(this.gameModel.background?.imageData)
      var array: any = [];
      for (var i = 0; i < binary.length; i++) {
        var byte = binary.charCodeAt(i)
          array.push(byte);
      }
      var blob =  new Blob([new Uint8Array(array)], { type: 'image/jpeg' });
      var reader = new FileReader
      reader.onloadend =() => {
        this.background = reader.result
        this.renderer.setStyle(
          this.headerImage.nativeElement,
          'backgroundImage',
          `url(${this.background})`
      );
      }
      reader.readAsDataURL(blob)
    }
  }
}
