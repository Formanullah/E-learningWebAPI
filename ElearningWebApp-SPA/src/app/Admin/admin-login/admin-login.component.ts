import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-admin-login',
  templateUrl: './admin-login.component.html',
  styleUrls: ['./admin-login.component.css']
})
export class AdminLoginComponent implements OnInit {
  model: any = {};

  constructor(private auth: AuthService, private router: Router, private alertify: AlertifyService) { }

  ngOnInit(): void {
    this.loggedIn();
  }

  login(): void {
    console.log(this.model);
    this.auth.adminLogIn(this.model).subscribe( res => {
      this.alertify.success('Login successfully');
    }, error => {
      this.alertify.error(error);
    });
  }


  loggedIn(): void {
    if (this.auth.adminLoggedIn()) {
      this.router.navigate(['Admin/dashboard']);
     }
  }

}
