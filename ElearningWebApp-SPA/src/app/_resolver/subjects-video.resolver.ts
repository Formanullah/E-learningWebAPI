import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot} from '@angular/router';
import { UserService } from '../_services/user.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Video } from '../_models/video';
import { AlertifyService } from '../_services/alertify.service';

@Injectable()
export class SubejctVideo implements Resolve<Video[]> {
    constructor(private userService: UserService, private alertify: AlertifyService,
                private router: Router) {}
    resolve(route: ActivatedRouteSnapshot): Observable<Video[]> {
        // tslint:disable-next-line:no-string-literal
        return this.userService.getVideosBySubjectId(route.params['id']).pipe(
            catchError( error => {
                this.alertify.error('problem retriving Data');
                this.router.navigate(['/home']);
                return of<Video[]>();
            })
        );
    }
}
