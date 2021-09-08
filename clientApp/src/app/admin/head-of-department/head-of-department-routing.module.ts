import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes } from '@angular/router';
import { HeadOfDepartmentListComponent } from './head-of-department-list/head-of-department-list.component';
import { HeadOfDepartmentDetailComponent } from './head-of-department-detail/head-of-department-detail.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'head-of-department',
    pathMatch: 'full',
  },
  {
    path: 'head-of-department',
    component: HeadOfDepartmentListComponent,
  },
  {
    path: 'head-of-department',
    component: HeadOfDepartmentDetailComponent,
  },
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ]
})
export class HeadOfDepartmentRoutingModule { }
