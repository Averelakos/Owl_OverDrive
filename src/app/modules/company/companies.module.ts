import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AddEditCompanyComponent } from './add-edit/add-edit-company.component';


const routes: Routes = [
    {path:'', component:AddEditCompanyComponent},
]

@NgModule({
    imports:[
        RouterModule.forChild(routes)
    ],
    providers:[],
    declarations:[

  
    AddEditCompanyComponent
  ],
    exports:[
        RouterModule,
        AddEditCompanyComponent
    ]
})
export class CompanyModule{}