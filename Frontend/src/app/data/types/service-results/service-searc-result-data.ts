import { ServiceResultBase } from "./service-result-base"

export interface ServiceSearchResultData<T> extends ServiceResultBase{
    result: T | undefined
    totalCount : number
    totalPages: number 
}