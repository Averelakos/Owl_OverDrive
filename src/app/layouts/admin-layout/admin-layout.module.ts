import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { RouterModule } from "@angular/router";
import { AdminLayoutComponent } from "./container/admin-layout.component";


@NgModule({
    imports:[
        BrowserModule,
        RouterModule
    ],
    providers:[],
    declarations:[
        AdminLayoutComponent
    ],
    exports:[
       AdminLayoutComponent
    ]
})
export class AdminLayoutModule{}