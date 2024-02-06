import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/Shared/auth.service';
import { LoginModel } from 'src/app/Shared/login.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  credentials: LoginModel = {
    email: '',
    password: '',
    isLoggedIn: false
  };

  //set loginError = false by default
  loginError = false;

  //set loginErrorMessage empty for initial
  loginErrorMessage = '';

  constructor(private authService: AuthService,
              private router: Router) { }

  ngOnInit(): void {
  }

  login(){
    this.authService.login(this.credentials).subscribe(
      (response) => {
        this.authService.setLoggedIn(true);
        this.router.navigate(['/login']);
        this.loginError = false;
      },
      (error) =>{
        console.log('Login failed:', error);
        this.loginError = true;
        this.loginErrorMessage = error.error.Error || 'Username or password is incorrect';
      }
    );
  }


}
