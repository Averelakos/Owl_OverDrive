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


@Component({
  selector: 'app-info',
  standalone: true,
  imports: [CommonModule, TabsComponent, TabComponent, DetailsComponent, StoryComponent, WebsitesComponent, SpellingsComponent, MultiplayerModesComponent],
  templateUrl: './info.component.html',
  styleUrls: ['./info.component.scss']
})
export class InfoComponent {
  @Input()gameModel: GameDetailsDto
  selectedTab: string

  constructor(private readonly router: Router){}

  clickToEdit() {
    this.router.navigate(['Game/edit/'+this.gameModel?.name,{id:this.gameModel?.id}]);   
   }
}
