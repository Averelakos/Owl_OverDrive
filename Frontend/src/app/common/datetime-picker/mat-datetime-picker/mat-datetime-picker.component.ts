import { CommonModule } from '@angular/common';
import { compileNgModule } from '@angular/compiler';
import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormGroupDirective, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatNativeDateModule } from '@angular/material/core';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
const today = new Date();
const month = today.getMonth();
const year = today.getFullYear();
@Component({
  selector: 'app-mat-datetime-picker',
  templateUrl: './mat-datetime-picker.component.html',
  styleUrls: ['./mat-datetime-picker.component.scss'],
  standalone: true,
  imports: [
    CommonModule,
    MatFormFieldModule,
    MatDatepickerModule,
    MatNativeDateModule,
    FormsModule,
    ReactiveFormsModule]
})
export class MatDatetimePickerComponent  implements OnInit {
  
  @Input() label:string = ''
  @Input() controlName = ''
  @Input() subGroup: string = ''
  formGroup!: FormGroup
  isFocused:boolean = false;

  constructor(public parentForm: FormGroupDirective){}

  ngOnInit(): void {
    this.formGroup = this.parentForm.control.get(this.subGroup) as FormGroup
  }
  
  clickToFocus(){
    this.isFocused = true
  }

  clickOutside(){
    this.isFocused = false
  }
}
