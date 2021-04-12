import { Component, OnInit } from '@angular/core';
import { Class } from 'src/app/_models/class';
import { Register } from 'src/app/_models/register';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  classes: Class[] = [];
  user: any = {};

  constructor(private auth: AuthService) { }

  ngOnInit() {
    this.auth.getClasses().subscribe( res => {
      this.classes = res;
    }, error => {
      console.log('problem in retrive classes');
    });
  }


  register(): void {
    this.auth.userRegister(this.user).subscribe( res => {
      console.log('Registration Successfull');
    }, error => {console.log('Registration Failed'); });
  }

}
