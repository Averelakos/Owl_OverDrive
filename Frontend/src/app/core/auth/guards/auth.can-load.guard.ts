import { inject } from "@angular/core";
import { CanLoadFn, Router } from "@angular/router";
import { AuthService } from "../auth.service";
import { ToastrService } from "src/app/lib/toastr/toastr.service";

export const AuthGuardCanLoad: CanLoadFn = (route, state) => {
    const authService = inject(AuthService)
    const toaster = inject(ToastrService)
    const router = inject(Router)

    if(authService.isAuthenticated()){
        return true
    } else {
        router.navigate(['/Auth/SignIn'], { replaceUrl: true })
        toaster.error('Unauthorized')
        return false
    }
}