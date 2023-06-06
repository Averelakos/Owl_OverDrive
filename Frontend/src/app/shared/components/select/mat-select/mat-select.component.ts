import { Component, EventEmitter, Input, Output, forwardRef } from '@angular/core';
import { ControlValueAccessor, FormControl, FormGroup, NG_VALUE_ACCESSOR } from '@angular/forms';


@Component({
  selector: 'app-mat-select',
  templateUrl: './mat-select.component.html',
  styleUrls: ['./mat-select.component.scss'],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(
        () => MatSelectComponent
      ),
      multi: true
    }
  ]
})
export class MatSelectComponent implements ControlValueAccessor{

  @Input() parentForm: FormGroup;
  @Input() fieldName: string;
  @Input() label: string;
  @Input() type: string;
  @Input() optionsList: Array<any>;
  @Output() onValueChange : EventEmitter<any> = new EventEmitter<any>();

  public value: any = null ;
  public changed: (value: any) => void;
  public onTouched: () => void;
  public isDisabled: boolean;
  listIsOpen: boolean = false;


  
  openOptionsList() {
    this.listIsOpen = true;
  }

  closeOptionList() {
    this.listIsOpen = false;
  }

  public setOptionValue(value:any):void {
    this.value = value;
    this.formField.setValue(this.value);
    this.listIsOpen = false;
    this.onValueChange.emit(value)
  }

  // public onChanged(event: Event): void {
  //   const value: any = (<HTMLLIElement>event.target).value
  //   this.changed(value);
  //   this.value = value
  //   this.openOptionsList();
  // }



  get formField (): FormControl {
    return this.parentForm?.get(this.fieldName) as FormControl;
  }



  //#region ControlValueAccessor

  /**
   * This Method fires every time 
   * our value changes
   * @param obj 
   */
  public writeValue(value: any): void {
    this.value = value;
  }

  /**
   * This method return a function 
   * every time it detect a change
   * @param fn 
   */
  public registerOnChange(fn: any): void {
    this.changed = fn;
  }

  /**
   * This is for focus or when our input is
   * touched
   * @param fn 
   */
  public registerOnTouched(fn: any): void {
    this.onTouched = fn;
  }

  /**
   * This is to dissable our component
   * when the form control is dissabled
   * or when the input is dissabled
   * @param isDisabled 
   */
  public setDisabledState?(isDisabled: boolean): void {
    this.isDisabled = isDisabled;
  }

  //#endregion ControlValueAccessor

}
