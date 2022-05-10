import { AdminPageComponent } from './pages/admin/admin-page/admin-page.component';
import { SignupComponent } from './pages/signup/signup.component';
import { SigninComponent } from './pages/signin/signin.component';
import { NgModule, Component } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MainComponent } from './layout/main/main.component';
import { PublicHomeComponent } from './pages/public-home/public-home.component';

const routes: Routes = [
  {
    path: '',
    component: MainComponent,
    children:[
      {
        path:'',
        component: PublicHomeComponent,
      },
      {
        path:'signin',
        component: SigninComponent,
      },
      {
        path:'signup',
        component: SignupComponent,
      },
      {
        path:'account',
        component:AdminPageComponent,
      }

    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
