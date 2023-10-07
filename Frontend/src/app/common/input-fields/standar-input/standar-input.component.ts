import { CommonModule } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { FormGroup, FormGroupDirective, FormsModule, ReactiveFormsModule } from '@angular/forms';


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


  constructor(public parentForm: FormGroupDirective){}

  ngOnInit(): void {
    this.formGroup = this.parentForm.control.get(this.subGroup) as FormGroup
  }
}
