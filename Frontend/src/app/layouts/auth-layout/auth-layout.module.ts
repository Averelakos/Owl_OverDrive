import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { ReactiveFormsModule } from "@angular/forms";
import { RouterModule, Routes } from "@angular/router";
import { SharedComponentsModule } from "src/app/shared/shared.module";
import { AuthLayoutComponent } from './container/auth-layout.component';
import { ResultBannerComponent } from "src/app/common/result-banner/result-banner.component";

const routes: Routes = [
  {
      path:'',
      component: AuthLayoutComponent,
      children:[
        {
        path:'',
        loadChildren:() => import('../../modules/auth/auth.module').then(m => m.AuthModule)
        }
      ]
  }
]

@NgModule({
    imports:[
      CommonModule, 
      ReactiveFormsModule,     
      SharedComponentsModule,
      RouterModule.forChild(routes),
      ResultBannerComponent,
      

    ],
    providers:[],
    declarations:[
    AuthLayoutComponent,
  ],
    exports:[
    ]
})
export class AuthLayoutModule{}