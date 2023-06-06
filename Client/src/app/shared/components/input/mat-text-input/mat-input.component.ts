import { Component, forwardRef, Input, OnChanges, SimpleChanges } from '@angular/core';
import { ControlValueAccessor, FormControl, FormGroup, NG_VALUE_ACCESSOR } from '@angular/forms';

@Component({
  selector: 'app-mat-input',
  templateUrl: './mat-input.component.html',
  styleUrls: ['./mat-input.component.scss'],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(
        () => MatInputComponent
      ),
      multi: true
    }
  ]
})
export class MatInputComponent implements ControlValueAccessor {
  
  @Input() parentForm: FormGroup;
  @Input() fieldName: string;
  @Input() label: string;
  @Input() type: string;

  public value: string | number | boolean;
  public changed: (value: any) => void;
  public onTouched: () => void;
  public isDisabled: boolean;

  constructor() {}

  test() {
    console.log('test2')
  }

  public onChanged(event: Event): void {
    const value: any = (<HTMLInputElement>event.target).value;
    console.log(this.changed)
    this.changed(value);
  }

  get formField (): FormControl {
    return this.parentForm?.get(this.fieldName) as FormControl;
  }


  /**
   * Check if the input value is empty or not
   * and check based the type of input is register
   * in the component
   * @returns boolean
   */
  isValueEmpty(): boolean {

    if (typeof this.formField.value === "string") {
      return this.formField.value !==null && this.formField.value.length !== 0;
    } 
    else if (typeof this.formField.value === "number") {
      return this.formField.value !==null && this.formField.value !== undefined 
    }
    else if (typeof this.formField.value === "boolean") {
      return this.formField.value !==null && this.formField.value !== undefined 
    } 
    else {
      return false;
    }

  }

  /**
   * Check if the input is
   * valid
   * @returns boolean
   */
  isFieldInValid() {
    return this.formField.invalid && this.formField.touched && this.isValueEmpty();
  }

  /**
   * Check if the input is invalid
   * @returns boolean
   */
  isFieldValid() {
    return this.formField.valid;
  }


  displayFieldCss() {
    return {
      'has-error': this.isFieldInValid(),
      'has-feedback': this.isFieldInValid(),
      'valid-input': this.isFieldValid()
    };
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
