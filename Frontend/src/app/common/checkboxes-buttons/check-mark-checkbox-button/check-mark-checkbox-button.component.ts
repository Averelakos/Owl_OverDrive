import { Component, EventEmitter, Input, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';


@Component({
  selector: 'app-check-mark-checkbox-button',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './check-mark-checkbox-button.component.html',
  styleUrls: ['./check-mark-checkbox-button.component.scss']
})
export class CheckMarkCheckBoxButtonComponent {
  @Input() label!: string
  @Input() isChecked: boolean = false
  @Output() clickEvent = new EventEmitter<boolean>

  onClick(e: Event) {
    this.isChecked = !this.isChecked
    this.clickEvent.emit(this.isChecked)
  }
}
