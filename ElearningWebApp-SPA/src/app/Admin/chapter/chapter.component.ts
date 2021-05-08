import { Subjectforclass } from './../../_models/subjectforclass';
import { Component, OnInit } from '@angular/core';
import { Class } from 'src/app/_models/class';
import { AdminService } from 'src/app/_services/admin.service';
import { Chapter } from 'src/app/_models/chapter';
import { AlertifyService } from 'src/app/_services/alertify.service';

@Component({
  selector: 'app-chapter',
  templateUrl: './chapter.component.html',
  styleUrls: ['./chapter.component.css']
})
export class ChapterComponent implements OnInit {
  classes: Class[] = [];
  subjectsforclass: Subjectforclass[] = [];
  chapter: any = {
    name: '',
    subjectForClassId: 0
  };
  chapters: Chapter[] = [];

  constructor(private Auth: AdminService, private alertify: AlertifyService) { }

  ngOnInit(): void {
    this.getAllClasses();
    this.getAllChapers();
  }
  getAllClasses(): void {
    this.Auth.getClasses().subscribe( res => {
      this.classes = res;
    }, error => {
      this.alertify.error('Problem in retrive class');
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

  getAllChapers(): void {
    this.Auth.getAllChapters().subscribe( res => {
      this.chapters = res;
    }, error => {
      this.alertify.error('problem in retrive chapters');
    });
  }

  getChapterBySubjectForClassId(id: any): void {
    this.Auth.getChapterBySubjectForClassId(id).subscribe( res => {
      this.chapters = res;
    }, error => {
      this.alertify.error('problem in retrive subjects');
    });
  }

  addChapter(): void {
    this.Auth.create('AddChapter', this.chapter).subscribe( res => {
      this.alertify.success('Chapter added Successfully');
      this.getChapterBySubjectForClassId(this.chapter.subjectForClassId);
    }, error => {
      this.alertify.error(error.error.text);
    });
  }

  deleteChapter(id: any): void {
    this.Auth.delete('DeleteChapter/', id).subscribe( res => {
      this.alertify.success('Chapter Deleted Successfully');
      this.getChapterBySubjectForClassId(this.chapter.subjectForClassId);
    }, error => {
      this.alertify.error(error.error.text);
    });
  }

}
