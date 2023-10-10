import { Component, EventEmitter, Input, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserSimpleDto } from 'src/app/data/types/user/user-simple-dto';

@Component({
  selector: 'app-user-field',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './user-field.component.html',
  styleUrls: ['./user-field.component.scss']
})
export class UserFieldComponent {
  @Input() userInputList: Array<UserSimpleDto> = []
  @Output() updateSelectedUser = new EventEmitter<number>
  clickToUpdateUser(userId: number){
    this.updateSelectedUser.emit(userId)
  }
}
