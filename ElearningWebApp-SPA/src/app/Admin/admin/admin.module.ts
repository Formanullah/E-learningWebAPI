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
import { VideoComponent } from '../video/video.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AdminRegisterComponent } from '../admin-register/admin-register.component';

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
    VideoComponent,
    AdminRegisterComponent
  ],

  imports: [
    RouterModule,
    CommonModule,
    AdminRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: []
})
export class AdminModule { }
