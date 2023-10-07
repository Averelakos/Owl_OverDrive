import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { ClickOutsideDirective } from "./directives/outside.directive";
import { MatSelectComponent } from './components/select/mat-select/mat-select.component';
import {MatDatepickerModule} from '@angular/material/datepicker';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { MatNativeDateModule } from "@angular/material/core";
import { MatFormFieldModule } from "@angular/material/form-field";




@NgModule({
    imports:[
        CommonModule,
        MatFormFieldModule,
        MatDatepickerModule,
        MatNativeDateModule,
        FormsModule,
        ReactiveFormsModule,
    ],
    providers:[],
    declarations:[
        ClickOutsideDirective,
        MatSelectComponent,
    ],
    exports:[
        ClickOutsideDirective,
        MatSelectComponent,
    ]
    
  })
  export class SharedComponentsModule { }