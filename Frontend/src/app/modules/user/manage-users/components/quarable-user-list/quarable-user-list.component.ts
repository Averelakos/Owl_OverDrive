import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TabComponent, TabsComponent } from 'src/app/common/tabs/tabs';
import { UserService } from 'src/app/data/services/user.service';

@Component({
  selector: 'app-quarable-user-list',
  standalone: true,
  imports: [CommonModule, TabsComponent, TabComponent],
  templateUrl: './quarable-user-list.component.html',
  styleUrls: ['./quarable-user-list.component.scss']
})
export class QuarableUserListComponent {
  constructor(private readonly userService: UserService){
    this.fetch()
  }

  fetch= () => {
    this.userService.getAllUsersWithRoles().subscribe((res) => console.log(res))
  }
}
