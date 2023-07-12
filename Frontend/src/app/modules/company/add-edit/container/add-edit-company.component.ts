import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BehaviorSubject, finalize, first } from 'rxjs';
import { ResponsiveService, ResponsizeSize } from 'src/app/core/services/responsive.service';
import { BannerResultActionService } from 'src/app/core/services/result-banner-action.service';
import { CompanyService } from 'src/app/data/services/company.service';
import { CreateCompanyDto } from 'src/app/data/types/company/new-company';
import { UpdateCompanyDto } from 'src/app/data/types/company/update-company';
import { ServiceResult } from 'src/app/data/types/service-results/service-result';
import { ServiceResultBase } from 'src/app/data/types/service-results/service-result-base';
import { ToastrService } from 'src/app/lib/toastr/toastr.service';

@Component({
  selector: 'app-add-edit-company',
  templateUrl: './add-edit-company.component.html',
  styleUrls: ['./add-edit-company.component.scss']
})
export class AddEditCompanyComponent implements OnInit {
  imageSrc: string | ArrayBuffer | null;
  loading$ = new BehaviorSubject<boolean>(false)
  deviceType = ResponsizeSize
  companyForm!: FormGroup
  companyId: number | null
  companyLogoData!: string | null

  constructor(
    public responsiveService: ResponsiveService, 
    private readonly companyService: CompanyService,
    private router: Router,
    private readonly route: ActivatedRoute,
    private toastr: ToastrService,
    private resultBannerActionService: BannerResultActionService
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
    this.loading$.next(true)
    const newCompany: CreateCompanyDto = this.createNewCompanyModel()
    this.companyService
    .createNewCompany(newCompany)
    .pipe(first(),finalize(()=> this.loading$.next(false)))
    .subscribe({
      next:(response: ServiceResult<CreateCompanyDto>) => {
        if (response.success) {
          if (this.responsiveService.responsiveSize.value === this.deviceType.Desktop) {
            this.toastr.success(`${response.result?.name} entry was created succefully.`, 'Create Success')
          } 
          else {
            this.resultBannerActionService.success('Create Success', `${response.result?.name} entry was created succefully.`)
          }
          
        } else {
          if (this.responsiveService.responsiveSize.value === this.deviceType.Desktop) {
            this.toastr.error(`${response.result?.name} failed to update. Error: ${response.error}.`, 'Create failed')
          } else {
            this.resultBannerActionService.error('Create failed', `${response.result?.name} failed to create. Error: ${response.error}.`)
          }
        }
        this.router.navigate(['Company/view/' + response.result?.name, {id:response.result?.id} ])
      },
      error: (error: ServiceResultBase) => {
        if (this.responsiveService.responsiveSize.value === this.deviceType.Desktop) {
          this.toastr.error( `${error.error}`, 'Error')
        } else {
          this.resultBannerActionService.error('Error', `${error.error}`)
        }
      }
    })
  }

  updateCompany() {
    this.loading$.next(true)
    const newCompany: UpdateCompanyDto = this.updateCompanyModel()
    this.companyService
    .updateCompany(newCompany)
    .pipe(first(),finalize(()=> this.loading$.next(false)))
    .subscribe({
      next:(response: ServiceResult<UpdateCompanyDto>) => {
        if (response.success) {
          if (this.responsiveService.responsiveSize.value === this.deviceType.Desktop) {
            this.toastr.success(`${response.result?.name} was updated succefully.`, 'Update Success')
          } 
          else {
            this.resultBannerActionService.success('Update Success', `${response.result?.name} was updated succefully.`)
          }
        } else {
          if (this.responsiveService.responsiveSize.value === this.deviceType.Desktop) {
            this.toastr.error(`${response.result?.name} failed to update. Error: ${response.error}.`, 'Update failed')
          } else {
            this.resultBannerActionService.error('Update failed', `${response.result?.name} failed to update. Error: ${response.error}.`)
          }
        }
        this.router.navigate(['Company/view/' + response.result?.name, {id:response.result?.id} ])
      },
      error: (error: ServiceResultBase) => {
        if (this.responsiveService.responsiveSize.value === this.deviceType.Desktop) {
          this.toastr.error( `${error.error}`, 'Error')
        } else {
          this.resultBannerActionService.error('Error', `${error.error}`)
        }
      }
    })
  }

  createNewCompanyModel(): CreateCompanyDto {
    let model: CreateCompanyDto = {
      id: null,
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

  updateCompanyModel(): UpdateCompanyDto {
    let model: UpdateCompanyDto = {
      id: this.companyId!,
      name: this.companyForm.get('generalDetails')?.get('name')?.value,
      description: this.companyForm.get('generalDetails')?.get('description')?.value,
      newCompanyLogoId: this.companyForm.get('generalDetails')?.get('image')?.value,
      parentCompany: this.companyForm.get('parentCompany')?.value,
      foundedIn: this.companyForm.get('foundedDetails')?.get('foundedIn')?.value,
      countryId: this.companyForm.get('foundedDetails')?.get('country')?.value,
      statusId: this.companyForm.get('statusDetails')?.get('status')?.value,
      changedDate: this.companyForm.get('statusDetails')?.get('changedDate')?.value,
      officialWebsite: this.companyForm.get('linksDetails')?.get('officialWebsite')?.value,
      twitter: this.companyForm.get('linksDetails')?.get('twitter')?.value,
      companyLogoId: this.companyForm.get('generalDetails')?.get('companyLogoId')?.value,
    }
    return model
  }

  clickToReturnBack() {
    this.router.navigate(['Company']);
  }

  getEditFormData(companyId: number){
    this.loading$.next(true)
    this.companyService
    .getCompany(companyId)
    .pipe(first(),finalize(()=> this.loading$.next(false)))
    .subscribe((res) => {
      this.companyForm.get('generalDetails')?.get('name')?.patchValue(res.name),
      this.companyForm.get('generalDetails')?.get('description')?.patchValue(res.description),
      this.companyForm.get('generalDetails')?.get('companyLogoId')?.patchValue(res.companyLogoId),
      this.companyForm.get('parentCompany')?.patchValue(res.parentCompanyId),
      this.companyForm.get('foundedDetails')?.get('foundedIn')?.patchValue(res.foundedIn),
      this.companyForm.get('foundedDetails')?.get('country')?.patchValue(res.countryId),
      this.companyForm.get('statusDetails')?.get('status')?.patchValue(res.statusId),
      this.companyForm.get('statusDetails')?.get('changedDate')?.patchValue(res.changedDate),
      this.companyForm.get('linksDetails')?.get('officialWebsite')?.patchValue(res.officialWebsite),
      this.companyForm.get('linksDetails')?.get('twitter')?.patchValue(res.twitter)
      this.companyLogoData = res.imageData
    })
  }

}
