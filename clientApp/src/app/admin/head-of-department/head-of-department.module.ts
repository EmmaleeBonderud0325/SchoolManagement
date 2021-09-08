import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeadOfDepartmentListComponent } from './head-of-department-list/head-of-department-list.component';
import { HeadOfDepartmentDetailComponent } from './head-of-department-detail/head-of-department-detail.component';
import { HeadOfDepartmentRoutingModule } from './head-of-department-routing.module';



@NgModule({
  declarations: [
    HeadOfDepartmentListComponent,
    HeadOfDepartmentDetailComponent
  ],
  imports: [
    CommonModule,
    HeadOfDepartmentRoutingModule
  ]
})
export class HeadOfDepartmentModule { }
