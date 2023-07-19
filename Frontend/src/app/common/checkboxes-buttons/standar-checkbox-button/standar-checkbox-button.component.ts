import { Component, EventEmitter, Input, Output } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-standar-checkbox-button',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './standar-checkbox-button.component.html',
  styleUrls: ['./standar-checkbox-button.component.scss']
})
export class StandarCheckBoxButtonComponent {
  @Input() label!: string
  @Input() isChecked: boolean = false
  @Output() clickEvent = new EventEmitter<boolean>
  @Input() dissableUncheck: boolean = false

  onClick(e: Event) {
    if (this.isChecked && this.dissableUncheck) {
      e.preventDefault()
      this.clickEvent.emit(this.isChecked)
    } else {
      this.clickEvent.emit(!this.isChecked) 
    }
  }
}
