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

const routes: Routes = [
    {path:'', component:AddEditGameComponent},
]

@NgModule({
    imports:[
        CommonModule,
        RouterModule.forChild(routes),
        FormsModule,
        ReactiveFormsModule,
        GeneralInfoComponent,
        LocalizationComponent,
        GameStoryComponent

    ],
    providers:[GameService],
    declarations:[
    AddEditGameComponent,
    GameInfoTabAccordioComponent,
  ],
    exports:[
        RouterModule,
    ]
})
export class GamesModule{}