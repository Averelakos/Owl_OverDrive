import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { CommonModule } from "@angular/common";
import { AddEditGameComponent } from './add-edit/container/add-edit-game.component';
import { GameInfoTabAccordioComponent } from './add-edit/components/game-info-tabs-accordio/game-info-tab-accordio.component';
import { GeneralInfoComponent } from './add-edit/components/general-info/general-info.component';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { GameService } from "src/app/data/services/game.service";
import { LocalizationComponent } from "./add-edit/components/localization/localization.component";
import { GameStoryComponent } from "./add-edit/components/game-story/game-story.component";
import { GameWebsitesComponent } from "./add-edit/components/game-websites/game-websites.component";
import { GameCategorizationComponent } from "./add-edit/components/game-categorization/game-categorization.component";
import { GameReleaseDatesComponent } from "./add-edit/components/game-release-dates/game-release-dates.component";
import { CompaniesComponent } from "./add-edit/components/companies/companies.component";
import { LanguagesComponent } from "./add-edit/components/languages/languages.component";
import { AlternativeTitlesComponent } from "./add-edit/components/alternative-titles/alternative-titles.component";
import { ListGamesComponent } from "./list/container/list-games.component";
import { SearchFilterHeaderComponent } from "./list/components/search-filter-header/search-filter-header.component";
import { QueryableGameListComponent } from "./list/components/queryable-game-list/queryable-game-list.component";
import { GameDetailsComponent } from './game-details/container/game-details.component';
import { GameDetailsDesktopComponent } from "./game-details/components/game-details-desktop/game-details-desktop.component";
import { GameDetailsMobileComponent } from "./game-details/components/game-details-mobile/game-details-mobile.component";
import { SpinnerLoaderComponent } from "src/app/common/loaders/spinner-loader/spinner-loader";
import { EPermission } from "src/app/core/enums/enum-permissions";
import { ReviewsComponent } from "./reviews/container/reviews.component";
import { ReviewHeaderComponent } from "./reviews/components/review-header/review-header.component";
import { ReviewBodyComponent } from "./reviews/components/review-body/review-body.component";
import { AddReviewsComponent } from "./add-review/container/add-reviews.component";

import { AddReviewBodyComponent } from "./add-review/components/add-review-body/add-review-body.component";
import { AddReviewHeaderComponent } from "./add-review/components/add-review-header/add-review-header.component";

const routes: Routes = [
    {
        path:'',
        component: ListGamesComponent,
        data:{permissions:[EPermission.Display_Game]}
    },
    {
        path:'add',
        component:AddEditGameComponent,
        data:{permissions:[EPermission.Create_Game]}
    },
    {
        path:'view/:game',
        component: GameDetailsComponent,
        data:{permissions:[EPermission.Details_Game]}
    },
    {
        path:'edit/:game', 
        component: AddEditGameComponent,
        data:{permissions:[EPermission.Update_Game]}
    },
    {
        path:'reviews/:game', 
        component: ReviewsComponent,
        data:{permissions:[EPermission.Details_Game]}
    },
    {
        path:'add-review/:game', 
        component: AddReviewsComponent,
        data:{permissions:[EPermission.Details_Game]}
    }
]

@NgModule({
    imports:[
        CommonModule,
        RouterModule.forChild(routes),
        FormsModule,
        ReactiveFormsModule,
        GeneralInfoComponent,
        LocalizationComponent,
        GameStoryComponent,
        GameWebsitesComponent,
        GameCategorizationComponent,
        GameReleaseDatesComponent,
        CompaniesComponent,
        LanguagesComponent,
        AlternativeTitlesComponent,
        SearchFilterHeaderComponent,
        QueryableGameListComponent,
        GameDetailsDesktopComponent,
        GameDetailsMobileComponent,
        SpinnerLoaderComponent,
        ReviewHeaderComponent,
        ReviewBodyComponent,
        AddReviewHeaderComponent,
        AddReviewBodyComponent

    ],
    providers:[GameService],
    declarations:[
    AddEditGameComponent,
    GameInfoTabAccordioComponent,
    ListGamesComponent,
    GameDetailsComponent,
    ReviewsComponent,
    AddReviewsComponent
  ],
    exports:[
        RouterModule,
    ]
})
export class GamesModule{}