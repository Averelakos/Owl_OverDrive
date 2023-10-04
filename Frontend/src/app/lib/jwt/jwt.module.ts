import { ModuleWithProviders, NgModule, Optional, SkipSelf } from "@angular/core";
import { JwtModuleOptions } from "./interfaces/jwt-module-options";
import { HTTP_INTERCEPTORS } from "@angular/common/http";
import { JwtInterceptor } from "./jwt.interceptor";
import { JWT_OPTIONS } from "./jwt-options.token";
import { JwtHelperService } from "./jwt-helper.service";

@NgModule()
export class JwtModule {
  constructor(@Optional() @SkipSelf() parentModule: JwtModule) {
    if (parentModule) {
      throw new Error(
        `JwtModule is already loaded. It should only be imported in your application's main module.`
      );
    }
  }
  static forRoot(options: JwtModuleOptions): ModuleWithProviders<JwtModule> {
    return {
      ngModule: JwtModule,
      providers: [
        {
          provide: HTTP_INTERCEPTORS,
          useClass: JwtInterceptor,
          multi: true,
        },
        options.jwtOptionsProvider || {
          provide: JWT_OPTIONS,
          useValue: options.config,
        },
        JwtHelperService,
      ],
    };
  }
}