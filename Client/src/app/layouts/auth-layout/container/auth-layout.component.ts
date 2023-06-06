import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-auth-layout',
  templateUrl: './auth-layout.component.html',
  styleUrls: ['./auth-layout.component.scss']
})
export class AuthLayoutComponent implements OnInit {
  

  
  ngOnInit(): void {
    this.createForm();
  }

  loginForm: FormGroup;
  isLoading = false;
  error = '';

  onSubmit(){
    
    if(!this.loginForm.valid){
      return;
    }

    this.isLoading = true;

    const loginData = {
      email: this.loginForm.value.email.toString(),
      password: this.loginForm.value.password.toString()
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
   * We create the form and the controls
   * that we are going to use in the html
   * file and we assign it in the form group
   */
   createForm(){
    this.loginForm = new FormGroup({
      'email': new FormControl(null, [Validators.required, Validators.email/*, this.forbiddenEmails.bind(this)*/] ),
      'password': new FormControl(null, Validators.required)
    });
  }
}
