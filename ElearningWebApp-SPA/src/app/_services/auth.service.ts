import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Class } from '../_models/class';
import { Register } from '../_models/register';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  baseUrl = environment.apiUrl;

constructor(private http: HttpClient, private router: Router) { }

getClasses(): Observable<Class[]> {
  return this.http.get<Class[]>(this.baseUrl + 'Admin/GetAllClass');
}
// tslint:disable-next-line:typedef
userRegister(user: Register) {
  return this.http.post(this.baseUrl + 'Auth/register', user);
}

// tslint:disable-next-line:typedef
login(model: any) {

  return this.http.post(this.baseUrl + 'Auth/Login', model)
  .pipe(
    map((response: any) => {
      const user = response;
      if (user) {
        localStorage.setItem('user', JSON.stringify(user.user));
        localStorage.setItem('token', JSON.stringify(user.token));

        if (user.user.roleName === 'Student') {
          this.router.navigate(['/subjects/', user.user.classId]);
        }
        /* this.decodedToken = this.jwtHelper.decodeToken(user.token);
        this.currentUser = user.user;
        this.changeMemberPhoto(this.currentUser.photoUrl); */
      }
    })
  );
}

loggedIn(): boolean {
  const token = localStorage.getItem('user');

  if (token !== null && JSON.parse(token).roleName === 'Student') {
    return true;
  }
  return false;
}


// tslint:disable-next-line:typedef
adminRegister(model: any) {
  return this.http.post(this.baseUrl + 'Auth/AddAdmin', model);
}

// tslint:disable-next-line:typedef
adminLogIn(model: any) {

  return this.http.post(this.baseUrl + 'Auth/AdminLogin', model)
  .pipe(
    map((response: any) => {
      const user = response;
      console.log(response);
      if (user) {
        localStorage.setItem('user', JSON.stringify(user.user));
        localStorage.setItem('token', JSON.stringify(user.token));

        if (user.user.roleName === 'Admin') {
          this.router.navigate(['Admin/dashboard']);
        }
        /* this.decodedToken = this.jwtHelper.decodeToken(user.token);
        this.currentUser = user.user;
        this.changeMemberPhoto(this.currentUser.photoUrl); */
      }
    })
  );
}

adminLoggedIn(): boolean {
  const token = localStorage.getItem('user');
  if (token !== null && JSON.parse(token).roleName === 'Admin') {
    return true;
  }
  return false;
}

}
