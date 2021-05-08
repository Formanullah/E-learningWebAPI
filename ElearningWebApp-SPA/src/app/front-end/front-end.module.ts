import { AuthGuard } from './../_guards/auth.guard';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';



import { RouterModule } from '@angular/router';
import { FrontEndRoutingModule } from './front-end-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SlickCarouselModule } from 'ngx-slick-carousel';

import { FrontEndComponent } from './front-end.component';
import { HomeComponent } from './home/home.component';
import { FooterComponent } from './footer/footer.component';
import { NavComponent } from './nav/nav.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { NoticeComponent } from './notice/notice.component';
import { ProfileComponent } from './profile/profile.component';
import { SubjectsComponent } from './class/subjects/subjects.component';
import { SubjectDetailsComponent } from './class/subject-details/subject-details.component';
import { SubejctVideo } from '../_resolver/subjects-video.resolver';
import { SubjectVideoComponent } from './subject-video/subject-video.component';
import { SubjectsResolver } from '../_resolver/subjects.resolver';
import { SubjectsChapter } from '../_resolver/subjects-chapter.resolver';
import { ChaptersComponent } from './class/chapters/chapters.component';
import { SubjectsTopicResolver } from '../_resolver/subjects-topic.resolver';

@NgModule({
  declarations: [
    FrontEndComponent,
    HomeComponent,
    FooterComponent,
    NavComponent,
    LoginComponent,
    RegisterComponent,
    NoticeComponent,
    ProfileComponent,
    SubjectsComponent,
    SubjectDetailsComponent,
    SubjectVideoComponent,
    ChaptersComponent
  ],
  imports: [
    RouterModule,
    CommonModule,
    FrontEndRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    SlickCarouselModule
  ],
  providers: [
    SubejctVideo,
    SubjectsResolver,
    SubjectsChapter,
    SubjectsTopicResolver,
    AuthGuard
  ]
})
export class FrontEndModule { }
