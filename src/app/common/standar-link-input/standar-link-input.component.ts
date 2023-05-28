import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-standar-link-input',
  standalone: true,
  imports:[CommonModule],
  templateUrl: './standar-link-input.component.html',
  styleUrls: ['./standar-link-input.component.scss']
})
export class StandarLinkInputComponent {
  @Input() label:string = ''
  @Input() iconStyle:string = ''
  @Input() icon: string = ''
}
