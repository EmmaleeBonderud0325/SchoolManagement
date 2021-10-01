import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { StudentHomeComponent } from './student-home/student-home.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'studentHome',
    pathMatch: 'full',
  },
  {
    path: 'studentHome',
    component: StudentHomeComponent,
  },
 ];
 @NgModule({
  declarations: [],
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class StudentHomeRoutingModule { }
