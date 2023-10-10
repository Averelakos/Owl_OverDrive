import { ERole } from "src/app/core/enums/enum-role";
import { DataLoaderOptions } from "../data-loader/data-loader-options";

export interface RequestGetUserByRole{
    role: ERole
    options: DataLoaderOptions
}