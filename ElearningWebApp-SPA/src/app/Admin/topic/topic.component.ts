import { AdminService } from './../../_services/admin.service';
import { Component, OnInit } from '@angular/core';
import { Chapter } from 'src/app/_models/chapter';
import { Class } from 'src/app/_models/class';
import { Subjectforclass } from 'src/app/_models/subjectforclass';
import { Topic } from 'src/app/_models/topic';
import { AlertifyService } from 'src/app/_services/alertify.service';

@Component({
  selector: 'app-topic',
  templateUrl: './topic.component.html',
  styleUrls: ['./topic.component.css']
})
export class TopicComponent implements OnInit {
  classes: Class[] = [];
  subjectsforclass: Subjectforclass[] = [];
  chapters: Chapter[] = [];
  topics: Topic[] = [];
  topic: any = {
    name: '',
    chapterId: 0
  };

  constructor(private Auth: AdminService, private alertify: AlertifyService) { }

  ngOnInit(): void {
    this.getAllClasses();
    this.getAllTopics();
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

  getChapterBySubjectForClassId(id: any): void {
    this.Auth.getChapterBySubjectForClassId(id).subscribe( res => {
      this.chapters = res;
    }, error => {
      this.alertify.error(error);
    });
  }

  getAllTopics(): void {
    this.Auth.getAllTopics().subscribe(res => {
      this.topics = res;
    }, error => {
      this.alertify.error('Problem in retrive topics');
    });
  }

  getAllTopicsByChapterId(id: any): void {
    this.Auth.getAllTopicsByChapterId(id).subscribe(res => {
      this.topics = res;
    }, error => {
      this.alertify.error('Problem in retrive topics');
    });
  }


  addTopic(): void {
    this.Auth.create('AddTopic', this.topic).subscribe( res => {
      this.alertify.success('Topic added successfully');
      this.getAllTopicsByChapterId(this.topic.chapterId);
    }, error => {
      this.alertify.error(error.error.text);
    });
  }

  deleteTopic(id: any): void {
    this.Auth.delete('DeleteTopic/', id).subscribe( res => {
      this.alertify.success('Topic deleted successfully');
      this.getAllTopicsByChapterId(this.topic.chapterId);
    }, error => {
      this.alertify.error(error.error.text);
    });
  }

}
