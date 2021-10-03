import { StudentMcqQuestionDetailsComponent } from './student-mcq-question-details/student-mcq-question-details.component';
import { StudentMcqQuestionListComponent } from './student-mcq-question-list/student-mcq-question-list.component';
import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'student-mcq-question',
    pathMatch: 'full',
  },
  {
    path: 'student-mcq-question',
    component: StudentMcqQuestionListComponent,
  },
  {
    path: 'student-mcq-question-detail',
    component: StudentMcqQuestionDetailsComponent,
  },
];

@NgModule({
  declarations: [],
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class StudentMcqQuestionRoutingModule { }
