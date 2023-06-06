import { Component, Input } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
const today = new Date();
const month = today.getMonth();
const year = today.getFullYear();
@Component({
  selector: 'app-mat-datetime-picker',
  templateUrl: './mat-datetime-picker.component.html',
  styleUrls: ['./mat-datetime-picker.component.scss']
})
export class MatDatetimePickerComponent {
  isFocused:boolean = false;
  @Input()label: string = ''
  campaignOne = new FormGroup({
    start: new FormControl(new Date(year, month, 13)),
    end: new FormControl(new Date(year, month, 16)),
  });
  campaignTwo = new FormGroup({
    start: new FormControl(new Date(year, month, 15)),
    end: new FormControl(new Date(year, month, 19)),
  });

  clickToFocus(){
    this.isFocused = true
  }

  clickOutside(){
    this.isFocused = false
  }
}
