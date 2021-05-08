import { Injectable } from '@angular/core';
declare let alertify: any;

@Injectable({
  providedIn: 'root'
})
export class AlertifyService {
constructor() { }


// tslint:disable-next-line:typedef
confirm(title: string, message: string, okCallback: () => any, cancelCallback: () => any) {
  alertify.confirm(title, message, () => { okCallback(); }
              , () => { cancelCallback(); });
}

// tslint:disable-next-line:typedef
success(message: string) {
  alertify.success(message);
}

// tslint:disable-next-line:typedef
error(message: string) {
  alertify.error(message);
}

// tslint:disable-next-line:typedef
warning(message: string) {
  alertify.warning(message);
}

// tslint:disable-next-line:typedef
message(message: string) {
  alertify.message(message);
}

}
