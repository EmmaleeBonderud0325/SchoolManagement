import { LessonDetailComponent } from './lesson-detail/lesson-detail.component';
import { LessonsComponent } from './lessons/lessons.component';

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
    path: 'lesson-detail',
    component: LessonDetailComponent,
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