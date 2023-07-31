import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormArray, FormBuilder, FormGroup, FormGroupDirective, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MultiplayerModePanelComponent } from './components/multiplayer-mode-panel/multiplayer-mode-panel.component';

@Component({
  selector: 'app-multiplayer-mode',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule, MultiplayerModePanelComponent],
  templateUrl: './multiplayer-mode.component.html',
  styleUrls: ['./multiplayer-mode.component.scss']
})
export class MultiplayerModeComponent {
  constructor(private readonly formBuilder: FormBuilder, public parentForm: FormGroupDirective){}

  multiplayerModes() : FormArray {
    return this.categorization().get('multiplayerModes') as FormArray
  }

  categorization() {
    return this.parentForm.control.get('categorization') as FormGroup
  }

  multiplayerMode(): FormGroup {
    return this.formBuilder.group({
      platform:[null],
      onlineCoOpMax:[null],
      offlineCoOpMax:[null],
      onlineMax:[null],
      offlineMax:[null],
      onlineCoOp:[false],
      offlineCoOp:[false],
      lanCoOp:[false],
      coOpCampaign:[false],
      onlineSplitScreen:[false],
      offlineSpliteScreen:[false],
      dropInOut:[false]
    })
  }

  addNewIndex() {
    this.multiplayerModes().push(this.multiplayerMode())
  }

  removeIndex(index: number) {
    this.multiplayerModes().removeAt(index)
  }
}
