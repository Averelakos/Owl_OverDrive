import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { HomeComponent } from "./container/home.component";
import { StandarLoaderComponent } from "src/app/common/standar-loader/standar-loader.component";


const routes: Routes = [
    {path:'', component:HomeComponent},
]

@NgModule({
    imports:[
        RouterModule.forChild(routes),
        // BrowserModule,
        StandarLoaderComponent
    ],
    providers:[],
    declarations:[
        HomeComponent
  ],
    exports:[
        HomeComponent,
        RouterModule
    ]
})
export class HomeModule{}