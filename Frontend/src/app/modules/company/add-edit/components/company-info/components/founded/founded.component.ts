import { Component } from '@angular/core';
import { SelectSearchInputValue } from 'src/app/common/standar-select-search/standar-select-search.component';
import { ResponsiveService, ResponsizeSize } from 'src/app/core/services/responsive.service';
import { LookupsService } from 'src/app/data/services/Lookups.service';

@Component({
  selector: 'app-founded',
  templateUrl: './founded.component.html',
  styleUrls: ['./founded.component.scss']
})
export class FoundedComponent {
  responsiveSizes = ResponsizeSize
  listOfCountries: Array<SelectSearchInputValue> = []
  constructor(public responsiveService: ResponsiveService, private readonly lookupService: LookupsService) {
    this.convertForSearchSelect()
  }

  convertForSearchSelect() {
    const start = Date.now()
    this.lookupService.countryCodes.forEach(item => {
      let newItem: SelectSearchInputValue = {
        id: item.id,
        value: item.name
      } 
      this.listOfCountries.push(newItem)
    })
    
    const end = Date.now()
    console.log(start, end, this.listOfCountries)
  }
}
