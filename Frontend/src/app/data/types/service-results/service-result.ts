import { ServiceResultBase } from "./service-result-base";

export interface ServiceResult<T> extends ServiceResultBase{
    result: T | undefined
}

