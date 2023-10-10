import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { HttpClient} from "@angular/common/http";
import { UserSimpleDto } from "../types/user/user-simple-dto";
import { RequestGetUserByRole } from "../types/user/request-get-user-by-role";
import { ServiceSearchResultData } from "../types/service-results/service-searc-result-data";


@Injectable()
export class UserService{
  uri: string = 'User'
  baseUrl = environment.apiUrl+this.uri;

  constructor(private http: HttpClient){}

  

  getAllUsersWithRoles(model: RequestGetUserByRole) {
    return this.http.post<ServiceSearchResultData<Array<UserSimpleDto>>>(this.baseUrl + `/GetAllUsersWithRoles`, model)
  }

  getUser(userId: number) {
    return this.http.get<UserSimpleDto>(this.baseUrl + `/GetUserById?userId=${userId}`)
  }

  updateUserRole(model: UserSimpleDto) {
    return this.http.post<any>(this.baseUrl + `/UpdateUserRole`, model)
  }

}