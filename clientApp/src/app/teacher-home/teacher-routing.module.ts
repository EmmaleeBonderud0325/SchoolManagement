import { QuestionListComponent } from './question/question-list/question-list.component';





import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
const routes: Routes = [
  {
    path: '',
    redirectTo: 'lesson',
    pathMatch: 'full',
  },
  {
    path: 'lesson',
    loadChildren:() =>
          import('./lesson/lesson.module').then((m)=>m.LessonModule)
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
  
  
];
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class TeacherHomeRoutingModule {}