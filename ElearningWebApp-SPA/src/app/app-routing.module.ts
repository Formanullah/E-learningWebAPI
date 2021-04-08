import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const appRoutes: Routes = [
  {
    path: 'Admin',
    loadChildren: () => import('./Admin/admin/admin.module').then(m => m.AdminModule)
  },
  { path: '',
  loadChildren: () => import('./front-end/front-end.module').then(m => m.FrontEndModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(appRoutes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
