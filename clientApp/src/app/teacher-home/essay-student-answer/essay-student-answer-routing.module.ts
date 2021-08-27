import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { EssayStudentAnswerListComponent } from './essay-student-answer-list/essay-student-answer-list.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'essay-Student-answer',
    pathMatch: 'full',
  },
  {
    path: 'essay-studeny-answer-list',
    component: EssayStudentAnswerListComponent,
  },
  //{
   // path: 'mcq-question-answer-detail',
   // component: McqQuestionAnswerDetailComponent,
 // },
];


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ]
})
export class EssayStudentAnswerRoutingModule { }
