import { Component, ElementRef, Input, OnInit, Renderer2, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ResponsiveService, ResponsizeSize } from 'src/app/core/services/responsive.service';
import { GameSimpleDto } from 'src/app/data/types/game/GameSimpleDto';

@Component({
  selector: 'app-game-card',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './game-card.component.html',
  styleUrls: ['./game-card.component.scss']
})
export class GameCardComponent implements OnInit{
  deviceTypes = ResponsizeSize
  cover: any
  @ViewChild('container') containerElement:ElementRef;
  @Input() item:GameSimpleDto
  constructor(public responsiveService: ResponsiveService, private renderer: Renderer2){}
  
  ngOnInit(): void {
    this.convertBinaryToImage()
  }

  convertBinaryToImage() {
    if (this.item?.imageData != null) {
      var binary = atob(this.item.imageData)
      var array: any = [];
      for (var i = 0; i < binary.length; i++) {
        var byte = binary.charCodeAt(i)
          array.push(byte);
      }
      var blob =  new Blob([new Uint8Array(array)], { type: 'image/jpeg' });
      var reader = new FileReader
      reader.onloadend =() => {
        this.cover = reader.result
        this.renderer.setStyle(
          this.containerElement.nativeElement,
          'backgroundImage',
          `url(${this.cover})`
      );
      }
      reader.readAsDataURL(blob)
    }

    
}
  }

