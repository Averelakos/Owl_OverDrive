import { CommonModule } from '@angular/common';
import { Component, Input, forwardRef } from '@angular/core';
import { ControlValueAccessor, FormControl, FormGroup, NG_VALUE_ACCESSOR } from '@angular/forms';
import { SharedComponentsModule } from 'src/app/shared/shared.module';

export interface SelectSearchInputValue {
  id: number
  value: string
  isVisible: boolean
}

@Component({
  selector: 'app-standar-select-search',
  standalone: true,
  imports:[CommonModule, SharedComponentsModule],
  templateUrl: './standar-select-search.component.html',
  styleUrls: ['./standar-select-search.component.scss'],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(
        () => StandarSelectSearchComponent
      ),
      multi: true
    }
  ]
})
export class StandarSelectSearchComponent implements ControlValueAccessor {

  public value: string | number
  public changed: (value: any) => void
  public onTouched: () => void
  public isDisabled: boolean

  @Input() parentForm: FormGroup
  @Input() label: string
  @Input() type: string = 'text'
  @Input() fieldName: string
  @Input() listOfInputValues: Array<SelectSearchInputValue> = [
    {id:1,value:'Test',isVisible:true},
    {id:2,value:'Test2',isVisible:true},
    {id:3,value:'Test3',isVisible:true}
  ]

  inputValue: SelectSearchInputValue | null = null;
  selectIsFocused: boolean = false;
  filteredInputValues: Array<SelectSearchInputValue> = []
  openSelectField:boolean = false;
  searchValue:string = ''

  constructor(){
    this.filteredInputValues = this.listOfInputValues
  }

  // get formField (): FormControl {
  //   return this.parentForm?.get(this.fieldName) as FormControl;
  // }

  /**
   * This Method fires every time 
   * our value changes
   * @param value 
   */
  writeValue(value: any): void {
    this.value = value;
  }

  /**
   * This method return a function 
   * every time it detect a change
   * @param fn 
   */
  registerOnChange(fn: any): void {
    this.changed = fn;
  }

  /**
   * This is for focus or when our input is
   * touched
   * @param fn 
   */
  registerOnTouched(fn: any): void {
    this.onTouched = fn;
  }

  /**
   * This is to dissable our component
   * when the form control is dissabled
   * or when the input is dissabled
   * @param isDisabled 
   */
  setDisabledState?(isDisabled: boolean): void {
    this.isDisabled = isDisabled;
  }

  clickSelectSearchField(){
    this.openSelectField = !this.openSelectField
    this.selectIsFocused = true
  }

  clickSelectOption(selectedOption: number){
    const selected = this.listOfInputValues
    .map((option) => option)
    .filter((option) => option.id === selectedOption)
    
    if (selected != null && selected.length > 1){
      return
    }

    this.inputValue = selected[0]
  }

  clickToRemoveSelectedOption(){
    this.inputValue = null
  }

  clickOutSide(){
    this.openSelectField = false
    this.selectIsFocused = false
    let inputValue = (<HTMLInputElement>document.getElementById('inputSearchOption'));
    this.filteredInputValues = this.listOfInputValues
    if (inputValue != null) {
      inputValue.value = ''
    }
  }

  inputSearchOptions(event: any){
    const searchInput = event.target.value

    this.filteredInputValues = this.listOfInputValues
    .map((option) => option)
    .filter( (x) => x.value.toLowerCase().includes(searchInput.toLowerCase()))
  }
}
