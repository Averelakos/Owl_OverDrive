import { Injectable } from "@angular/core";
import { BehaviorSubject, Subject } from "rxjs";

@Injectable({
    providedIn:'root'
})
export class LayoutService {
   public sidebarMenuTrigger = new Subject<boolean>()
   public sidebarMobileMenuTrigger = new BehaviorSubject<boolean>(false)
   constructor() {} 

}