import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { FormGroup, FormGroupDirective, FormsModule, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-standar-textarea',
  standalone: true,
  imports:[CommonModule, ReactiveFormsModule, FormsModule],
  templateUrl: './standar-textarea.component.html',
  styleUrls: ['./standar-textarea.component.scss']
})
export class StandarTextareaComponent {
  @Input() label:string = ''
  @Input() controlName = ''
  @Input() subGroup: string = ''
  formGroup!: FormGroup

  constructor(public parentForm: FormGroupDirective){}

  ngOnInit(): void {
    if (this.subGroup !== '') {
      this.formGroup = this.parentForm.control.get(this.subGroup) as FormGroup
    } 
    else {
      this.formGroup = this.parentForm.form
    }
  }
}
