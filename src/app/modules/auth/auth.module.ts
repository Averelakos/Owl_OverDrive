import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { ReactiveFormsModule } from "@angular/forms";
import { RouterModule, Routes } from "@angular/router";
import { SharedComponentsModule } from "src/app/shared/shared.module";
import { SignInComponent } from "./signIn/container/sign-in.component";
import { SignUpComponent } from './signUp/container/sign-up.component';
import { BirthdateSelectorsComponent } from './signUp/components/birthdate-selectors/birthdate-selectors.component';


const routes: Routes = [
    {path:'SignIn', component:SignInComponent},
    {path:'SignUp', component:SignUpComponent},

]

@NgModule({
    imports:[
        CommonModule, 
        RouterModule.forChild(routes),
        ReactiveFormsModule,
        SharedComponentsModule,
    ],
    providers:[],
    declarations:[
  
    SignInComponent,
    SignUpComponent,
    BirthdateSelectorsComponent
  ],
    exports:[
        RouterModule
    ]
})
export class AuthModule{}