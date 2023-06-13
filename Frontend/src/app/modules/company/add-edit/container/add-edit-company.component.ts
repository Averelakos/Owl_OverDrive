import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { BehaviorSubject } from 'rxjs';
import { ResponsiveService, ResponsizeSize } from 'src/app/core/services/responsive.service';
import { CompanyService } from 'src/app/data/services/company.service';
import { CreateCompanyDto } from 'src/app/data/types/company/new-company';

@Component({
  selector: 'app-add-edit-company',
  templateUrl: './add-edit-company.component.html',
  styleUrls: ['./add-edit-company.component.scss']
})
export class AddEditCompanyComponent {
  imageSrc: string | ArrayBuffer | null;
  loading$ = new BehaviorSubject<boolean>(false)
  responsiveSizes = ResponsizeSize
  companyForm!: FormGroup

  constructor(
    public responsiveService: ResponsiveService, 
    private readonly companyService: CompanyService,
    private readonly formBuilder: FormBuilder
    ) {
      this.companyForm = this.companyService.initForm()
    }

  readURL(event: any): void {
    if (event?.target.files && event.target.files[0]) {
        const file = event.target.files[0];

        const reader = new FileReader();
        reader.onload = e => this.imageSrc = reader.result;

        reader.readAsDataURL(file);
    }
  }

  createCompany() {
    const newCompany: CreateCompanyDto = this.createNewCompanyModel()
    console.log(newCompany)
    this.companyService.createNewCompany(newCompany).subscribe(x => console.log(x))
  }

  createNewCompanyModel(): CreateCompanyDto {
    let model: CreateCompanyDto = {
      name: this.companyForm.get('generalDetails')?.get('name')?.value,
      description: this.companyForm.get('generalDetails')?.get('description')?.value,
      parentCompany: this.companyForm.get('parentCompany')?.value,
      foundedIn: this.companyForm.get('foundedDetails')?.get('foundedIn')?.value,
      country: this.companyForm.get('foundedDetails')?.get('country')?.value,
      status: this.companyForm.get('statusDetails')?.get('status')?.value,
      changedDate: this.companyForm.get('statusDetails')?.get('changedDate')?.value,
      officialWebsite: this.companyForm.get('linksDetails')?.get('officialWebsite')?.value,
      twitter: this.companyForm.get('linksDetails')?.get('twitter')?.value,
    }
    return model
  }
}
