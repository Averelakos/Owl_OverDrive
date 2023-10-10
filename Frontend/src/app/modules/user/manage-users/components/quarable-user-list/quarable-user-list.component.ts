import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TabComponent, TabsComponent } from 'src/app/common/tabs/tabs';
import { UserService } from 'src/app/data/services/user.service';
import { FilterTabsComponent } from 'src/app/common/tabs/filter-tabs';
import { ERole } from 'src/app/core/enums/enum-role';
import { UserFieldComponent } from '../user-field/user-field.component';
import { UserPaginationComponent } from './components/user-pagination/user-pagination.component';
import { LogoLoader } from 'src/app/common/loaders/logo-loader/logo-loader';
import { DataLoaderOptions } from 'src/app/data/types/data-loader/data-loader-options';
import { RequestGetUserByRole } from 'src/app/data/types/user/request-get-user-by-role';
import { UserSimpleDto } from 'src/app/data/types/user/user-simple-dto';
import { Router } from '@angular/router';

@Component({
  selector: 'app-quarable-user-list',
  standalone: true,
  imports: [CommonModule, TabsComponent, TabComponent, FilterTabsComponent, UserFieldComponent, UserPaginationComponent, LogoLoader],
  templateUrl: './quarable-user-list.component.html',
  styleUrls: ['./quarable-user-list.component.scss']
})
export class QuarableUserListComponent {
  filterTabs: Array<string> = []
  options: DataLoaderOptions
  userList: Array<UserSimpleDto> = []
  pageSize: number = 20
  totalPages: number
  currentPage: number = 1
  selectedRole = ERole.Administrator
  constructor(private readonly userService: UserService, private router: Router){
    this.options = {
      take: this.pageSize,
      skip: 0,
      searchString:null
     }
    this.fetch()
    this.filterTabs.push(ERole[ERole.Administrator])
    this.filterTabs.push(ERole[ERole.Agent])
    this.filterTabs.push(ERole[ERole.Reviewer])
    this.filterTabs.push(ERole[ERole.Default])
  }

  fetch= () => {
    let model: RequestGetUserByRole = {
      role: this.selectedRole,
      options: this.options
    }
    this.userService.getAllUsersWithRoles(model).subscribe((res) => {
      this.userList = res.result!
      console.log(this.userList)
      this.totalPages = res.totalPages
    })
  }

  resetOptions() {
    this.options.skip = 0
  }

  tabChange(selectedTab: string){
    switch(selectedTab) {
      case ERole[ERole.Administrator]:
            this.selectedRole = ERole.Administrator
            this.resetOptions()
            this.fetch()
            break
          case ERole[ERole.Agent]:
            this.selectedRole = ERole.Agent
            this.resetOptions()
            this.fetch()
            break
          case ERole[ERole.Reviewer]:
            this.selectedRole = ERole.Reviewer
            this.resetOptions()
            this.fetch()
            break
          case ERole[ERole.Default]:
            this.selectedRole = ERole.Default
            this.resetOptions()
            this.fetch()
            break
    }
  }

  changePage(event: any) {
    this.options.skip = this.pageSize * (event - 1)
    this.currentPage = event
    this.fetch()
  }

  updateSelectedUser(event){
    this.router.navigate(['User/edit/' + event, {id:event} ])
  }
}
