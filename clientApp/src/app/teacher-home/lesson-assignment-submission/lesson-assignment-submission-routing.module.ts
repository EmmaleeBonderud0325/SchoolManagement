import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { LessonAssignmentSubmissionListComponent } from './lesson-assignment-submission-list/lesson-assignment-submission-list.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'lesson-assignment-submission',
    pathMatch: 'full',
  },
  {
    path: 'lesson-assignment-submission',
    component: LessonAssignmentSubmissionListComponent,
  },
 
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ]
})
export class LessonAssignmentSubmissionRoutingModule { }
