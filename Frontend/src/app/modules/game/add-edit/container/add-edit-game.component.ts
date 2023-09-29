import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BehaviorSubject, finalize, first } from 'rxjs';
import { ResponsiveService, ResponsizeSize } from 'src/app/core/services/responsive.service';
import { BannerResultActionService } from 'src/app/core/services/result-banner-action.service';
import { GameService } from 'src/app/data/services/game.service';
import { CreateGameResponseDto } from 'src/app/data/types/game/responses/create-game-response-dto';
import { UpdateGameDto } from 'src/app/data/types/game/update-game';
import { ServiceResult } from 'src/app/data/types/service-results/service-result';
import { ServiceResultBase } from 'src/app/data/types/service-results/service-result-base';
import { ToastrService } from 'src/app/lib/toastr/toastr.service';

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
  deviceType = ResponsizeSize

  constructor(
    private gameService: GameService, 
    private readonly route: ActivatedRoute,
    private toastr: ToastrService,
    private resultBannerActionService: BannerResultActionService,
    public responsiveService: ResponsiveService,
    private router: Router
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
    .subscribe({
      next:(response: ServiceResult<CreateGameResponseDto>) => {
        if (response.success) {
          if (this.responsiveService.responsiveSize.value === this.deviceType.Desktop) {
            this.toastr.success(`${response.result?.name} game was created succefully.`, 'Create Success')
          } 
          else {
            this.resultBannerActionService.success('Create Success', `${response.result?.name} game was created succefully.`)
          }
          this.router.navigate(['Game/view/' + response.result?.name, {id:response.result?.id} ])
        } else {
          if (this.responsiveService.responsiveSize.value === this.deviceType.Desktop) {
            this.toastr.error(`${model.name} game entry was not created. Error: ${response.error}.`, 'Create failed')
          } else {
            this.resultBannerActionService.error('Create failed', `${model.name} ame entry was not created. Error: ${response.error}.`)
          }
        }
      },
      error: (error: ServiceResultBase) => {
        if (this.responsiveService.responsiveSize.value === this.deviceType.Desktop) {
          this.toastr.error( `${error.error}`, 'Error')
        } else {
          this.resultBannerActionService.error('Error', `${error.error}`)
        }
      }
    })
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
    .subscribe({
      next:(response: ServiceResult<UpdateGameDto>) => {
      if (response.success) {
        if (this.responsiveService.responsiveSize.value === this.deviceType.Desktop) {
          this.toastr.success(`${response.result?.name} was updated succefully.`, 'Update Success')
        } 
        else {
          this.resultBannerActionService.success('Update Success', `${response.result?.name} was updated succefully.`)
        }
      } else {
        if (this.responsiveService.responsiveSize.value === this.deviceType.Desktop) {
          this.toastr.error(`${response.result?.name} failed to update. Error: ${response.error}.`, 'Update failed')
        } else {
          this.resultBannerActionService.error('Update failed', `${response.result?.name} failed to update. Error: ${response.error}.`)
        }
      }
    },
    error: (error: ServiceResultBase) => {
      if (this.responsiveService.responsiveSize.value === this.deviceType.Desktop) {
        this.toastr.error( `${error.error}`, 'Error')
      } else {
        this.resultBannerActionService.error('Error', `${error.error}`)
      }
    }
  })
  }
}
