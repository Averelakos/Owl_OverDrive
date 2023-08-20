import { Component, Input, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormGroup, FormGroupDirective, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Subscription } from 'rxjs';
import { SharedComponentsModule } from 'src/app/shared/shared.module';

export interface DropDownOption {
  id: number
  value: string
}

@Component({
  selector: 'app-standar-dropdown-menu',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, FormsModule, SharedComponentsModule],
  templateUrl: './standar-dropdown-menu.component.html',
  styleUrls: ['./standar-dropdown-menu.component.scss']
})
export class StandarDropdownMenuComponent implements OnInit{

  @Input() label:string = ''
  @Input() controlName = ''
  @Input() subGroup: string = ''
  @Input() options: Array<DropDownOption> = []
  inputValue!: DropDownOption | undefined
  selectedOption!:number
  openMenu: boolean = false
  rotateIcon: boolean = false
  private unsubscribe: Subscription | undefined
  formGroup!: FormGroup

  constructor(public parentForm: FormGroupDirective){}
  
  ngOnInit(): void {
    this.formGroup = this.parentForm.control.get(this.subGroup) as FormGroup

    this.unsubscribe =  this.formGroup.get(this.controlName)?.valueChanges.subscribe((b) => {
      if (this.inputValue === null && b != null && this.inputValue !== b) {
        // this.clickSelectOption(this.formGroup.get(this.controlName)?.value)
      }
    })
  }

  setOption(option: DropDownOption) {
    this.inputValue = option
    this.formGroup.get(this.controlName)?.setValue(option.id)
    this.openMenu = false
    this.rotateIcon = false
  }

  removeValue() {
    this.inputValue = undefined
    this.formGroup.get(this.controlName)?.setValue(null)
  }

  clickToOpenDropDownMenu(){
    this.openMenu = true
    this.rotateIcon = true
  }

  clickOutside() {
    this.openMenu = false
    this.rotateIcon = false
  }
}
