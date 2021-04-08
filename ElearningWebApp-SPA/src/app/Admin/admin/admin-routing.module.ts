import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminLoginComponent } from '../admin-login/admin-login.component';
import { BannerComponent } from '../banner/banner.component';
import { ChapterComponent } from '../chapter/chapter.component';
import { ClassComponent } from '../class/class.component';
import { DashboardComponent } from '../dashboard/dashboard.component';
import { SubjectComponent } from '../subject/subject.component';
import { SubjectsForClassComponent } from '../subjects-for-class/subjects-for-class.component';
import { TopicComponent } from '../topic/topic.component';
import { VideoComponent } from '../video/video.component';
import { AdminComponent } from './admin.component';



const adminRoutes: Routes = [
    {
      path: '',
      component: AdminComponent,
      children: [
        {path: 'dashboard', component: DashboardComponent},
        {path: 'chapter', component: ChapterComponent},
        {path: 'class', component: ClassComponent},
        {path: 'subject', component: SubjectComponent},
        {path: 'subjectsforclass', component: SubjectsForClassComponent},
        {path: 'topic', component: TopicComponent},
        {path: 'video', component: VideoComponent},
        {path: 'banner', component: BannerComponent},
        {path: 'admin-login', component: AdminLoginComponent},
        {path: '', redirectTo: '/dashboard', pathMatch: 'full'}
      ]
    }

];

@NgModule({
    imports: [RouterModule.forChild(adminRoutes)],
    exports: [RouterModule]
})
export class AdminRoutingModule { }
