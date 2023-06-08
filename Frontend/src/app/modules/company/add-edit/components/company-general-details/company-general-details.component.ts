import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormGroupDirective } from '@angular/forms';
import { StandarInputComponent } from 'src/app/common/standar-input/standar-input.component';
import { StandarTextareaComponent } from 'src/app/common/standar-textarea/standar-textarea.component';
import { ResponsiveService, ResponsizeSize } from 'src/app/core/services/responsive.service';

@Component({
  selector: 'app-company-general-details',
  templateUrl: './company-general-details.component.html',
  styleUrls: ['./company-general-details.component.scss'],
  standalone:true,
  imports:[CommonModule, StandarInputComponent, StandarTextareaComponent]
})
export class CompanyGeneralDetailsComponent implements OnInit {
  responsiveSizes = ResponsizeSize
  
  constructor(public responsiveService: ResponsiveService, public parentForm: FormGroupDirective) {}
  
  ngOnInit(): void {
    let generalDetails: FormGroup = this.parentForm.form.controls['generalDetails'] as FormGroup
  }
}
