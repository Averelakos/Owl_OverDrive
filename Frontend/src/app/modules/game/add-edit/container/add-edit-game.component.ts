import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { GameService } from 'src/app/data/services/game.service';

@Component({
  selector: 'app-add-edit-game',
  templateUrl: './add-edit-game.component.html',
  styleUrls: ['./add-edit-game.component.scss']
})
export class AddEditGameComponent implements OnInit {
  gameForm!: FormGroup
  gameId: number | null
  isForCreate: boolean = true
  constructor(
    private gameService: GameService, 
    private readonly route: ActivatedRoute
    ){
    this.gameForm = gameService.initForm()
  }

  ngOnInit(): void {
    this.gameId = this.route.snapshot.params['id']
    if (this.gameId != null) {
      this.isForCreate = false
      this.getDataForEdit()
    }
  }

  createGame() {
    let model = this.gameService.createModel(this.gameForm)
    this.gameService.createNewGame(model).subscribe()
  }

  getDataForEdit() {
    this.gameService.getGameByIdForEdit(this.gameId).subscribe((res) => {
      console.log(res)
      this.gameService.populateForm(this.gameForm, res)
    })
  }
}
