export interface Menu{
    mainPageLabel?:string;
    route?:string;
    subMenu?:Array<SubMenu>;
    icon?:string;
}

export interface SubMenu{
    subPagelabel?:string;
    route?:string;
    icon?: string;
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

export const Company: Menu = {
    mainPageLabel:'Companies',
    route:'Company',
    icon: 'fa-solid fa-building',
    subMenu: []
}


export const Home: Menu = {
    mainPageLabel: 'Home',
    route:'/Home',
    icon:'fa fa-house',
    subMenu:[]
}


export const menu: Array<Menu> = [
    Home,
    Test,
    Company,
]
