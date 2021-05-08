import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from '../_guards/auth.guard';
import { SubjectsChapter } from '../_resolver/subjects-chapter.resolver';
import { SubjectsTopicResolver } from '../_resolver/subjects-topic.resolver';
import { SubejctVideo } from '../_resolver/subjects-video.resolver';
import { SubjectsResolver } from '../_resolver/subjects.resolver';
import { ChaptersComponent } from './class/chapters/chapters.component';

import { SubjectDetailsComponent } from './class/subject-details/subject-details.component';
import { SubjectsComponent } from './class/subjects/subjects.component';
/* import { HomePageComponent } from '../home-page/home-page.component';
import { CollectionComponent } from '../collection/collection.component';
import { ProductDetailsComponent } from '../product-details/product-details.component';
import { CheckoutComponent } from '../checkout/checkout.component';
import { OrderSuccessComponent } from '../order-success/order-success.component'; */
import { FrontEndComponent } from './front-end.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { NoticeComponent } from './notice/notice.component';
import { ProfileComponent } from './profile/profile.component';
import { RegisterComponent } from './register/register.component';
import { SubjectVideoComponent } from './subject-video/subject-video.component';
/* import { LoginComponent } from '../login/login.component';
import { UserRegistrationComponent } from '../user-registration/user-registration.component';
import { AllshopComponent } from '../allshop/allshop.component';
import { VendorRegistrationComponent } from '../vendor-registration/vendor-registration.component';
import { ShoplistResolver } from '../_resolver/shop-list.resolver';
import { VendorproductlistResolver } from '../_resolver/vendor-product-list.resolver';
import { ProductDetailsResolver } from '../_resolver/product-details.resolver';
import { ProductListByCategoryResolver } from './../_resolver/product-list-by-category.resolver';
import { CartComponent } from '../cart/cart.component'; */



const routes: Routes = [
    {
      path: '',
      component: FrontEndComponent,
      children: [
        { path: 'home', component: HomeComponent },
        { path: 'login', component: LoginComponent },
      { path: 'signup', component: RegisterComponent },
      { path: 'subjectsvideo/:id', component: SubjectVideoComponent , resolve: {videos: SubejctVideo}},
      {path: '', redirectTo: '/home', pathMatch: 'full'},
      ]
    },

    {path: '',
    component: FrontEndComponent,
    
    children: [
      { path: 'subjects/:id', component: SubjectsComponent, resolve: {subjects: SubjectsResolver} },
      { path: 'chapters/:id', component: ChaptersComponent , resolve: {chapters: SubjectsChapter}},
      { path: 'topics/:id', component: SubjectDetailsComponent , resolve: {topics: SubjectsTopicResolver}},
      { path: 'notice', component: NoticeComponent },
      { path: 'profile', component: ProfileComponent },
    ]
  },
  {path: '**', redirectTo: '', pathMatch: 'full'},
  ];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class FrontEndRoutingModule { }