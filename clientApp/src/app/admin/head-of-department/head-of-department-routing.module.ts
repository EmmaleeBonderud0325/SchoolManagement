import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { HeadOfDepartmentListComponent } from './head-of-department-list/head-of-department-list.component';
import { HeadOfDepartmentDetailComponent } from './head-of-department-detail/head-of-department-detail.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'head-of-departments',
    pathMatch: 'full',
  },
  {
    path: 'head-of-departments',
    component: HeadOfDepartmentListComponent,
  },
  {
    path: 'head-of-department',
    component: HeadOfDepartmentDetailComponent,
  },
];

@NgModule({
  declarations: [],
  imports:[RouterModule.forChild(routes)],
  exports:[RouterModule]
})
export class HeadOfDepartmentRoutingModule { }
