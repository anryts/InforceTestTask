import { Component } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  username: string = '';
  password: string = '';
  error: string = '';

  constructor(private authService: AuthService, private router: Router) {}

  login() {
    this.authService.login(this.username, this.password)
      .subscribe(
        data => {
          this.router.navigate(['/albums']);
        },
        error => {
          this.error = 'Username or password is incorrect';
        }
      );
  }

  closeLoginForm() {
    this.router.navigate(['/']); // Navigate to the home page or another route
  }
}
