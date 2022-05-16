import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SigninComponent } from './signin/signin.component';
import { SignupComponent } from './signup/signup.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { JobCategoryComponent } from './admin/job-category/job-category.component';
import { AdminProfileSideComponent } from './admin/admin-profile-side/admin-profile-side.component';
import { AdminPageComponent } from './admin/admin-page/admin-page.component';
import { CompanyRequestsComponent } from './admin/company-requests/company-requests.component';
import { AddJobComponent } from './admin/add-job/add-job.component';



@NgModule({
  declarations: [
    SigninComponent,
    SignupComponent,
    JobCategoryComponent,
    AdminProfileSideComponent,
    AdminPageComponent,
    CompanyRequestsComponent,
    AddJobComponent,
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    RouterModule
  ]
})
export class PublicModule { }
