import { Injectable } from "@angular/core";
import { Subject } from "rxjs";

@Injectable({
    providedIn:'root'
})
export class LayoutService {
   public sidebarMenuTrigger = new Subject<boolean>()
   constructor() {} 
}