import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { BehaviorSubject, finalize, first } from 'rxjs';
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
  loading$ = new BehaviorSubject<boolean>(false)
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
    this.loading$.next(true)
    let model = this.gameService.createModel(this.gameForm)
    this.gameService.createNewGame(model)
    .pipe(first(),finalize(()=> this.loading$.next(false)))
    .subscribe()
  }

  getDataForEdit() {
    this.loading$.next(true)
    this.gameService.getGameByIdForEdit(this.gameId)
    .pipe(first(),finalize(()=> this.loading$.next(false)))
    .subscribe((res) => {
      this.gameService.populateForm(this.gameForm, res)
    })
  }

  updateGame(){
    this.loading$.next(true)
    let model = this.gameService.updateModel(this.gameForm, this.gameId!)
    this.gameService.updateGame(model)
    .pipe(first(),finalize(()=> this.loading$.next(false)))
    .subscribe()
  }
}
