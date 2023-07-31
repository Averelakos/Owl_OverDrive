import { Component, EventEmitter, Input, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ResponsiveService, ResponsizeSize } from 'src/app/core/services/responsive.service';
import { FormGroupDirective } from '@angular/forms';
import { StandarInputComponent } from 'src/app/common/standar-input/standar-input.component';
import { StandarSelectSearchComponent } from 'src/app/common/standar-select-search/standar-select-search.component';
import { ReleaseComponent } from '../release/release.component';

@Component({
  selector: 'app-platform-release',
  standalone: true,
  imports: [CommonModule, StandarInputComponent, StandarSelectSearchComponent, ReleaseComponent],
  templateUrl: './platform-release.component.html',
  styleUrls: ['./platform-release.component.scss']
})
export class PlatformReleaseComponent {
  @Input() index!: number
  @Output() remove = new EventEmitter<number>
  deviceType = ResponsizeSize

  constructor(public parentForm: FormGroupDirective, public responsiveService: ResponsiveService){}

  removeLocalization() {
    this.remove.emit(this.index)
  }
}
