import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GameDetailsDto } from 'src/app/data/types/game/game-details-dto';
import { TabComponent, TabsComponent } from 'src/app/common/tabs/tabs';
import { Router } from '@angular/router';
import { DetailsComponent } from '../../../../../common/details/details.component';
import { StoryComponent } from '../../../../../common/story/story.component';
import { WebsitesComponent } from '../../../../../common/websites/websites.component';
import { SpellingsComponent } from '../../../../../common/spellinigs/spellings.component';
import { MultiplayerModesComponent } from '../../../../../common/multiplayer-modes/multiplayer-modes.component';
import { SupportedLanguagesComponent } from '../../../../../common/supported-languages/supported-languages.component';
import { PlatformsReleasedDatesComponent } from '../../../../../common/platforms-release-dates/platforms-released-dates.component';
import { AuthService } from 'src/app/core/auth/auth.service';
import { EPermission } from 'src/app/core/enums/enum-permissions';


@Component({
  selector: 'app-info',
  standalone: true,
  imports: [
    CommonModule, 
    TabsComponent, 
    TabComponent, 
    DetailsComponent, 
    StoryComponent, 
    WebsitesComponent, 
    SpellingsComponent, 
    MultiplayerModesComponent, 
    SupportedLanguagesComponent,
    PlatformsReleasedDatesComponent
  ],
  templateUrl: './info.component.html',
  styleUrls: ['./info.component.scss']
})
export class InfoComponent {
  @Input()gameModel: GameDetailsDto
  selectedTab: string
  canUpdateGame!:boolean

  constructor(private readonly router: Router, private readonly authService: AuthService){
    this.canUpdateGame = this.authService.hasPermission(EPermission.Update_Game)
  }

  clickToEdit() {
    this.router.navigate(['Game/edit/'+this.gameModel?.name,{id:this.gameModel?.id}]);   
   }
}
