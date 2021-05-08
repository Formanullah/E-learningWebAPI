import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  constructor(private authService: AuthService, private routes: Router) { }

  ngOnInit(): void {
  }

  // tslint:disable-next-line:typedef
  loggedIn() {
    return this.authService.loggedIn();
   }

   logout(): void {
     localStorage.removeItem('user');
     localStorage.removeItem('token');
     this.routes.navigate(['/home']);
   }


}
