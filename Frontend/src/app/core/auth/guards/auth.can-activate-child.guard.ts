import { inject } from "@angular/core";
import { CanActivateChildFn, CanActivateFn, Router } from "@angular/router";
import { AuthService } from "../auth.service";
import { ToastrService } from "src/app/lib/toastr/toastr.service";

export const AuthGuarCanActivateChild: CanActivateChildFn = (route, state) => {
    const authService = inject(AuthService)
    const toaster = inject(ToastrService)
    const router = inject(Router)

    let result = true

    //check if route requires one or more permissions
    const permissions = !!route && !!route.data && !!route.data['permissions'] ? route.data['permissions'] : null

    if (!!permissions) {
      // user has any of the requested permissions
      result = authService.hasAnyOfPermissions(permissions)
    }

    if (!result) {
      router.navigate(['/', 'unauthorized'])
    }

    return result
}