import { CommonModule } from '@angular/common';
import { ChangeDetectionStrategy, Component, Input, OnInit, forwardRef } from '@angular/core';
import { ControlValueAccessor, FormControl, FormGroup, FormGroupDirective, FormsModule, NG_VALUE_ACCESSOR, ReactiveFormsModule } from '@angular/forms';
import { SharedComponentsModule } from 'src/app/shared/shared.module';

export interface SelectSearchInputValue {
  id: number
  value: string
}

@Component({
  selector: 'app-standar-select-search',
  standalone: true,
  imports:[CommonModule, SharedComponentsModule, ReactiveFormsModule, FormsModule],
  templateUrl: './standar-select-search.component.html',
  styleUrls: ['./standar-select-search.component.scss'],
  // changeDetection: ChangeDetectionStrategy.OnPush,
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
export class StandarSelectSearchComponent implements ControlValueAccessor, OnInit {

  public value: string | number
  public changed: (value: any) => void
  public onTouched: () => void
  public isDisabled: boolean

  @Input() label:string = ''
  @Input() controlName = ''
  @Input() subGroup: string = ''
  formGroup!: FormGroup
  @Input() type: string = 'text'
  @Input() fieldName: string
  @Input() listOfInputValues: Array<SelectSearchInputValue> = []
  // = [
  //   {id:1,value:'Test'},
  //   {id:2,value:'Test2'},
  //   {id:3,value:'Test3'}
  // ]

  inputValue: SelectSearchInputValue | null = null;
  selectIsFocused: boolean = false;
  filteredInputValues: Array<SelectSearchInputValue> = []
  openSelectField:boolean = false;
  searchValue:string = ''

  constructor(public parentForm: FormGroupDirective){
    // this.filteredInputValues = this.listOfInputValues
    // console.log(this.filteredInputValues)
  }

  ngOnInit(): void {
    this.filteredInputValues = this.listOfInputValues
    if (this.subGroup === ''){
      this.formGroup = this.parentForm.form 
    }
    else {
      this.formGroup = this.parentForm.form.controls[this.subGroup] as FormGroup
    }
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
    this.formGroup.get(this.controlName)?.setValue(selected[0].id)
    this.inputValue = selected[0]
  }

  clickToRemoveSelectedOption(){
    this.inputValue = null
    this.formGroup.get(this.controlName)?.setValue(null)
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
