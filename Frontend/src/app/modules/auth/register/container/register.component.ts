import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { RegisterDto } from 'src/app/core/models/Auth/registerDto';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/core/auth/auth.service';
import { BehaviorSubject, finalize, first } from 'rxjs';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  loading$ = new BehaviorSubject<boolean>(false)
  registerForm: FormGroup;
  registerData: RegisterDto;

  constructor(private router: Router, private readonly authService: AuthService) {
    this.authService.isAuthorized()
  }
  ngOnInit(): void {
    this.registerForm = this.authService.initRegisterForm()
  }

  onSubmit(){
    // if (this.registerForm.valid) {
     
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
        this.authService.loginActions(res)
      });

    // }

  }
  
  /**
 * We create the register form and the controls
 * that we are going to use in the html
 * file and we assign it in the form group
 */
  // buildRegisterForm(){
  //   this.registerForm = new FormGroup({
  //     'email': new FormControl(null, [Validators.required, Validators.email] ),
  //     'name': new FormControl(null,[Validators.required]),
  //     'password': new FormControl(null, [Validators.required])
  //   }, 
  //   {updateOn: 'blur'}
  //   );
  // }

  redirectToLoginPage() {
    this.router.navigate(['/Auth/login']);
  }

}
