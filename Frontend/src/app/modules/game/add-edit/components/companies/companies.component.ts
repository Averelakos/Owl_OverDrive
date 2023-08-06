import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormArray, FormBuilder, FormGroup, FormGroupDirective, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CompanyComponent } from './components/company/company.component';

@Component({
  selector: 'app-companies',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule, CompanyComponent],
  templateUrl: './companies.component.html',
  styleUrls: ['./companies.component.scss']
})
export class CompaniesComponent {

  constructor(private readonly formBuilder: FormBuilder, public parentForm: FormGroupDirective){}

  companies() : FormArray {
    return this.parentForm.control.get('companies') as FormArray
  }

  newCompanie(): FormGroup {
    return this.formBuilder.group({
      company:[null],
      platform:[null],
      publisher:[false],
      mainDeveloper:[false],
      supportingDeveloper:[false],
      portingDeveloper:[false]
    })
  }

  addNewIndex() {
    this.companies().push(this.newCompanie())
  }

  removeIndex(index: number) {
    this.companies().removeAt(index)
  }
}
