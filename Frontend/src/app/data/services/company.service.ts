import { Injectable } from "@angular/core";
import { FormBuilder, FormGroup } from "@angular/forms";
import { NewCompany } from "../types/company/new-company";
import { environment } from "src/environments/environment";
import { HttpClient } from "@angular/common/http";

@Injectable()
export class CompanyService{
    baseUrl = environment.apiUrl;
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

    createNewCompany(newCompany: NewCompany){
      console.log(this.baseUrl)
      return this.http.get<any>(this.baseUrl+'WeatherForecast')
    }
}