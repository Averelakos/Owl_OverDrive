import { CommonModule } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { AbstractControl, FormArray, FormGroup, FormGroupDirective, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FormsHelper } from '../helpers/forms-helper';

@Component({
  selector: 'app-standar-input',
  standalone: true,
  imports:[CommonModule, ReactiveFormsModule, FormsModule],
  templateUrl: './standar-input.component.html',
  styleUrls: ['./standar-input.component.scss']
})
export class StandarInputComponent implements OnInit{
  
  @Input() label:string = ''
  @Input() controlName = ''
  @Input() subGroup: string = ''
  formGroup!: FormGroup
  formHelper = new FormsHelper

  constructor(public parentForm: FormGroupDirective){}

  ngOnInit(): void {
    this.formGroup = this.parentForm.control.get(this.subGroup) as FormGroup
  }
}
