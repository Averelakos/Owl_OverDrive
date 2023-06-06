import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-standar-textarea',
  standalone: true,
  imports:[CommonModule],
  templateUrl: './standar-textarea.component.html',
  styleUrls: ['./standar-textarea.component.scss']
})
export class StandarTextareaComponent {
  @Input() label:string = ''
}
