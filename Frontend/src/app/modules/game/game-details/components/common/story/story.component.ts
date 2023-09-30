import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-story',
  standalone: true,
  imports: [CommonModule],
  template: `
    <div class="story-container">
      <p>{{story}}</p>
    </div>
`,
  styles: [
    `
    :host{
      display: contents;
    }

    .story-container{
        display: flex;
        flex-direction: column;
    }
    `
  ]
})
export class StoryComponent {
  @Input() story: string
}
