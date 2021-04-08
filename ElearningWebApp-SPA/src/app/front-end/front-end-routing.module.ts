import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

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
        { path: 'subjects', component: SubjectsComponent },
        { path: 'subjectdetails', component: SubjectDetailsComponent },
        { path: 'login', component: LoginComponent },
        { path: 'signup', component: RegisterComponent },
        { path: 'notice', component: NoticeComponent },
        { path: 'profile', component: ProfileComponent },
        {path: '', redirectTo: '/home', pathMatch: 'full'},
        /*
        { path: 'cart', component: CartComponent },
        { path: 'shops/:id', component: CollectionComponent, resolve: {products: VendorproductlistResolver} },
        { path: 'category/:id', component: CollectionComponent, resolve: {products: ProductListByCategoryResolver} },
        { path: 'product/:id', component: ProductDetailsComponent, resolve: {product: ProductDetailsResolver} }, */
        {
          /* path: 'checkout',
          component: CheckoutComponent, */
          // canActivate: [AngularFireAuthGuard],
          // data: { authGuardPipe: redirectUnauthorizedToLogin }
        },
        {
          /* path: 'order-success',
          component: OrderSuccessComponent */
          // canActivate: [AngularFireAuthGuard],
          // data: { authGuardPipe: redirectUnauthorizedToLogin }
        },
      /*   { path: 'login', component: LoginComponent },
        { path: 'user-registration', component: UserRegistrationComponent },
        { path: 'vendor-registration', component: VendorRegistrationComponent },
        { path: 'all-shop', component: AllshopComponent, resolve: {shops: ShoplistResolver} } */
      ]
    }
  ];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class FrontEndRoutingModule { }