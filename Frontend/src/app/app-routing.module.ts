import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminLayoutComponent } from './layouts/admin-layout/container/admin-layout.component';
import { AuthLayoutComponent } from './layouts/auth-layout/container/auth-layout.component';

const routes: Routes = [
  {
    path:'Auth',
    component:AuthLayoutComponent,
    children:[
      {path:'', loadChildren:() => import('./modules/auth/auth.module').then(m => m.AuthModule)},
    ]
  },
  {
    path:'',
    component:AdminLayoutComponent,
    children:[
      {path:'',redirectTo:'Home', pathMatch:'full'},
      {path:'Home', loadChildren:() => import('./modules/home/home.module').then(m => m.HomeModule)},
      {path:'Test', loadChildren:()=> import('./modules/test/test-page.module').then(m => m.TestPageModule)},
      {path: 'Company', loadChildren:() => import('./modules/company/companies.module').then(m => m.CompanyModule)},
      {path: 'Game', loadChildren:() => import('./modules/game/games.module').then(m => m.GamesModule)}
    ]
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
  
 }
