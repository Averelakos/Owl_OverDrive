import { AfterViewInit, Component, OnInit } from '@angular/core';
import { SelectSearchInputValue } from 'src/app/common/standar-select-search/standar-select-search.component';
import { ResponsiveService, ResponsizeSize } from 'src/app/core/services/responsive.service';
import { LookupsService } from 'src/app/data/services/Lookups.service';

@Component({
  selector: 'app-status',
  templateUrl: './status.component.html',
  styleUrls: ['./status.component.scss']
})
export class StatusComponent  {
  responsiveSizes = ResponsizeSize
  listOfStatuses: Array<SelectSearchInputValue> = []
  constructor(public responsiveService: ResponsiveService, private readonly lookupService: LookupsService) {
   this.convertForSearchSelect()
  }
  

  convertForSearchSelect() {
    this.lookupService.companyStatus.forEach(item => {
      let newItem: SelectSearchInputValue = {
        id: item.id,
        value: item.name
      } 
      this.listOfStatuses.push(newItem)
    })
  }
}
