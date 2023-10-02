import { Component, Input, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GameDetailsSupportedLanguageDto } from 'src/app/data/types/game/game-details-dto';
import { LookupsService } from 'src/app/data/services/Lookups.service';

@Component({
  selector: 'app-supported-languages',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './supported-languages.component.html',
  styleUrls: ['./supported-languages.component.scss']
})
export class SupportedLanguagesComponent implements OnInit {
  @Input() supportedlanguages: GameDetailsSupportedLanguageDto
  audio: Array<string> = []
  subtitles: Array<string> = []
  interface: Array<string> = []

  constructor(private readonly lookupsService: LookupsService){}

  ngOnInit(): void {
    if(this.supportedlanguages.audio != null && this.supportedlanguages.audio.length > 0) {
      this.supportedlanguages.audio.forEach((entry) => {
        var temp = this.lookupsService.languages.find((x) => x.id === entry)
        if(temp != null) {
          this.audio.push(temp.name)
        }
      })
    }

    if(this.supportedlanguages.subtitles != null && this.supportedlanguages.subtitles.length > 0) {
      this.supportedlanguages.subtitles.forEach((entry) => {
        var temp = this.lookupsService.languages.find((x) => x.id === entry)
        if(temp != null) {
          this.subtitles.push(temp.name)
        }
      })
    }

    if(this.supportedlanguages.interface != null && this.supportedlanguages.interface.length > 0) {
      this.supportedlanguages.interface.forEach((entry) => {
        var temp = this.lookupsService.languages.find((x) => x.id === entry)
        if(temp != null) {
          this.interface.push(temp.name)
        }
      })
    }
  }
}
