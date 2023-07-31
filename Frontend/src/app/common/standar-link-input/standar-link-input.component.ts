import { CommonModule } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { FormGroup, FormGroupDirective, FormsModule, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-standar-link-input',
  standalone: true,
  imports:[CommonModule, ReactiveFormsModule, FormsModule],
  templateUrl: './standar-link-input.component.html',
  styleUrls: ['./standar-link-input.component.scss']
})
export class StandarLinkInputComponent implements OnInit {
  
  @Input() label:string = ''
  @Input() controlName = ''
  @Input() subGroup: string = ''
  @Input() iconStyle:string = ''
  @Input() icon: string = ''
  @Input() imagePath: string;
  formGroup!: FormGroup


  constructor(public parentForm: FormGroupDirective){}

  ngOnInit(): void {
    this.formGroup = this.parentForm.control.get(this.subGroup) as FormGroup
  }

  
}
