import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TabComponent, TabsComponent } from 'src/app/common/tabs/tabs';
import { GameDetailsPlatformReleasedDatesDto } from 'src/app/data/types/game/game-details-dto';
import { LookupsService } from 'src/app/data/services/Lookups.service';
import { EGameStatus } from 'src/app/core/enums/enum-games-status';

@Component({
  selector: 'app-platforms-released-dates',
  standalone: true,
  imports: [CommonModule,TabComponent, TabsComponent],
  templateUrl: './platforms-released-dates.component.html',
  styleUrls: ['./platforms-released-dates.component.scss']
})
export class PlatformsReleasedDatesComponent {
  @Input() platformsReleaseDates:Array<GameDetailsPlatformReleasedDatesDto> = []
    
  constructor(private readonly lookupsService: LookupsService){}
    
  getRegion(regionId: number): string{
    let region = this.lookupsService.regions.find((x) => x.id == regionId)?.name
    if(region != null) {
      return region
    } else {
      return 'N/A'
    }
  }

  getGameStatus(statusId: number): string{
    debugger
    let status = EGameStatus[statusId]
    if(status != null) {
      return status
    } else {
      return 'N/A'
    }
  }
}
