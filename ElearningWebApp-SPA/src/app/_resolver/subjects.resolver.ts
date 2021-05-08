import { Subject } from 'src/app/_models/subject';
import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot} from '@angular/router';
import { UserService } from '../_services/user.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AlertifyService } from '../_services/alertify.service';

@Injectable()
export class SubjectsResolver implements Resolve<Subject[]> {
    constructor(private userService: UserService, private alertify: AlertifyService,
                private router: Router) {}
    resolve(route: ActivatedRouteSnapshot): Observable<Subject[]> {
        // tslint:disable-next-line:no-string-literal
        return this.userService.getAllSubjectsByClassId(route.params['id']).pipe(
            catchError( error => {
                this.alertify.error('problem retriving Data');
                this.router.navigate(['/home']);
                return of<Subject[]>();
            })
        );
    }
}
