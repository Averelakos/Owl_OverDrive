import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuardCanLoad } from './core/auth/guards/auth.can-load.guard';

const routes: Routes = [
  {
    path:'Auth',
    loadChildren:() => import('./layouts/auth-layout/auth-layout.module').then(m => m.AuthLayoutModule)
  },
  {
    path:'',
    loadChildren: () => import('./layouts/admin-layout/admin-layout.module').then((m) => m.AdminLayoutModule),
    canLoad: [AuthGuardCanLoad]
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
  
 }
