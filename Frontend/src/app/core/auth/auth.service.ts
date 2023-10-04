import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { HttpClient} from "@angular/common/http";
import { RegisterDto } from "../models/Auth/registerDto";
import { JwtHelperService } from "src/app/lib/jwt/jwt-helper.service";
import { LoginDto } from "../models/Auth/loginDto";

const tokenKey = 'auth-token'

@Injectable({
  providedIn: 'root'
})
export class AuthService{
    key: string = 'Auth'
    baseUrl = environment.apiUrl + this.key;
    private jwtHelper = new JwtHelperService()
    private username!: string
    private userId: number | null = null
    private authenticationState: boolean = false
    constructor(private http: HttpClient){}

    loginActions(response: any){
        if(response && response.token) {
            localStorage.setItem(tokenKey, response.token)
            this.authenticationState = true
            this.saveTokenInfo(response.token)
        }
    }

    private saveTokenInfo(token: string) {
        const decodedToken = this.jwtHelper.decodeToken(token)

        this.username = decodedToken.upn
        this.userId = +decodedToken.nameid
    }

    /**
     * Checks if we have a valid authenticated state
     * @returns the authentication state
     */
    isAuthenticated(): boolean {
        return this.authenticationState
    }
    
    register(model: RegisterDto){
        return this.http.post<any>(this.baseUrl + '/register',model)
    }

    login(model: LoginDto){
        return this.http.post<any>(this.baseUrl + '/login',model)
    }
}