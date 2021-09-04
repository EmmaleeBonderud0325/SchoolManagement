import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { EssayStudentAnswerListComponent } from './essay-student-answer-list/essay-student-answer-list.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'essay-student-answer',
    pathMatch: 'full',
  },
  {
    path: 'essay-student-answer',
    component: EssayStudentAnswerListComponent,
  },
 
];

@NgModule({
  declarations: [],
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class EssayStudentAnswerRoutingModule { }
