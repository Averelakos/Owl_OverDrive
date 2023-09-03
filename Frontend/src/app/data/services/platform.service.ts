import { Injectable } from "@angular/core";
import { FormBuilder } from "@angular/forms";
import { environment } from "src/environments/environment";
import { HttpClient, HttpParams } from "@angular/common/http";


@Injectable()
export class PlatformService{
  uri: string = 'Platform'
  baseUrl = environment.apiUrl+this.uri;
  constructor( private http: HttpClient){}

  searchPlatform(searchInput: string){
    const params = new HttpParams().set('input', searchInput)
    return this.http.post<any>(this.baseUrl + '/SearchPlatformByName', null, { params })
  }

  getPlatformById(searchInput: string){
    const params = new HttpParams().set('input', searchInput)
    return this.http.post<any>(this.baseUrl + '/GetPlatformById', null, { params })
  }

}