import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { RegisterDto } from 'src/app/core/models/Auth/registerDto';
import * as moment from 'moment';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.scss']
})
export class SignUpComponent implements OnInit {

  constructor(private router: Router) {}

  ngOnInit(): void {
    this.buildRegisterForm();
  }

  registerForm: FormGroup;
  registerData: RegisterDto;

  onSubmit(){
    if (this.registerForm.valid) {

      const birthDate = this.registerForm.value.dateOfBirth;
     
      this.registerData = {
        email: this.registerForm.value.email.toString(),
        password: this.registerForm.value.password.toString(),
        name: this.registerForm.value.name.toString(),
        dateOfBirth: moment(Date.parse(birthDate.year+' '+ birthDate.month +' '+ birthDate.day)).format("DD/MM/YYYY")
      };

    }

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
  buildRegisterForm(){
    this.registerForm = new FormGroup({
      'email': new FormControl(null, [Validators.required, Validators.email] ),
      'name': new FormControl(null,[Validators.required]),
      'password': new FormControl(null, [Validators.required]),
      'dateOfBirth': new FormGroup({
        'year': new FormControl(null, [Validators.required]),
        'month': new FormControl(null, [Validators.required]),
        'day': new FormControl(null, [Validators.required]),
      })
    }, 
    {updateOn: 'blur'}
    );
  }

  redirectToLoginPage() {
    this.router.navigate(['/Auth/SignIn']);
  }

}
