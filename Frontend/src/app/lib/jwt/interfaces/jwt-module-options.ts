import { Provider } from "@angular/core";
import { JwtConfig } from "./jwt-config";

export interface JwtModuleOptions {
    jwtOptionsProvider?: Provider;
    config?: JwtConfig;
  }