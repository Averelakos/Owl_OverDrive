import { Injectable } from "@angular/core";
import {BreakpointObserver, Breakpoints} from '@angular/cdk/layout';
import { BehaviorSubject, filter } from "rxjs";

export enum ResponsizeSize {
    Mobile,
    Tablet,
    Desktop
}

@Injectable({
    providedIn: 'root'
})
export class ResponsiveService{

    // desktopMinWidth: string = '(min-width: 959px)'
    desktopMinWidth: string = '(min-width: 1200px)'
    tabletMinWidth: string = '(min-width: 1024px)'
    public responsiveSize = new BehaviorSubject<ResponsizeSize>(ResponsizeSize.Mobile)

    constructor(private responsive: BreakpointObserver) {
        this.responsive
        .observe(Breakpoints.Handset)
        .pipe(filter((x) => x.matches))
        .subscribe(() => this.responsiveSize.next(ResponsizeSize.Mobile))

        this.responsive
        .observe(Breakpoints.Tablet)
        .pipe(filter((x) => x.matches))
        .subscribe(() => this.responsiveSize.next(ResponsizeSize.Tablet))

        // this.responsive
        // .observe(this.tabletMinWidth)
        // .pipe(filter((x) => x.matches))
        // .subscribe(() => this.responsiveSize.next(ResponsizeSize.Tablet))

        // this.responsive
        // .observe([Breakpoints.Handset, Breakpoints.Tablet])
        // .pipe(filter((x) => !x.matches))
        // .subscribe(() => this.responsiveSize.next(ResponsizeSize.Desktop))

        this.responsive
        .observe(this.desktopMinWidth)
        .pipe(filter((x) => x.matches))
        .subscribe(() => this.responsiveSize.next(ResponsizeSize.Desktop))

        this.responsiveSize.subscribe((x) => {
            document.body.className = ResponsizeSize[x]
        })
    }

    // private detectDesktop() {
    //     this.breakPoint
    //     .observe([Breakpoints.Handset, Breakpoints.Tablet])
    //     .subscribe(result => {
    //         if (!result.matches) {
    //             console.log('its desktop')
    //             this.Desktop = true
    //         } 
    //         else {
    //             this.Desktop = false
    //         }
    //     })
    // }

    // private detectMobile() {
    //     this.breakPoint
    //     .observe(Breakpoints.Handset)
    //     .subscribe(result => {
    //         if (result.matches) {
    //             this.Mobile = true
    //         } 
    //         else {
    //             this.Mobile = false
    //         }
    //     })
    // }

    // private detectTablet() {
    //     this.breakPoint
    //     .observe(Breakpoints.Tablet)
    //     .subscribe(result => {
    //         if (result.matches) {
    //             this.Tablet = true
    //         } 
    //         else {
    //             this.Tablet = false
    //         }
    //     })
    // }
}