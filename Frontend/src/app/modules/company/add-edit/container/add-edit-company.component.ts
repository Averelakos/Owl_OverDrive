import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BehaviorSubject } from 'rxjs';
import { ResponsiveService, ResponsizeSize } from 'src/app/core/services/responsive.service';
import { CompanyService } from 'src/app/data/services/company.service';
import { CreateCompanyDto } from 'src/app/data/types/company/new-company';

@Component({
  selector: 'app-add-edit-company',
  templateUrl: './add-edit-company.component.html',
  styleUrls: ['./add-edit-company.component.scss']
})
export class AddEditCompanyComponent implements OnInit {
  imageSrc: string | ArrayBuffer | null;
  loading$ = new BehaviorSubject<boolean>(false)
  responsiveSizes = ResponsizeSize
  companyForm!: FormGroup
  companyId: number | null

  constructor(
    public responsiveService: ResponsiveService, 
    private readonly companyService: CompanyService,
    private readonly formBuilder: FormBuilder,
    private router: Router,
    private readonly route: ActivatedRoute
    ) 
  {
    this.companyForm = this.companyService.initForm()
  }

  ngOnInit(): void {
    this.companyId = this.route.snapshot.params['id']
    if (this.companyId != null) {
      this.getEditFormData(this.companyId)
    }
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
      imageGuid: this.companyForm.get('generalDetails')?.get('image')?.value,
      parentCompany: this.companyForm.get('parentCompany')?.value,
      foundedIn: this.companyForm.get('foundedDetails')?.get('foundedIn')?.value,
      countryId: this.companyForm.get('foundedDetails')?.get('country')?.value,
      statusId: this.companyForm.get('statusDetails')?.get('status')?.value,
      changedDate: this.companyForm.get('statusDetails')?.get('changedDate')?.value,
      officialWebsite: this.companyForm.get('linksDetails')?.get('officialWebsite')?.value,
      twitter: this.companyForm.get('linksDetails')?.get('twitter')?.value,
    }
    return model
  }

  clickToReturnBack() {
    this.router.navigate(['Company']);
  }

  getEditFormData(companyId: number){
    this.companyService
    .getCompanyForEdit(companyId)
    .subscribe((res) => {
      this.companyForm.get('generalDetails')?.get('name')?.patchValue(res.name),
      this.companyForm.get('generalDetails')?.get('description')?.patchValue(res.description),
      this.companyForm.get('parentCompany')?.patchValue(res.parentCompany),
      this.companyForm.get('foundedDetails')?.get('foundedIn')?.patchValue(res.foundedIn),
      this.companyForm.get('foundedDetails')?.get('country')?.patchValue(res.countryId),
      this.companyForm.get('statusDetails')?.get('status')?.patchValue(res.statusId),
      this.companyForm.get('statusDetails')?.get('changedDate')?.patchValue(res.changedDate),
      this.companyForm.get('linksDetails')?.get('officialWebsite')?.patchValue(res.officialWebsite),
      this.companyForm.get('linksDetails')?.get('twitter')?.patchValue(res.twitter)
    })
  }

  clickToUpdateCompany() {
    
  }
}
