import { Component, OnInit } from '@angular/core';
import { Class } from 'src/app/_models/class';
import { AdminService } from 'src/app/_services/admin.service';

@Component({
  selector: 'app-class',
  templateUrl: './class.component.html',
  styleUrls: ['./class.component.css']
})
export class ClassComponent implements OnInit {
  classes: Class[] = [];
  class: any;

  constructor(private Auth: AdminService) { }

  ngOnInit(): void {
    this.getAllClasses();
  }

  getAllClasses(): void {
    this.Auth.getClasses().subscribe( res => {
      this.classes = res;
    }, error => {
      console.log('Problem in retrive class');
    });
  }

  createClass(): void {
    this.Auth.createClass(this.class).subscribe( res => {
      console.log(res);
    }, error => {
      console.log(error);
    });
  }

}
