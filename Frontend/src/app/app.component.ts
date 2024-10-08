import { Component } from '@angular/core';
import { AuthService } from './core/auth/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Owl_Overdrive_UI';

  constructor(private readonly authService: AuthService){
    this.authService.checkToken()
  }
}
