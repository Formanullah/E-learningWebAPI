import { Injectable } from '@angular/core';
import {CanActivate, Router } from '@angular/router';
import { AlertifyService } from '../_services/alertify.service';
import { AuthService } from '../_services/auth.service';
/* import { AlertifyService } from '../_services/alertify.service'; */

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private authService: AuthService, private routes: Router,
              private alertify: AlertifyService) {}

  canActivate(): boolean {
    if (this.authService.loggedIn()) {
      return true;
    }
    if (this.authService.adminLoggedIn()) {
      return true;
    }

    this.alertify.error('you shall not pass!!!');
    this.routes.navigate(['/home']);
    return false;
  }
}
