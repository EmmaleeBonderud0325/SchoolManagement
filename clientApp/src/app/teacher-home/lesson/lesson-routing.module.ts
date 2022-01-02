import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LessonListComponent } from './lesson-list/lesson-list.component';
import { LessonDetailComponent } from './lesson-detail/lesson-detail.component';
import { RouterModule, Routes } from '@angular/router';
import { LessonContentComponent } from './lesson-content/lesson-content.component';
import { LessonContainerComponent } from './lesson-container/lesson-container.component';



const routes: Routes = [
  {
    path: '',
    redirectTo: 'lesson',
    pathMatch: 'full',
  },
  {
    path: 'lesson',
    component:LessonListComponent,
  },
  {
    path: 'lesson/:id',
    component:LessonContainerComponent,
  }
]


@NgModule({
  declarations: [],
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class LessonRoutingModule { }
