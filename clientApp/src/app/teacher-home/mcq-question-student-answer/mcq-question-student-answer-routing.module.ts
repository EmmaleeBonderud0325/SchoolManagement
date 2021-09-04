import { McqQuestionStudentAnswerDetailsComponent } from './mcq-question-student-answer-details/mcq-question-student-answer-details.component';
import { McqQuestionStudentAnswerListComponent } from './mcq-question-student-answer-list/mcq-question-student-answer-list.component';
import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';


const routes: Routes = [
  {
    path: '',
    redirectTo: 'mcq-question-student-answer',
    pathMatch: 'full',
  },
  {
    path: 'mcq-question-student-answer',
    component: McqQuestionStudentAnswerListComponent,
  },
  {
    path: 'mcq-question-student-answer-details',
    component: McqQuestionStudentAnswerDetailsComponent,
  },
];


@NgModule({
  declarations: [],
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class McqQuestionStudentAnswerRoutingModule { }
