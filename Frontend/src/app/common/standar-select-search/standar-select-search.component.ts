import { CommonModule } from '@angular/common';
import { ChangeDetectionStrategy, Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormGroup, FormGroupDirective, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Subscription } from 'rxjs';
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
  
})
export class StandarSelectSearchComponent implements  OnInit {


  @Input() label:string = ''
  @Input() controlName = ''
  @Input() subGroup: string = ''
  formGroup!: FormGroup
  @Input() type: string = 'text'
  @Input() fieldName: string
  @Input() listOfInputValues: Array<SelectSearchInputValue> = []
  @Input() apiSearchEnable: boolean = false
  @Output() searchInput = new EventEmitter<string>()

  inputValue: string | null = null;
  selectIsFocused: boolean = false;
  filteredInputValues: Array<SelectSearchInputValue> = []
  openSelectField:boolean = false;
  searchValue:string = ''
  noResults: boolean = false
  loader: boolean = false
  private unsubscribe: Subscription | undefined

  constructor(public parentForm: FormGroupDirective){
    // this.filteredInputValues = this.listOfInputValues
  }

  ngOnInit(): void {
    this.filteredInputValues = this.listOfInputValues
    if (this.subGroup === ''){
      this.formGroup = this.parentForm.form 
    }
    else {
      // this.formGroup = this.parentForm.form.controls[this.subGroup] as FormGroup
      this.formGroup = this.parentForm.control.get(this.subGroup) as FormGroup
    }

   this.unsubscribe =  this.formGroup.get(this.controlName)?.valueChanges.subscribe((b) => {
      if (this.inputValue === null && b != null && this.inputValue !== b) {
        this.clickSelectOption(this.formGroup.get(this.controlName)?.value)
      }
    })
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
    this.unsubscribe?.unsubscribe()
    this.formGroup.get(this.controlName)?.setValue(selected[0].id)
    this.inputValue = selected[0].value
    this.openSelectField = false
    this.selectIsFocused = false
  }

  clickToRemoveSelectedOption(){
    this.inputValue = null
    this.formGroup.get(this.controlName)?.setValue(null)
  }

  clickOutSide(){
    this.openSelectField = false
    this.selectIsFocused = false
    this.loader = false
    this.noResults = false
    // let inputValue = (<HTMLInputElement>document.getElementById('inputSearchOption'));
    // this.filteredInputValues = this.listOfInputValues
    // if (inputValue != null) {
    //   inputValue.value = ''
    // }
  }

  inputSearchOptions(event: any){
    const searchInput = event.target.value
    if (this.apiSearchEnable) {
      this.searchInput.emit(searchInput)
      if (searchInput.length > 0){
        this.loader = true
        setTimeout(()=>{
            this.loader = false
            this.noResults = true
        }, 3000);

      }
      else {
        this.noResults = false
        this.loader = false
      }
    } else {
      this.filteredInputValues = this.listOfInputValues
    .map((option) => option)
    .filter( (x) => x.value.toLowerCase().includes(searchInput.toLowerCase()))
    }
  }
}
