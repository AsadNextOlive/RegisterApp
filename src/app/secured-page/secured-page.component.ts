import { Component, OnInit } from '@angular/core';
import { AuthService } from '../Shared/auth.service';
import { Router } from '@angular/router';
import { Location } from '@angular/common';

@Component({
  selector: 'app-secured-page',
  templateUrl: './secured-page.component.html',
  styleUrls: ['./secured-page.component.css']
})
export class SecuredPageComponent implements OnInit {

  constructor(private authService: AuthService,
              private router: Router,
              private location: Location) { }

  ngOnInit(): void {
  }

  signOut(){
    this.authService.setLoggedIn(false);
    this.location.replaceState('/register-list');
    this.router.navigate(['/register-list']);
    console.log(this.authService.isLoggedIn());
    
  }

}
