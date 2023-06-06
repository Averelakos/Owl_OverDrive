import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { RouterModule } from "@angular/router";
import { AdminLayoutComponent } from "./container/admin-layout.component";
import { AdminHeaderMobileComponent } from './components/admin-header-mobile/admin-header-mobile.component';
import { AdminSidebarComponent } from './components/admin-sidebar/admin-sidebar.component';
// import { ClickOutsideDirective } from "src/app/shared/directives/outside.directive";
import { SharedComponentsModule } from "src/app/shared/shared.module";
import { AdminHeaderComponent } from "./components/admin-header/admin-header.component";
import { AdminFooterComponent } from "./components/admin-footer/admin-footer.component";
import { AdminSidebarMobileComponent } from './components/admin-sidebar-mobile/admin-sidebar-mobile.component';
// import { SharedComponentsModule } from "src/app/shared/shared.module";


@NgModule({
    imports:[
        BrowserModule,
        RouterModule,
        SharedComponentsModule
    ],
    providers:[],
    declarations:[
        AdminLayoutComponent,
        AdminHeaderMobileComponent,
        AdminHeaderComponent,
        AdminSidebarComponent,
        AdminFooterComponent,
        AdminSidebarMobileComponent
        // ClickOutsideDirective
    ],
    exports:[
       AdminLayoutComponent
    ]
})
export class AdminLayoutModule{}