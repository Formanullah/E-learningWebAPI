import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Class } from '../_models/class';
import { Register } from '../_models/register';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  baseUrl = environment.apiUrl;

constructor(private http: HttpClient) { }

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
/*   .pipe(
    map((response: any) => {
      const user = response;
      if (user) {
        localStorage.setItem('token', user.accessToken);
        localStorage.setItem('user', JSON.stringify(user));
        localStorage.setItem('identity', user.identity);

        if(user.identity === 'vendor') {
          this.router.navigate(['/Seller/dashboard']);
        }
        this.decodedToken = this.jwtHelper.decodeToken(user.token);
        this.currentUser = user.user;
        this.changeMemberPhoto(this.currentUser.photoUrl);
      }
    })
  ) */;
}



}
