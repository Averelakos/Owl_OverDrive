import { Injectable } from "@angular/core";
import { BehaviorSubject, Subject } from "rxjs";

interface BannerResultInfo {
    title: string,
    message: string
}

@Injectable({
    providedIn:'root'
})
export class BannerResultActionService {
    displaySuccessBanner$ = new BehaviorSubject<boolean>(false)
    displayErrorBanner$ = new BehaviorSubject<boolean>(false)

    bannerInformation$ = new BehaviorSubject<BannerResultInfo | null>(null)
    constructor() {} 

    success(title: string, message: string) {
        let info: BannerResultInfo = {
            title: title,
            message: message
        }

        this.displaySuccessBanner$.next(true)
        this.bannerInformation$.next(info)
    }

    error(title: string, message: string) {
        let info: BannerResultInfo = {
            title: title,
            message: message
        }

        this.displayErrorBanner$.next(true)
        this.bannerInformation$.next(info)
    }

    clear() {
        this.displayErrorBanner$.next(false)
        this.displaySuccessBanner$.next(false)
        this.bannerInformation$.next(null)
    }
}