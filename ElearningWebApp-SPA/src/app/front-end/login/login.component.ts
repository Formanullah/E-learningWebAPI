import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  model: any = {};
  constructor(private auth: AuthService) { }

  ngOnInit() {
  }

  login(): void {
    console.log(this.model);
    this.auth.login(this.model).subscribe( res => {
      console.log(res);
    }, error => {
      console.log(error);
    });
  }

}
