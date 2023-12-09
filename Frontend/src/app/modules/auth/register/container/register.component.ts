import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { RegisterDto } from 'src/app/core/models/Auth/registerDto';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/core/auth/auth.service';
import { BehaviorSubject, finalize, first } from 'rxjs';
import { ResponsiveService, ResponsizeSize } from 'src/app/core/services/responsive.service';
import { ToastrService } from 'src/app/lib/toastr/toastr.service';
import { BannerResultActionService } from 'src/app/core/services/result-banner-action.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  loading$ = new BehaviorSubject<boolean>(false)
  registerForm: FormGroup;
  registerData: RegisterDto;
  deviceType = ResponsizeSize

  constructor(
    private router: Router, 
    private readonly authService: AuthService,
    public responsiveService: ResponsiveService,
    private toastr: ToastrService,
    private resultBannerActionService: BannerResultActionService
    ) {
    this.authService.isAuthorized()
  }
  ngOnInit(): void {
    this.registerForm = this.authService.initRegisterForm()
    console.log(this.registerForm.get('email'))
  }

  onSubmit(){
      this.validateAllFormFields(this.registerForm)
      if(this.registerForm.valid) {
        this.loading$.next(true)

        this.registerData = {
          email: this.registerForm.value.email,
          password: this.registerForm.value.password,
          username: this.registerForm.value.username,
        };

        this.authService
        .register(this.registerData)
        .pipe(first(),finalize(()=> this.loading$.next(false)))
        .subscribe((res) => {
          if(res.token !== null && res.token !== '') {
            this.authService.loginActions(res)
            this.router.navigate(['/'], { replaceUrl: true })
          } else {
            if (this.responsiveService.responsiveSize.value === this.deviceType.Desktop) {
              this.toastr.error(`Account with this email already exists.`, 'Create Account failed')
            } else {
              this.resultBannerActionService.error('Create Account failed', `Account with this email already exists.`)
            }
          }
        });

    }
  }

  validateAllFormFields(formGroup: FormGroup) {         //{1}
    Object.keys(formGroup.controls).forEach(field => {  //{2}
      const control = formGroup.get(field);             //{3}
      if (control instanceof FormControl) {             //{4}
        control.markAsTouched({ onlySelf: true });
      } else if (control instanceof FormGroup) {        //{5}
        this.validateAllFormFields(control);            //{6}
      }
    });
  }
  
  redirectToLoginPage() {
    this.router.navigate(['/Auth/login']);
  }

}
