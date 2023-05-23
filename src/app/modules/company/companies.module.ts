import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AddEditCompanyComponent } from "./add-edit/container/add-edit-company.component";
import { StandarInputComponent } from "src/app/common/standar-input/standar-input.component";
import { StandarTextareaComponent } from "src/app/common/standar-textarea/standar-textarea.component";
import { CompanyGeneralDetailsComponent } from './add-edit/components/company-general-details/company-general-details.component';
import { StandarSelectSearchComponent } from "src/app/common/standar-select-search/standar-select-search.component";
import { StandarDatetimePickerComponent } from "src/app/common/standar-datetimepicker/standar-datetimepicker.component";
// 

const routes: Routes = [
    {path:'', component:AddEditCompanyComponent},
]

@NgModule({
    imports:[
        RouterModule.forChild(routes),
        StandarInputComponent,
        StandarTextareaComponent,
        StandarSelectSearchComponent,
        StandarDatetimePickerComponent
    ],
    providers:[],
    declarations:[

  
    AddEditCompanyComponent,
        CompanyGeneralDetailsComponent
  ],
    exports:[
        RouterModule,
        AddEditCompanyComponent
    ]
})
export class CompanyModule{}