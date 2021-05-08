import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css'
]})
export class AdminComponent implements OnInit {

  constructor( private routes: Router, private auth: AuthService) { }

  ngOnInit(): void {
    this.loggedIn();
  }

  logout(): void {
    localStorage.removeItem('user');
    localStorage.removeItem('token');
    this.routes.navigate(['/home']);
  }

  loggedIn(): void {
    if (!this.auth.adminLoggedIn()) {
      this.routes.navigate(['/home']);
     }
  }

}
