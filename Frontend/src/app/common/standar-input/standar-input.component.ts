import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-standar-input',
  standalone: true,
  imports:[CommonModule],
  templateUrl: './standar-input.component.html',
  styleUrls: ['./standar-input.component.scss']
})
export class StandarInputComponent {
  @Input() label:string = ''
}
