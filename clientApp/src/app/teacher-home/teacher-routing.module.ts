import { QuestionListComponent } from './question/question-list/question-list.component';
import { LessonsComponent } from './lessons/lessons.component';

import { LessonDetailComponent } from './lesson-detail/lesson-detail.component';


import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
const routes: Routes = [
  {
    path: '',
    redirectTo: 'lessons',
    pathMatch: 'full',
  },
  {
    path: 'lessons',
    component: LessonsComponent,
  },


  {
    path: '',
    redirectTo: 'question',
    pathMatch: 'full',
  },
  {
    path: 'question',
    loadChildren:() =>
          import('./question/question.module').then((m)=>m.QuestionModule)
  },


  {
    path: '',
    redirectTo: 'mcq-question-answer',
    pathMatch: 'full',
  },
  {
    path: 'mcq-question-answer',
    loadChildren:() =>
          import('./mcq-question-answer/mcq-question-answer.module').then((m)=>m.McqQuestionAnswerModule)
  },
  {
    path: '',
    redirectTo: 'essay-answer',
    pathMatch: 'full',
  },
  {
    path: 'essay-answer',
    loadChildren:() =>
          import('./essay-answer/essay-answer.module').then((m)=>m.EssayAnswerModule)
  },


];
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class TeacherHomeRoutingModule {}