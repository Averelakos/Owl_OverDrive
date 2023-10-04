import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { ReactiveFormsModule } from "@angular/forms";
import { RouterModule, Routes } from "@angular/router";
import { SharedComponentsModule } from "src/app/shared/shared.module";
import { SignInComponent } from "./signIn/container/sign-in.component";
import { SignUpComponent } from './signUp/container/sign-up.component';
import { BirthdateSelectorsComponent } from './signUp/components/birthdate-selectors/birthdate-selectors.component';
import { AuthLayoutComponent } from "src/app/layouts/auth-layout/container/auth-layout.component";


const routes: Routes = [
    {path:'SignIn', component:SignInComponent},
    {path:'SignUp', component:SignUpComponent},
]

// {
  //   path:'',
  //   component:AdminLayoutComponent,
  //   children:[
  //     {path:'',redirectTo:'Home', pathMatch:'full'},
  //     {path:'Home', loadChildren:() => import('./modules/home/home.module').then(m => m.HomeModule)},
  //     {path:'Test', loadChildren:()=> import('./modules/test/test-page.module').then(m => m.TestPageModule)},
  //     {path: 'Company', loadChildren:() => import('./modules/company/companies.module').then(m => m.CompanyModule)},
  //     {path: 'Game', loadChildren:() => import('./modules/game/games.module').then(m => m.GamesModule)}
  //   ]
  // },

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