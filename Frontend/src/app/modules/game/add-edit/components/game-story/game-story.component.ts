import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StandarTextareaComponent } from 'src/app/common/standar-textarea/standar-textarea.component';

@Component({
  selector: 'app-game-story',
  standalone: true,
  imports: [CommonModule, StandarTextareaComponent],
  templateUrl: './game-story.component.html',
  styleUrls: ['./game-story.component.scss']
})
export class GameStoryComponent {

}
