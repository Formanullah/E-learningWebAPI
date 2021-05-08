import { Component, OnInit } from '@angular/core';
import { Class } from 'src/app/_models/class';
import { AdminService } from 'src/app/_services/admin.service';
import { AlertifyService } from 'src/app/_services/alertify.service';

@Component({
  selector: 'app-class',
  templateUrl: './class.component.html',
  styleUrls: ['./class.component.css']
})
export class ClassComponent implements OnInit {
  classes: Class[] = [];
  class: Class = {
    id: 0,
    name: ''
  };

  constructor(private Auth: AdminService,  private alertify: AlertifyService) { }

  ngOnInit(): void {
    this.getAllClasses();
  }

  getAllClasses(): void {
    this.Auth.getClasses().subscribe( res => {
      this.classes = res;
    }, error => {
      this.alertify.error('Problem in retrive class');
    });
  }

  // tslint:disable-next-line:typedef
  createClass() {
    console.log(this.class);
    this.Auth.create( 'AddClass', this.class).subscribe( res => {
      this.alertify.success('Class addes successfully');
    }, error => {
      this.alertify.error(error.error.text);
      this.getAllClasses();
    });
  }

  // tslint:disable-next-line:typedef
  deleteClass(id: any) {
    this.Auth.delete('DeleteClass/', id).subscribe( res => {
      this.alertify.success('Class deleted successfully');
    }, error => {
      this.alertify.error(error.error.text);
      this.getAllClasses();
    });
  }

}
