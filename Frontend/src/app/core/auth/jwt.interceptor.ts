import { HttpEvent, HttpHandler, HttpHeaders, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { AuthService } from "./auth.service";
import { HeaderModel } from "../enums/enum-header-model";

@Injectable()
export class JwtInterceptor implements HttpInterceptor{
   
    constructor(private authService: AuthService){}

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        let headers = new HttpHeaders()
        
        if (this.authService.isAuthenticated()) {
            headers = headers.append(HeaderModel.AUTHORIZATION, `Bearer ${this.authService.getToken()}`)
        } else {
            headers = headers.append(HeaderModel.CONTENT_TYPE, 'application/json')
        }
      
        request = request.clone({ headers })

        return next.handle(request)
    }

}