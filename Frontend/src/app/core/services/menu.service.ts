import { Injectable } from "@angular/core";
import { Menu } from "../models/menu";


@Injectable({
    providedIn: 'root'
})
export class MenuService{
    menuItem: Array<Menu>;

    constructor(){
        this.menuItem = [];
    }

    /**
     * Load the menu items for the 
     * sidebar menu 
     * @param items menu items 
     */
    addMenu(items: Array<Menu>) {
        items.forEach((item) => {
            this.menuItem.push(item);
        });
    }

    /**
     * Get the menu to load to the sidebar
     * @returns Array<MenuModel>
     */
    getMenu() {
        return this.menuItem;
    }
}