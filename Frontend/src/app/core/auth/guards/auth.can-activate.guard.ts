import { inject } from "@angular/core";
import { CanActivateFn } from "@angular/router";
import { AuthService } from "../auth.service";
import { ToastrService } from "src/app/lib/toastr/toastr.service";

export const AuthGuarCanActivate: CanActivateFn = (route, state) => {
    const authService = inject(AuthService)
    const toaster = inject(ToastrService)

    if(authService.isAuthenticated()){
        return true
    } else {
        toaster.error('Unauthorized')
        return false
    }
}