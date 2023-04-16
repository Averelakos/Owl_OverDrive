import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { menu } from './core/models/menu';
import { MenuService } from './core/services/menu.service';
import { AdminLayoutModule } from './layouts/admin-layout/admin-layout.module';
import { AuthLayoutModule } from './layouts/auth-layout/auth-layout.module';
import { LocalService } from './core/services/local.service';

@NgModule({
  declarations: [
    AppComponent,
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    AdminLayoutModule,
    AuthLayoutModule
  ],
  providers: [MenuService, LocalService],
  bootstrap: [AppComponent]
})
export class AppModule {
  constructor(public menuService: MenuService) {
    menuService.addMenu(menu);
  }
 }
