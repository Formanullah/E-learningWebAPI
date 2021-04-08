import { VideoFormComponent } from './../../../../../ELearning-SPA/src/app/admin/video/video-form/video-form.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminComponent } from './admin.component';
import { RouterModule } from '@angular/router';
import { AdminRoutingModule } from './admin-routing.module';
import { DashboardComponent } from '../dashboard/dashboard.component';
import { ChapterComponent } from '../chapter/chapter.component';
import { ClassComponent } from '../class/class.component';
import { AdminLoginComponent } from '../admin-login/admin-login.component';
import { BannerComponent } from '../banner/banner.component';
import { SubjectComponent } from '../subject/subject.component';
import { SubjectsForClassComponent } from '../subjects-for-class/subjects-for-class.component';
import { TopicComponent } from '../topic/topic.component';

@NgModule({
  declarations: [
    AdminComponent,
    AdminLoginComponent,
    BannerComponent,
    DashboardComponent,
    ChapterComponent,
    ClassComponent,
    SubjectComponent,
    SubjectsForClassComponent,
    TopicComponent,
    VideoFormComponent
  ],

  imports: [
    RouterModule,
    CommonModule,
    AdminRoutingModule
  ],
  providers: []
})
export class AdminModule { }
