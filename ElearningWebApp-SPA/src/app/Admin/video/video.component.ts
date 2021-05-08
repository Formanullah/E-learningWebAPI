import { Class } from 'src/app/_models/class';
import { Chapter } from 'src/app/_models/chapter';
import { AdminService } from 'src/app/_services/admin.service';
import { Component, OnInit } from '@angular/core';
import { Video } from 'src/app/_models/video';
import { Topic } from 'src/app/_models/topic';
import { Subjectforclass } from 'src/app/_models/subjectforclass';
import { AlertifyService } from 'src/app/_services/alertify.service';

@Component({
  selector: 'app-video',
  templateUrl: './video.component.html',
  styleUrls: ['./video.component.css']
})
export class VideoComponent implements OnInit {
  classes: Class[] = [];
  subjectsforclass: Subjectforclass[] = [];
  chapters: Chapter[] = [];
  topics: Topic[] = [];
  videos: Video[] = [];
  myFile!: File ;
  video: any = {
    isfree: false,
    topicId: 0
  };

  constructor(private Auth: AdminService, private alertify: AlertifyService) { }

  ngOnInit(): void {
    this.getAllClasses();
    this.getAllVideos();
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

  getAllVideos(): void {
    this.Auth.getAllVideos().subscribe(res => {
      this.videos = res;
    }, error => {
      this.alertify.error('Problem in retrive videos');
    });
  }

  getAllTopicsByChapterId(id: any): void {
    this.Auth.getAllTopicsByChapterId(id).subscribe(res => {
      this.topics = res;
    }, error => {
      this.alertify.error('Problem in retrive topics');
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

  AddVideo() {
    const formData: FormData = new FormData();
    formData.append('isfree', this.video.isfree);
    formData.append('topicId', this.video.topicId.toString());
    formData.append('file', this.myFile);

    // console.log(formData);
    this.Auth.create('AddVideo', formData).subscribe( res => {
      this.alertify.success('Video added successfully');
      this.getAllVideos();
    }, error => {
      this.alertify.error(error.error);
    });

  }

  deleteVideo(id: any): void {
    this.Auth.delete('DeleteVideo/', id).subscribe( res => {
      this.alertify.success('Video deleted successfully');
      this.getAllVideos();
    }, error => {
      this.alertify.error(error);
      this.getAllVideos();
    });
  }


}
