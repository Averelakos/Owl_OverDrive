import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { ReactiveFormsModule } from "@angular/forms";
import { RouterModule } from "@angular/router";
import { SharedComponentsModule } from "src/app/shared/shared.module";
import { AuthLayoutComponent } from './container/auth-layout.component';


@NgModule({
    imports:[
      CommonModule, 
      ReactiveFormsModule,     
      SharedComponentsModule,
      RouterModule,
      

    ],
    providers:[],
    declarations:[
    AuthLayoutComponent,
  ],
    exports:[
    ]
})
export class AuthLayoutModule{}