import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { QuarableUserListComponent } from '../components/quarable-user-list/quarable-user-list.component';

@Component({
  selector: 'app-manage-user',
  standalone: true,
  imports: [CommonModule, QuarableUserListComponent],
  templateUrl: './manage-user.component.html',
  styleUrls: ['./manage-user.component.scss']
})
export class ManageUserComponent {

}
