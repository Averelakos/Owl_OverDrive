import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { HttpClient} from "@angular/common/http";
import { UserSimpleDto } from "../types/user/user-simple-dto";


@Injectable()
export class UserService{
  uri: string = 'User'
  baseUrl = environment.apiUrl+this.uri;

  constructor(private http: HttpClient){}

  

  getAllUsersWithRoles() {
    return this.http.get<Array<UserSimpleDto>>(this.baseUrl + `/GetAllUsersWithRoles`)
  }

}