import { Subjectforclass } from './../../_models/subjectforclass';
import { Component, OnInit } from '@angular/core';
import { Class } from 'src/app/_models/class';
import { AdminService } from 'src/app/_services/admin.service';
import { Subject } from 'src/app/_models/subject';
import { environment } from 'src/environments/environment';
import { AlertifyService } from 'src/app/_services/alertify.service';

@Component({
  selector: 'app-subjects-for-class',
  templateUrl: './subjects-for-class.component.html',
  styleUrls: ['./subjects-for-class.component.css']
})
export class SubjectsForClassComponent implements OnInit {
  classes: Class[] = [];
  subjectsforclass: Subjectforclass[] = [];
  subjects: Subject[] = [];
  myFile!: File ;

  imageDirectoryPath = environment.imageDirectoryPath + 'Subject/';
  subjectForClass = {
    SubjectId: 0,
    ClassId : 0
  };
  constructor(private Auth: AdminService, private alertify: AlertifyService) { }

  // tslint:disable-next-line:typedef
  ngOnInit() {
    this.getAllClasses();
    this.getAllSubjects();
  }

  getAllClasses(): void {
    this.Auth.getClasses().subscribe( res => {
      this.classes = res;
      this.getSubjectByClassId(res[0].id);
    }, error => {
      this.alertify.error('Problem in retrive class');
    });
  }
  getAllSubjects(): void {
    this.Auth.getAllSubjects().subscribe( res => {
      this.subjects = res;
    }, error => {
      this.alertify.error('Problem in retrive subjects');
    });
  }

  // tslint:disable-next-line:typedef
  getSubjectByClassId(id: any) {
    this.Auth.getSubjectByClassId(id).subscribe( res => {
      this.subjectsforclass = res;
    }, error => {
      this.alertify.error('problem in retrive classes');
    });
  }

  // tslint:disable-next-line:typedef
  handleFileInput(event: Event) {
    const target = event.target as unknown as HTMLInputElement;
    const files = target?.files as FileList;

    if (files && files.length > 0) {

        this.myFile = files[0];
    }
    }

    // tslint:disable-next-line:typedef
    addSubjectInClass() {
      const formData: FormData = new FormData();
      formData.append('SubjectId', this.subjectForClass.SubjectId.toString());
      formData.append('ClassId', this.subjectForClass.ClassId.toString());
      formData.append('SubjectImage', this.myFile);

      this.Auth.create('AddSubjectInClass', formData).subscribe( res => {
       this.alertify.success('Subject added in the class successfully');
       this.getSubjectByClassId(this.subjectForClass.ClassId);
      }, error => {
        this.alertify.error(error.error.text);
      });
    }



    // tslint:disable-next-line:typedef
    deleteSubjectInClass(id: any) {
      this.Auth.delete('DeleteSubjectInAClass/', id).subscribe( res => {
        this.alertify.success('Subject deleted from the class successfully');
        this.getSubjectByClassId(this.subjectForClass.ClassId);
      }, error => {
        this.alertify.error(error.error.text);
      });
    }

}
