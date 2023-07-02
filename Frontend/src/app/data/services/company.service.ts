import { Injectable } from "@angular/core";
import { FormBuilder, FormGroup } from "@angular/forms";
import { CreateCompanyDto} from "../types/company/new-company";
import { environment } from "src/environments/environment";
import { HttpClient, HttpParams } from "@angular/common/http";
import { ListCompaniesComponent } from "src/app/modules/company/list/container/list-companies.component";
import { ListCompanyDto } from "../types/company/list-companies";
import { SimpleCompany } from "../types/company/simple-company";

@Injectable()
export class CompanyService{
    uri: string = 'Company'
    baseUrl = environment.apiUrl+this.uri;
    constructor(private readonly formBuilder: FormBuilder, private http: HttpClient){}

    initForm(): FormGroup {
        return this.formBuilder.group({
          generalDetails: this.formBuilder.group({
            name:[null],
            description:[null],
            image:[null]
          }),
          parentCompany:[null],
          foundedDetails: this.formBuilder.group({
            foundedIn:[null],
            country:[null]
          }),
          statusDetails: this.formBuilder.group({
            status:[null],
            changedDate:[null]
          }),
          linksDetails: this.formBuilder.group({
            officialWebsite:[null],
            twitter:[null]
          })
        })
    }

    createNewCompany(createCompany: CreateCompanyDto){
      return this.http.post<any>(this.baseUrl + '/AddCompany',createCompany)
    }

    searchParentCompany(searchInput: string){
      // console.log(input)
      const body = JSON.stringify(searchInput)
      const params = new HttpParams().set('searchInput', searchInput)
      return this.http.post<any>(this.baseUrl + '/SearchParent', null, { params })
    }

    getAllCompanies() {
      return this.http.get<Array<ListCompanyDto>>(this.baseUrl + '/list')
    }

    getCompany(companyId: number) {
      return this.http.get<any>(this.baseUrl + `/ViewCompany?companyId=${companyId}`)
    }

    getCompanyForEdit(companyId) {
      return this.http.get<any>(this.baseUrl + `/GetCompany?companyId=${companyId}`)
    }

    getCompanyLogoEdit(companyId) {
      return this.http.get<any>(this.baseUrl + `/GetCompanyLogo?companyId=${companyId}`)
    }
}