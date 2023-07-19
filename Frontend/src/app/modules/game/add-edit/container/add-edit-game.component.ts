import { Component } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { GameService } from 'src/app/data/services/game.service';

@Component({
  selector: 'app-add-edit-game',
  templateUrl: './add-edit-game.component.html',
  styleUrls: ['./add-edit-game.component.scss']
})
export class AddEditGameComponent {
  gameForm!: FormGroup

  constructor(private gameService: GameService){
    this.gameForm = gameService.initForm()
  }

  createGame() {
    console.log(this.gameForm)
  }
}
