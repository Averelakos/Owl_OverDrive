import { Injectable } from "@angular/core";
import { FormBuilder, FormGroup } from "@angular/forms";
import { environment } from "src/environments/environment";
import { HttpClient} from "@angular/common/http";

@Injectable()
export class GameService{
    uri: string = 'Game'
    baseUrl = environment.apiUrl+this.uri;
    constructor(private readonly formBuilder: FormBuilder, private http: HttpClient){}

    initForm(): FormGroup {
        return this.formBuilder.group({
          general: this.formBuilder.group({
            name:[null],
            description:[null],
            image:[null],
            gameType:this.formBuilder.group({
              typeId: [null],
              baseGame:[null]
            }),
            gameStatus:[null],
            gameEdition:this.formBuilder.group({
              baseGame: [null],
              editionTitle: [null]
            }),
            gameAlternativeNames:this.formBuilder.array([])
          }),
          localization: this.formBuilder.array([]),
          categorization: this.formBuilder.group({
            genre:[null],
            theme:[null],
            perspectives:[null],
            gameMode:[null],
            multiplayerModes: this.formBuilder.array([])
          }),
          releaseDates: this.formBuilder.array([]),
          websites: this.formBuilder.group({
            steam: [null],
            epic: [null],
            appStorePhone: [null],
            itch: [null],
            gog:[null],
            googlePlay:[null],
            appStoreTablet: [null],
            official: [null],
            twitch: [null],
            youtube: [null],
            facebook: [null],
            twitter:[null],
            instagram:[null],
            discord: [null],
            reddit:[null]
          }),
          companies: this.formBuilder.array([]),
          storyline: [null]
        })
    }

    // createNewCompany(model: CreateCompanyDto){
    //   return this.http.post<ServiceResult<CreateCompanyDto>>(this.baseUrl + '/AddCompany',model)
    // }
    // updateCompany(model: UpdateCompanyDto){
    //   return this.http.post<ServiceResult<UpdateCompanyDto>>(this.baseUrl + '/UpdateCompany',model)
    // }

    // searchParentCompany(searchInput: string){
    //   // console.log(input)
    //   const body = JSON.stringify(searchInput)
    //   const params = new HttpParams().set('searchInput', searchInput)
    //   return this.http.post<any>(this.baseUrl + '/SearchParent', null, { params })
    // }

    // getAllCompanies() {
    //   return this.http.get<Array<ListCompanyDto>>(this.baseUrl + '/list')
    // }

    // getCompany(companyId) {
    //   return this.http.get<SimpleCompany>(this.baseUrl + `/GetCompany?companyId=${companyId}`)
    // }

    // getCompanyLogoEdit(companyId) {
    //   return this.http.get<any>(this.baseUrl + `/GetCompanyLogo?companyId=${companyId}`)
    // }
}