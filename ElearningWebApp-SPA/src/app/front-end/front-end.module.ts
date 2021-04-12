import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';



import { RouterModule } from '@angular/router';
import { FrontEndRoutingModule } from './front-end-routing.module';

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
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SlickCarouselModule } from 'ngx-slick-carousel';

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
    SubjectDetailsComponent
  ],
  imports: [
    RouterModule,
    CommonModule,
    FrontEndRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    SlickCarouselModule
  ],
  providers: []
})
export class FrontEndModule { }
