import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { RouterModule, Routes } from "@angular/router";
import { AdminLayoutComponent } from "./container/admin-layout.component";
import { AdminHeaderMobileComponent } from './components/admin-header-mobile/admin-header-mobile.component';
import { AdminSidebarComponent } from './components/admin-sidebar/admin-sidebar.component';
// import { ClickOutsideDirective } from "src/app/shared/directives/outside.directive";
import { SharedComponentsModule } from "src/app/shared/shared.module";
import { AdminHeaderComponent } from "./components/admin-header/admin-header.component";
import { AdminFooterComponent } from "./components/admin-footer/admin-footer.component";
import { AdminSidebarMobileComponent } from './components/admin-sidebar-mobile/admin-sidebar-mobile.component';
import { ResultBannerComponent } from "src/app/common/result-banner/result-banner.component";
import { CommonModule } from "@angular/common";
import { AuthGuarCanActivateChild } from "src/app/core/auth/guards/auth.can-activate-child.guard";
// import { SharedComponentsModule } from "src/app/shared/shared.module";

const routes: Routes = [
    {
        path:'',
        component:AdminLayoutComponent,
        children:[
        {path:'',redirectTo:'Home', pathMatch:'full'},
        {path:'Home', loadChildren:() => import('../../modules/home/home.module').then(m => m.HomeModule), canActivateChild: [AuthGuarCanActivateChild]},
        {path:'Test', loadChildren:()=> import('../../modules/test/test-page.module').then(m => m.TestPageModule), canActivateChild: [AuthGuarCanActivateChild]},
        {path: 'Company', loadChildren:() => import('../../modules/company/companies.module').then(m => m.CompanyModule), canActivateChild: [AuthGuarCanActivateChild]},
        {path: 'Game', loadChildren:() => import('../../modules/game/games.module').then(m => m.GamesModule), canActivateChild: [AuthGuarCanActivateChild]}
        ]
    },
]

@NgModule({
    imports:[
        CommonModule,
        RouterModule,
        SharedComponentsModule,
        ResultBannerComponent,
        RouterModule.forChild(routes),
    ],
    providers:[],
    declarations:[
        AdminLayoutComponent,
        AdminHeaderMobileComponent,
        AdminHeaderComponent,
        AdminSidebarComponent,
        AdminFooterComponent,
        AdminSidebarMobileComponent,
        // ClickOutsideDirective
    ],
    exports:[
       AdminLayoutComponent
    ]
})
export class AdminLayoutModule{}