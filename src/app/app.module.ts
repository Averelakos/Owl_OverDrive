import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { menu } from './core/models/menu';
import { MenuService } from './core/services/menu.service';
import { AdminLayoutModule } from './layouts/admin-layout/admin-layout.module';
import { AuthLayoutModule } from './layouts/auth-layout/auth-layout.module';
import { LocalService } from './core/services/local.service';
import { LayoutModule } from '@angular/cdk/layout';
import { ResponsiveService } from './core/services/responsive.service';

@NgModule({
  declarations: [
    AppComponent,
    
  ],
  imports: [
    BrowserModule,
    LayoutModule,
    AppRoutingModule,
    AdminLayoutModule,
    AuthLayoutModule
  ],
  providers: [MenuService, LocalService, ResponsiveService],
  bootstrap: [AppComponent]
})
export class AppModule {
  constructor(public menuService: MenuService) {
    menuService.addMenu(menu);
  }
 }
