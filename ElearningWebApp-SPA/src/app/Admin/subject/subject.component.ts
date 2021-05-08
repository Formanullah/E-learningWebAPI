import { Subject } from './../../_models/subject';
import { Component, OnInit } from '@angular/core';
import { AdminService } from 'src/app/_services/admin.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { EditableSubject } from 'src/app/_models/editable-subject';

@Component({
  selector: 'app-subject',
  templateUrl: './subject.component.html',
  styleUrls: ['./subject.component.css']
})
export class SubjectComponent implements OnInit {
  subject: any = {
    name: ''
  };
  subjects: Subject[] = [];

  updatedSubject: EditableSubject = {
    id: 0,
    name: ''
  };

  constructor(private Auth: AdminService, private alertify: AlertifyService) { }

  // tslint:disable-next-line:typedef
  ngOnInit() {
    this.getAllSubjects();
  }

  getAllSubjects(): void {
    this.Auth.getAllSubjects().subscribe( res => {
      this.subjects = res;
    }, error => {
      this.alertify.error('problem in retrive subjects');
    });
  }

  // tslint:disable-next-line:typedef
  createSubject() {
    this.Auth.create('AddSubject', this.subject).subscribe( res => {
      this.alertify.success('Subject added successfully');
    }, error => {
      this.alertify.error(error.error);
    }, () => {
      this.getAllSubjects();
    });
  }

  // tslint:disable-next-line:typedef
  deleteSubject(id: any) {
    this.Auth.delete('DeleteSubject/', id).subscribe( res => {
      this.alertify.success('Subject added successfully');
      this.getAllSubjects();
    }, error => {
      console.log(error.error.text);
    });
  }

  updateSubject(): void {
  /*   this.Auth.updateSubejcet(this.updatedSubject).subscribe( res => {
      this.alertify.success('Update successfully');
    }, error => {
      this.alertify.error(error);
    }, () => {
      this.getAllSubjects();
    }); */
    console.log(this.updatedSubject);
  }

}
