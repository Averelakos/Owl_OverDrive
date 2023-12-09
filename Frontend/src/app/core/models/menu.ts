import { EPermission } from "../enums/enum-permissions";

export interface Menu{
    mainPageLabel?:string;
    route?:string;
    subMenu?:Array<SubMenu>;
    icon?:string;
    permision?: EPermission 
}

export interface SubMenu{
    subPagelabel?:string;
    route?:string;
    icon?: string;
    permision?: EPermission  
}



export const Test: Menu = {
    mainPageLabel:'Developement',
    route:'Test',
    icon: 'fa-solid fa-vial',
    subMenu: [
        {
            subPagelabel:'Test Area',
            route:'/Test/testarea',
            icon: 'fa-solid fa-vial',
        },
        {
            subPagelabel:'Playground',
            route:'/Test/playground',
            icon: 'fa-light fa-vials',
        }
    ]
}

export const xesou: Menu = {
    mainPageLabel:'Developement2',
    route:'Xesou',
    icon: 'fa-solid fa-vial',
    subMenu: [
        {
            subPagelabel:'Test Area2',
            icon: 'fa-solid fa-vial',
        },
        {
            subPagelabel:'Playground2',
            icon: 'fa-light fa-vials',
        }
    ]
}

export const Company: Menu = {
    mainPageLabel:'Companies',
    route:'Company',
    icon: 'fa-solid fa-building',
    permision: EPermission.Display_Company,
    subMenu: []
}


export const Home: Menu = {
    mainPageLabel: 'Home',
    route:'/Home',
    icon:'fa fa-house',
    subMenu:[]
}

export const Game: Menu = {
    mainPageLabel: 'Game',
    route:'/Game',
    icon:'fa-solid fa-ghost',
    permision: EPermission.Display_Game,
    subMenu:[]
}

export const ManageUser: Menu = {
    mainPageLabel:'Manage Users',
    route:'User',
    icon: 'fa-solid fa-user',
    permision: EPermission.Display_User,
    subMenu: []
}


export const menu: Array<Menu> = [
    // Home,
    Game,
    Company,
    // Test,
    ManageUser
]
