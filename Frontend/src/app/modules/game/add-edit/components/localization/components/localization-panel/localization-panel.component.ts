import { Component, EventEmitter, Input, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StandarInputComponent } from 'src/app/common/standar-input/standar-input.component';
import { StandarSelectSearchComponent } from 'src/app/common/standar-select-search/standar-select-search.component';
import { FormGroupDirective } from '@angular/forms';
import { ResponsiveService, ResponsizeSize } from 'src/app/core/services/responsive.service';

@Component({
  selector: 'app-localization-panel',
  standalone: true,
  imports: [CommonModule, StandarInputComponent, StandarSelectSearchComponent],
  templateUrl: './localization-panel.component.html',
  styleUrls: ['./localization-panel.component.scss']
})
export class LocalizationPanelComponent {
  @Input() index!: number
  @Output() remove = new EventEmitter<number>
  deviceType = ResponsizeSize

  constructor(public parentForm: FormGroupDirective, public responsiveService: ResponsiveService){}

  removeLocalization() {
    this.remove.emit(this.index)
  }
}
