import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LocalizationPanelComponent } from './components/localization-panel/localization-panel.component';
import { FormArray, FormBuilder, FormGroup, FormGroupDirective, FormsModule, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-localization',
  standalone: true,
  imports: [CommonModule, LocalizationPanelComponent, FormsModule, ReactiveFormsModule],
  templateUrl: './localization.component.html',
  styleUrls: ['./localization.component.scss']
})
export class LocalizationComponent {

  constructor(private readonly formBuilder: FormBuilder, public parentForm: FormGroupDirective ){
    this.addNewLocalization()
  }

  localizations() : FormArray {
    return this.parentForm.form.controls['localization'] as FormArray
  }

  newLocalization(): FormGroup {
    return this.formBuilder.group({
      region: [null],
      localizedTitle: [null]
    })
  }

  addNewLocalization() {
    this.localizations().push(this.newLocalization())
  }

  removeIndex(index: number) {
    this.localizations().removeAt(index)
  }
}
