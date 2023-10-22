import { Component, EventEmitter, Input, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatDatetimePickerComponent } from 'src/app/common/datetime-picker/mat-datetime-picker/mat-datetime-picker.component';
import { DropDownOption, StandarDropdownMenuComponent } from 'src/app/common/dropdown-input/standar-dropdown-menu/standar-dropdown-menu.component';
import { ResponsiveService, ResponsizeSize } from 'src/app/core/services/responsive.service';

@Component({
  selector: 'app-release',
  standalone: true,
  imports: [CommonModule, MatDatetimePickerComponent, StandarDropdownMenuComponent],
  templateUrl: './release.component.html',
  styleUrls: ['./release.component.scss']
})
export class ReleaseComponent {
  @Input() index!: number
  @Input() listOfRegions: Array<DropDownOption> = []
  @Input() listOfStatuses: Array<DropDownOption> = []
  @Output() remove = new EventEmitter<number>
  deviceType = ResponsizeSize

  constructor(public responsiveService: ResponsiveService, ){}

  removeRelease() {
    this.remove.emit(this.index)
    console.log()
  }
}
