import { AfterContentInit, AfterViewInit, Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginDto } from 'src/app/core/models/Auth/loginDto';
import { LocalService } from 'src/app/core/services/local.service';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.scss']
})
export class SignInComponent implements OnInit, AfterContentInit {

  loginForm: FormGroup;
  loginData: LoginDto;
  rememberMeCheckBox: any;

  constructor( private localService: LocalService, private router: Router) {}
  
  ngOnInit(): void {
    this.buildLoginForm();
  }

  ngAfterContentInit(): void {
    this.rememberMeCheckBox = document.getElementById('rememberMe');
    this.retrieveRememberMe();
  }

  onSubmit(){
    if (this.loginForm.valid) {
      this.rememberMe();

      this.loginData = {
        email: this.loginForm.value.email.toString(),
        password: this.loginForm.value.password.toString()
      }
      console.log(this.loginData)
    }
    

    //TODO: ADD LOADER

    //   this.authService.login(loginData).subscribe( 
    //     responce => { 
    //       console.log(responce);
          
    //       // this.authService.redirectInSuccess(responce);
    //       this.isLoading = false;
    //       this.route.navigate(['/Home'])
    //     }, 
    //     errorMessage => {
    //       // console.log(errorMessage);
    //       // this.toastr.error(errorMessage)
    //       // this.error = errorMessage;
    //       this.isLoading = false;
    //     }
    //   );
  }
  
  /**
 * We create the lofin form and the controls
 * that we are going to use in the html
 * file and we assign it in the form group
 */
  buildLoginForm(){
    this.loginForm = new FormGroup({
      'email': new FormControl(null, [Validators.required, Validators.email] ),
      'password': new FormControl(null, [Validators.required])
    }, 
    {updateOn: 'blur'}
    );
  }

  /**
   * Retrieve from local storage the login
   * values if there are saved there
   */
  retrieveRememberMe() {
    if(this.localService.getData('rememberMeCheckBox') && this.localService.getData('rememberMeCheckBox') !== ''){
      this.rememberMeCheckBox.setAttribute('checked', 'checked');
      this.loginForm.get('email')?.setValue( this.localService.getData('email'));
      this.loginForm.get('password')?.setValue( this.localService.getData('password'));
    } else {
      this.rememberMeCheckBox.removeAttribute('checked', 'checked');
    }
  }

  /**
   * If the checkBox is checked then 
   * save the email and password to the local storage 
   */
  rememberMe():void {
    if (this.rememberMeCheckBox.checked && this.loginForm.valid) {
      this.localService.saveData('email', this.loginForm.get('email')?.value);
      this.localService.saveData('password', this.loginForm.get('password')?.value);
      this.localService.saveData('rememberMeCheckBox', this.rememberMeCheckBox.value);
    }
  }

  redirectToRegisterPage() {
    this.router.navigate(['/Auth/SignUp']);
  }
}
