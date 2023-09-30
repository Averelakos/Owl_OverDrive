import { Component, Input, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GameDetailsSpellingsDto } from 'src/app/data/types/game/game-details-dto';

@Component({
  selector: 'app-spellings',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './spellings.component.html',
  styleUrls: ['./spellings.component.scss']
})
export class SpellingsComponent implements OnInit {
  @Input() spellings: GameDetailsSpellingsDto

  ngOnInit(): void {
    // throw new Error('Method not implemented.');
  }
}
