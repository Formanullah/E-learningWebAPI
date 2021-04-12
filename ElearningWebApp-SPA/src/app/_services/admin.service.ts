import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Class } from '../_models/class';

@Injectable({
  providedIn: 'root'
})
export class AdminService {
  baseUrl = environment.apiUrl + 'Admin/';

constructor(private http: HttpClient) { }

getClasses(): Observable<Class[]> {
  return this.http.get<Class[]>(this.baseUrl + 'GetAllClass');
}
// tslint:disable-next-line:typedef
createClass(model: Class) {
  return this.http.post(this.baseUrl + 'AddClass', model);
}
}
