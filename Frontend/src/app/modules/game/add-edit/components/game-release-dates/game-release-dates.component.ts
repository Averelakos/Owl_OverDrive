import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormArray, FormBuilder, FormGroup, FormGroupDirective, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PlatformReleaseComponent } from './components/platform-release/platform-release.component';

@Component({
  selector: 'app-game-release-dates',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule, PlatformReleaseComponent],
  templateUrl: './game-release-dates.component.html',
  styleUrls: ['./game-release-dates.component.scss']
})
export class GameReleaseDatesComponent {
  constructor(private readonly formBuilder: FormBuilder, public parentForm: FormGroupDirective){}

  releaseDates() : FormArray {
    return this.parentForm.control.get('releaseDates') as FormArray
  }

  releaseDate(): FormGroup {
    return this.formBuilder.group({
      platform:[null],
      releases: this.formBuilder.array([])
    })
  }

  addNewIndex() {
    this.releaseDates().push(this.releaseDate())
  }

  removeIndex(index: number) {
    this.releaseDates().removeAt(index)
  }
}
