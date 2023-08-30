import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormGroup, FormGroupDirective } from '@angular/forms';
import { StandarInputComponent } from 'src/app/common/standar-input/standar-input.component';
import { StandarTextareaComponent } from 'src/app/common/standar-textarea/standar-textarea.component';
import { ResponsiveService, ResponsizeSize } from 'src/app/core/services/responsive.service';
import { GameTypeComponent } from './components/game-type/game-type.component';
import { GameStatusComponent } from './components/game-status/game-status.component';
import { GameEditionComponent } from './components/game-edition/game-edition.component';

@Component({
  selector: 'app-general-info',
  standalone:true,
  imports:[CommonModule, StandarInputComponent, StandarTextareaComponent, GameTypeComponent, GameStatusComponent, GameEditionComponent],
  templateUrl: './general-info.component.html',
  styleUrls: ['./general-info.component.scss']
})
export class GeneralInfoComponent {
  imageB64?: string | null
  deviceType = ResponsizeSize
  formGroup!: FormGroup
  constructor(
    public responsiveService: ResponsiveService, 
    public parentForm: FormGroupDirective,){}
}
