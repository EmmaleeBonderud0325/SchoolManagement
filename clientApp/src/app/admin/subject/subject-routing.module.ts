import { SubjectDetailComponent } from './subject-detail/subject-detail.component';
import { SubjectListComponent } from './subject-list/subject-list.component';
import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'subjects',
    pathMatch: 'full',
  },
  {
    path: 'subjects',
    component: SubjectListComponent,
  },
  {
    path: 'subject-detail',
    component: SubjectDetailComponent,
  },
];


@NgModule({
  declarations: [],
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class SubjectRoutingModule { }
