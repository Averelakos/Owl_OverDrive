import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { CheckMarkCheckBoxButtonComponent } from 'src/app/common/checkboxes-buttons/check-mark-checkbox-button/check-mark-checkbox-button.component';
import { ERole } from 'src/app/core/enums/enum-role';
import { UserService } from 'src/app/data/services/user.service';
import { UserSimpleDto } from 'src/app/data/types/user/user-simple-dto';
import { SpinnerLoaderComponent } from 'src/app/common/loaders/spinner-loader/spinner-loader';
import { BehaviorSubject, finalize, first } from 'rxjs';

@Component({
  selector: 'app-update-user',
  standalone: true,
  imports: [CommonModule, RouterModule, CheckMarkCheckBoxButtonComponent, SpinnerLoaderComponent],
  templateUrl: './update-user.component.html',
  styleUrls: ['./update-user.component.scss']
})
export class UpdateUserComponent {
  roles = ERole
  adminCheck: boolean = false
  agentCheck: boolean = false
  reviewerCheck: boolean = false
  defaultCheck: boolean = false
  loading$ = new BehaviorSubject<boolean>(false)
  user:UserSimpleDto
  constructor(private readonly route: ActivatedRoute, private readonly userService: UserService){
    const userId = this.route.snapshot.params['id']
    this.getUserInfo(userId)
  }

  getUserInfo(userId){
    this.loading$.next(true)
    this.userService
    .getUser(userId)
    .pipe(first(),finalize(()=> this.loading$.next(false)))
    .subscribe((res) => {
      this.user = res
      if(res.roleId === 1)
        this.adminCheck = true
      else if(res.roleId === 2)
        this.agentCheck = true
      else if(res.roleId === 3)
        this.reviewerCheck = true
      else if(res.roleId === 4)
        this.defaultCheck = true
    })
  }

  updateUserRole() {
    this.loading$.next(true)
    
    if(this.adminCheck === true)
        this.user.roleId = 1
    else if(this.agentCheck === true)
        this.user.roleId = 2
    else if(this.reviewerCheck === true)
        this.user.roleId = 3
    else if(this.defaultCheck === true)
        this.user.roleId = 4
    
    this.userService
    .updateUserRole(this.user)
    .pipe(first(),finalize(()=> this.loading$.next(false)))
    .subscribe((res) => {
      this.user = res
  })
  }

  checkedRole(role: any) {
    switch(role){
      case ERole.Administrator:
        this.resetAllChecks() 
        this.adminCheck = true
        break
      case ERole.Agent:
        this.resetAllChecks() 
        this.agentCheck = true
        break
      case ERole.Reviewer:
        this.resetAllChecks() 
        this.reviewerCheck = true
        break
      case ERole.Default:
        this.resetAllChecks() 
        this.defaultCheck = true
        break
    }
  }
  resetAllChecks() {
    this.adminCheck = false
    this.agentCheck = false
    this.reviewerCheck = false
    this.defaultCheck = false
  }
}
