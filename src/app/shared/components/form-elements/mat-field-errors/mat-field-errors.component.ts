import { Component, Input } from '@angular/core';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-mat-field-errors',
  templateUrl: './mat-field-errors.component.html',
  styleUrls: ['./mat-field-errors.component.scss']
})
export class MatFieldErrorsComponent {

  @Input() formField: FormControl  
}
