import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { HttpClient } from "@angular/common/http";
import { LookupsDto } from "../types/lookups/lookupsDto";
import { CompanyStatusLookupDto } from "../types/lookups/company-status-lookup-dto";
import { CountryCodeLookupDto } from "../types/lookups/country-code-lookup-dto";

@Injectable({
  providedIn: 'root'
})
export class LookupsService{
    
  baseUrl = environment.apiUrl;
  key: string = 'Lookups'
  companyStatus!: Array<CompanyStatusLookupDto>
  countryCodes!: Array<CountryCodeLookupDto>

  constructor(private http: HttpClient){}

  init(){
    const savedLookUpString = localStorage.getItem(this.key)
    if (!!savedLookUpString){
      const lookups = JSON.parse(savedLookUpString)
      this.companyStatus = lookups.companyStatus
      this.countryCodes = lookups.countryCode
    } 
    else {
      this.getLookUps()
    }
  }

  getLookUps() {
    return this.http.get<LookupsDto>(this.baseUrl+'Looksup')
    .subscribe((response) => {
      this.set(response)
    })
  }

  set(lookups: LookupsDto) {
    localStorage.setItem(this.key,JSON.stringify(lookups))
    this.companyStatus = lookups.companyStatus
    this.countryCodes = lookups.countryCode
  }

  getCountryById(countryId: number| undefined) {
    const country = this.countryCodes.find((obj) => {
      return obj.id === countryId
    })

    return country;
  }

  getStatusById(statusId: number| undefined) {
    const status = this.companyStatus.find((obj) => {
      return obj.id === statusId
    })
    
    return status;
  }
}