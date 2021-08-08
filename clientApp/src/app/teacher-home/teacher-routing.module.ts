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
];
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class TeacherHomeRoutingModule {}