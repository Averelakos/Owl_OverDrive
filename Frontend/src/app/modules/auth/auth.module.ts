import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { ReactiveFormsModule } from "@angular/forms";
import { RouterModule, Routes } from "@angular/router";
import { SharedComponentsModule } from "src/app/shared/shared.module";

import { LoginComponent } from "./login/container/login.component";
import { RegisterComponent } from "./register/container/register.component";
import { MatInputComponent } from "src/app/common/input-fields/mat-text-input/mat-input.component";
import { SpinnerLoaderComponent } from "src/app/common/loaders/spinner-loader/spinner-loader";

const routes: Routes = [
  {path:'login', component:LoginComponent},
  {path:'register', component:RegisterComponent},
]

@NgModule({
    imports:[
        CommonModule, 
        RouterModule.forChild(routes),
        ReactiveFormsModule,
        MatInputComponent,
        SpinnerLoaderComponent
    ],
    providers:[],
    declarations:[
  
    LoginComponent,
    RegisterComponent,
  ],
    exports:[
        RouterModule
    ]
})
export class AuthModule{}