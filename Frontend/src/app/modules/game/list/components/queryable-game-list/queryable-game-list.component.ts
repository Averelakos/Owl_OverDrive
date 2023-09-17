import { AfterContentChecked, ChangeDetectorRef, Component, OnDestroy } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GameService } from 'src/app/data/services/game.service';
import { GameSimpleDto } from 'src/app/data/types/game/GameSimpleDto';
import { GameCardComponent } from './components/game-card/game-card.component';
import { GamePaginationComponent } from './components/game-pagination/game-pagination.component';
import { LogoLoader } from 'src/app/common/loaders/logo-loader/logo-loader';
import { BehaviorSubject, Subscription, finalize, first } from 'rxjs';
import { DataLoaderOptions } from 'src/app/data/types/data-loader/data-loader-options';
import { ToastrService } from 'src/app/lib/toastr/toastr.service';
import { BannerResultActionService } from 'src/app/core/services/result-banner-action.service';
import { ServiceSearchResultData } from 'src/app/data/types/service-results/service-searc-result-data';
import { ResponsiveService, ResponsizeSize } from 'src/app/core/services/responsive.service';
import { ServiceResultBase } from 'src/app/data/types/service-results/service-result-base';
import { Router } from '@angular/router';

@Component({
  selector: 'app-queryable-game-list',
  standalone: true,
  imports: [CommonModule, GameCardComponent, GamePaginationComponent, LogoLoader],
  templateUrl: './queryable-game-list.component.html',
  styleUrls: ['./queryable-game-list.component.scss']
})
export class QueryableGameListComponent implements AfterContentChecked, OnDestroy {
  deviceType = ResponsizeSize
  gameList: Array<GameSimpleDto>
  loading$ = new BehaviorSubject<boolean>(false)
  options: DataLoaderOptions
  pageSize: number = 10
  totalPages: number
  currentPage: number = 1
  searchInputSubscription: Subscription
  constructor(
    private gameService: GameService,
    private toastr: ToastrService,
    private resultBannerActionService: BannerResultActionService,
    public responsiveService: ResponsiveService,
    private changeDetector: ChangeDetectorRef,
    private router: Router
    )
  {
   this.options = {
    take: this.pageSize,
    skip: 0,
    searchString:null
   }
   this.fetchGame()

   this.searchInputSubscription =  this.gameService.searchString.subscribe((x) => {
    if(x) {
      this.options =  {
        take: this.pageSize,
        skip: 0,
        searchString: x
       }
       this.fetchGame()
    } else {
      this.options =  {
        take: this.pageSize,
        skip: 0,
        searchString: null
       }
       this.fetchGame()
    }
   })
  }

  ngAfterContentChecked(): void {
    this.changeDetector.detectChanges();
  }

  ngOnDestroy() {
    this.searchInputSubscription.unsubscribe()
}

  changePage(event: any) {
    this.options.skip = this.pageSize * (event - 1)
    this.currentPage = event
    this.fetchGame()
  }

  fetchGame() {
    this.loading$.next(true)
    this.gameService
    .listGame(this.options)
    .pipe(first(),finalize(()=> this.loading$.next(false)))
    .subscribe({
      next:(response: ServiceSearchResultData<Array<GameSimpleDto>>) => {
        if (response.success) {
          if(response.totalCount > 0) {
            this.gameList = response.result!
            this.totalPages = response.totalPages
          }
        } else {
          if (this.responsiveService.responsiveSize.value === this.deviceType.Desktop) {
            this.toastr.error(`$ There was a fail in the game search. Error: ${response.error}.`, 'Game Search List')
          } else {
            this.resultBannerActionService.error('Game Search List', `$ There was a fail in the game search. Error: ${response.error}.`)
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

  openDetails(game: GameSimpleDto) {
    this.router.navigate(['Game/view/' + game.name, {id:game.id} ])
  }
}
