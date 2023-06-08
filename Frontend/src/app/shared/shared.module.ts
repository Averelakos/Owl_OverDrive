import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { ClickOutsideDirective } from "./directives/outside.directive";
import { MatInputComponent } from './components/input/mat-text-input/mat-input.component';
import { MatFieldErrorsComponent } from './components/form-elements/mat-field-errors/mat-field-errors.component';
// import { OnValueChangeDirective } from "./directives/onValueChange.directive";
import { MatSelectComponent } from './components/select/mat-select/mat-select.component';
import { MatDatetimePickerComponent } from './components/mat-datetime-picker/mat-datetime-picker.component';
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
        MatInputComponent,
        MatFieldErrorsComponent,
        // OnValueChangeDirective,
        MatSelectComponent,
    ],
    exports:[
        ClickOutsideDirective,
        MatInputComponent,
        MatSelectComponent,
        
        // OnValueChangeDirective
    ]
    
  })
  export class SharedComponentsModule { }