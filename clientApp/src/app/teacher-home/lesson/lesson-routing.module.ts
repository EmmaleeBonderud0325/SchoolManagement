import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LessonListComponent } from './lesson-list/lesson-list.component';
import { LessonDetailComponent } from './lesson-detail/lesson-detail.component';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'lessons',
    pathMatch: 'full',
  },
  {
    path: 'lessons',
    component:LessonListComponent,
  },
  {
    path: 'lesson-detail',
    component:LessonDetailComponent,
  },
]


@NgModule({
  declarations: [],
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class LessonRoutingModule { }
