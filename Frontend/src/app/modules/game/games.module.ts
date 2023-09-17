import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { CommonModule } from "@angular/common";
import { CompanyService } from "src/app/data/services/company.service";
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

const routes: Routes = [
    {path:'', component: ListGamesComponent},
    {path:'add', component:AddEditGameComponent},
    {path:'view/:game', component: GameDetailsComponent},
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
        GameDetailsMobileComponent

    ],
    providers:[GameService],
    declarations:[
    AddEditGameComponent,
    GameInfoTabAccordioComponent,
    ListGamesComponent,
    GameDetailsComponent
  ],
    exports:[
        RouterModule,
    ]
})
export class GamesModule{}