import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GameService } from 'src/app/data/services/game.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-search',
  standalone: true,
  imports: [CommonModule,ReactiveFormsModule, FormsModule],
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss']
})
export class SearchComponent {
  searchInput:string | null = null
  constructor(
    // private gameService: GameService
    ){}

  search(){
    // this.gameService.searchString.next(this.searchInput)
  }

  onSearchValueChange(){
      // let trimmedInput = this.searchInput?.trim()
      // if (trimmedInput != null && trimmedInput.length > 2) {
      //   this.gameService.searchString.next(this.searchInput)
      // }
      // else if (trimmedInput == null || trimmedInput.length === 0) {
      //   this.gameService.searchString.next(null)
      // }
  }
}
