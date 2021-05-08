import { Chapter } from 'src/app/_models/chapter';
import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot} from '@angular/router';
import { UserService } from '../_services/user.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Topic } from '../_models/topic';
import { AlertifyService } from '../_services/alertify.service';

@Injectable()
export class SubjectsTopicResolver implements Resolve<Topic[]> {
    constructor(private userService: UserService, private alertify: AlertifyService,
                private router: Router) {}
    resolve(route: ActivatedRouteSnapshot): Observable<Topic[]> {
        // tslint:disable-next-line:no-string-literal
        return this.userService.getAllTopicsByChapterId(route.params['id']).pipe(
            catchError( error => {
                this.alertify.error('problem retriving Data');
                this.router.navigate(['/home']);
                return of<Topic[]>();
            })
        );
    }
}
