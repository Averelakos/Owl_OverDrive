import { Component, Input, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GameDetailsGeneral } from 'src/app/data/types/game/game-details-dto';

@Component({
  selector: 'app-details',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.scss']
})
export class DetailsComponent implements OnInit {
  
  @Input() gameDetails: GameDetailsGeneral
  @Input() firstReleaseDate: Date | null
  showCompanies:boolean = false
  showGenreThemes: boolean = false
  showModesPerspectives: boolean = false

  ngOnInit(): void {
    if (this.gameDetails.companies.developer != null && this.gameDetails.companies.developer.length > 0 
      && this.gameDetails.companies.publisher != null && this.gameDetails.companies.publisher.length > 0 
      && this.gameDetails.companies.porting != null && this.gameDetails.companies.porting.length > 0
      && this.gameDetails.companies.supporting != null && this.gameDetails.companies.supporting.length > 0) {
        this.showCompanies = true
    }

    if(this.gameDetails.genres != null && this.gameDetails.genres.length > 0 
      && this.gameDetails.themes != null && this.gameDetails.themes.length > 0) {
        this.showGenreThemes = true
    }

    if(this.gameDetails.gameModes != null && this.gameDetails.gameModes.length > 0 
      && this.gameDetails.playerPerspectives != null && this.gameDetails.playerPerspectives.length > 0) {
        this.showModesPerspectives = true
    }
  }
}
