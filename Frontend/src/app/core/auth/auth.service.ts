import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { HttpClient} from "@angular/common/http";
import { RegisterDto } from "../models/Auth/registerDto";
import { JwtHelperService } from "src/app/lib/jwt/jwt-helper.service";
import { LoginDto } from "../models/Auth/loginDto";
import { FormBuilder, FormGroup } from "@angular/forms";
import { Router } from "@angular/router";
import { EPermission } from "../enums/enum-permissions";

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
    private roles: Array<string> = []
    private permissions: Array<string> = []
    private authenticationState: boolean = false
    constructor(
        private readonly formBuilder: FormBuilder, 
        private http: HttpClient,
        private router: Router
    ){}

    initRegisterForm(): FormGroup {
        return this.formBuilder.group({
            username:[null],
            email:[null],
            password:[null]
        })
    }

    initLoginForm(): FormGroup {
        return this.formBuilder.group({
            username:[null],
            password:[null]
        },
        {updateOn: 'blur'}
        )
    }

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
        this.roles = this.fixNullSingleOrlist(decodedToken.role)
        this.permissions = this.fixNullSingleOrlist(decodedToken.permission)
    }

     /**
   * Init the service on startup to load
   */
    checkToken() {
        const token = localStorage.getItem(tokenKey)
        if (!!token) {
        this.authenticationState = true
        this.saveTokenInfo(token)
        } 
    }

    isAuthorized(){
        if(this.authenticationState) {
            this.router.navigate(['/'], { replaceUrl: true })
        }
    }

    /**
     * Checks if we have a valid authenticated state
     * @returns the authentication state
     */
    isAuthenticated(): boolean {
        return this.authenticationState
    }

    /**
     * Check if the user has a permission
     * @param permission The required permission to check
     * @returns whether or not the permission belongs to the user
     */
    hasPermission(permission: EPermission): boolean {
        let permissionString = EPermission[permission]
        return this.permissions ? this.permissions.includes(permissionString) : false
    }

    /**
     * Check if the user has any of the permissions provided
     * @param permissions the permissions to check
     * @returns whether or not the user has any of the permissions
     */
    hasAnyOfPermissions(permissions: Array<EPermission>): boolean {
        var permissionsString = permissions.map((x) => EPermission[x])
        return this.permissions ? this.permissions.some((x) => permissionsString.includes(x)) : false
    }

    getToken(): string | null {
        return localStorage.getItem(tokenKey)
      }
    
    register(model: RegisterDto){
        return this.http.post<any>(this.baseUrl + '/register',model)
    }

    login(model: LoginDto){
        return this.http.post<any>(this.baseUrl + '/login',model)
    }

   /**
   * Clear token reset state and redirect for azure logout
   */
  logout = () => {
    this.clear()
  }

  clear(expired = false) {
    localStorage.removeItem(tokenKey)
    this.authenticationState = false
    this.roles = []
    this.permissions = []
    this.username = ''
    // this.setServerInfo({})
    // this.name = ''
    // this.userId = null
    // this.stationId = null
    // this.employeeId = ''
    // this.currentUserStationId = null
    // this.worldTracerAgentId = ''
    const route: Array<any> = ['/', 'Auth', 'login']
    // if (expired) {
    //   route.push({ expired })
    // }
    this.router.navigate(route)
  }

    private fixNullSingleOrlist(value: any): Array<string> {
        let result
        if (value == null) {
          result = []
        } else if (!(value instanceof Array)) {
          result = [value]
        } else {
          result = value
        }
        return result
      }

    getUserId(){
        return this.userId
    }
}