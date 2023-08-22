import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SelectSearchInputValue, StandarSelectSearchComponent } from 'src/app/common/standar-select-search/standar-select-search.component';
import { FormGroupDirective } from '@angular/forms';
import { ResponsiveService, ResponsizeSize } from 'src/app/core/services/responsive.service';

@Component({
  selector: 'app-genre-theme',
  standalone: true,
  imports: [CommonModule, StandarSelectSearchComponent],
  templateUrl: './genre-theme.component.html',
  styleUrls: ['./genre-theme.component.scss']
})
export class GenreThemeComponent {
  deviceType = ResponsizeSize
  listOfGenre!: Array<SelectSearchInputValue>
  listOfThemes!: Array<SelectSearchInputValue>

  dataGenre = [
    {id:1, name: 'Adventure'},
    {id:2, name: 'Arcade'},
    {id:3, name: 'Card & Board Game'},
    {id:4, name: 'Fighting'},
    {id:5, name: `Hack and slash/ Beat 'em up`},
    {id:6, name: 'Indie'},
    {id:7, name: 'Music'},
    {id:8, name: 'Pinball'},
    {id:9, name: 'Platform'},
    {id:10, name: 'Point-and-click'},
    {id:11, name: 'Puzzle'},
    {id:12, name: 'Quiz/Trivia'},
    {id:13, name: 'Racing'},
    {id:14, name: 'Real Time Strategy(RTS)'},
    {id:15, name: 'Shooter'},
    {id:16, name: 'Role-playening(RPG)'},
    {id:17, name: 'Simulator'},
    {id:18, name: 'Sport'},
    {id:19, name: 'Strategy'},
    {id:20, name: 'Tactical'},
    {id:21, name: 'Turn-based-strategy(TBS)'},
    {id:22, name: 'Visual Novel'},
  ]

  dataTheme = [
    {id:1, name: '4X(explore, expand, exploit and exterminate)'},
    {id:2, name: 'Action'},
    {id:3, name: 'Bussiness'},
    {id:4, name: 'Comedy'},
    {id:5, name: 'Drama'},
    {id:6, name: 'Educational'},
    {id:7, name: 'Erotic'},
    {id:8, name: 'Fantasy'},
    {id:9, name: 'Historical'},
    {id:10, name: 'Horror'},
    {id:11, name: 'Kids'},
    {id:12, name: 'Mystery'},
    {id:13, name: 'Non-fiction'},
    {id:14, name: 'Open world'},
    {id:15, name: 'Party'},
    {id:16, name: 'Romance'},
    {id:17, name: 'Sandbox'},
    {id:18, name: 'Science fiction'},
    {id:19, name: 'Stealth'},
    {id:20, name: 'Survival'},
    {id:21, name: 'Thriller'},
    {id:22, name: 'Warfare'},
  ]

  constructor(public parentForm: FormGroupDirective, public responsiveService: ResponsiveService, ){
    this.listOfGenre = this.convertForSearchSelect(this.dataGenre)
    this.listOfThemes = this.convertForSearchSelect(this.dataTheme)
  }


  convertForSearchSelect(data: any): Array<SelectSearchInputValue> {
    let output: Array<SelectSearchInputValue> = []
    data.forEach((item) => {
      let newItem: SelectSearchInputValue = {
        id: item.id,
        value: item.name
      } 
      output.push(newItem)
    })

    return output;
  }
}
