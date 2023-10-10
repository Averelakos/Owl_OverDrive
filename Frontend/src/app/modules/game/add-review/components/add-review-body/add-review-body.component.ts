import { Component, Input, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SpinnerLoaderComponent } from 'src/app/common/loaders/spinner-loader/spinner-loader';
import { StandarTextareaComponent } from 'src/app/common/standar-textarea/standar-textarea.component';
import { GameService } from 'src/app/data/services/game.service';
import { FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { RatingScaleBarComponent } from 'src/app/common/rating-bars/rating-scale-bar/rating-scale-bar.component';
import { CircularScoreComponent } from 'src/app/common/score-progress/circular-score/circular-score.component';
import { AddUserReviewDto } from 'src/app/data/types/game/add-user-review';
import { AuthService } from 'src/app/core/auth/auth.service';
import { BehaviorSubject, finalize, first } from 'rxjs';
import { ServiceResult } from 'src/app/data/types/service-results/service-result';
import { BannerResultActionService } from 'src/app/core/services/result-banner-action.service';
import { ToastrService } from 'src/app/lib/toastr/toastr.service';
import { ResponsiveService, ResponsizeSize } from 'src/app/core/services/responsive.service';
import { ServiceResultBase } from 'src/app/data/types/service-results/service-result-base';

@Component({
  selector: 'app-add-review-body',
  standalone: true,
  imports: [CommonModule, SpinnerLoaderComponent, StandarTextareaComponent, FormsModule, ReactiveFormsModule, RatingScaleBarComponent, CircularScoreComponent],
  templateUrl: './add-review-body.component.html',
  styleUrls: ['./add-review-body.component.scss']
})
export class AddReviewBodyComponent implements OnInit {
  name
  reviewForm:FormGroup
  score: number
  loading$ = new BehaviorSubject<boolean>(false)
  deviceType = ResponsizeSize
  constructor(
    private readonly gameService: GameService, 
    private readonly router: Router, 
    private readonly authService: AuthService,
    private toastr: ToastrService,
    private resultBannerActionService: BannerResultActionService,
    public responsiveService: ResponsiveService, 
  ){
    this.reviewForm = gameService.initReviewForm()
  }
  ngOnInit(): void {
    this.name = this.gameService.returnGameReviewDetails()
    if(this.name != null) {
      this.reviewForm.get('id')?.patchValue(this.name.id)
    }
  }

  clickToCancel(){
    this.router.navigate(['Game/view/' + this.name.name, {id:this.name.id} ])
  }

  clickAddScore(score){
    this.score = score
    this.reviewForm.get('score')?.patchValue(score)
  }

  clickToAddReview(){
    this.loading$.next(true)
    const model : AddUserReviewDto = {
      score: this.reviewForm.get('score')?.value,
      review: this.reviewForm.get('review')?.value,
      gameId: this.reviewForm.get('id')?.value,
      userId: this.authService.getUserId()!
    }
    this.gameService
    .addUserReview(model)
    .pipe(first(),finalize(()=> this.loading$.next(false)))
    .subscribe({
      next:(response: ServiceResult<AddUserReviewDto>) => {
        if (response.success) {
          if (this.responsiveService.responsiveSize.value === this.deviceType.Desktop) {
            this.toastr.success(`Review was added succefully.`, 'Review Add Success')
          } 
          else {
            this.resultBannerActionService.success('Review Add Success', `Review was added succefully.`)
          }
          
        } else {
          if (this.responsiveService.responsiveSize.value === this.deviceType.Desktop) {
            this.toastr.error(`Review was failed to be added. Error: ${response.error}.`, 'Review Add failed')
          } else {
            this.resultBannerActionService.error('Review Add failed', `Review was failed to be added. Error: ${response.error}.`)
          }
        }
        this.router.navigate(['Game/view/' + this.name.name, {id:this.name.id} ])
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
