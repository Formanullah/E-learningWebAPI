import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-admin-register',
  templateUrl: './admin-register.component.html',
  styleUrls: ['./admin-register.component.css']
})
export class AdminRegisterComponent implements OnInit {
  admin: any = {};

  constructor(private auth: AuthService, private router: Router, private alertify: AlertifyService) { }

  ngOnInit(): void {
  }

  register(): void {
    this.auth.adminRegister(this.admin).subscribe( res => {
      this.alertify.success('Admin Registration Successfull');
    }, error => { this.alertify.error('Registration Failed'); },
    () => {
      this.auth.adminLogIn(this.admin).subscribe(res => {
        this.alertify.success('Login successfully');
      }, error => {
        this.alertify.error(error);
      });
    });
  }

}
