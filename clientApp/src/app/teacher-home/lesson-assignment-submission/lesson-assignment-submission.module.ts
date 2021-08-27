import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LessonAssignmentSubmissionRoutingModule } from './lesson-assignment-submission-routing.module';
import { LessonAssignmentSubmissionListComponent } from './lesson-assignment-submission-list/lesson-assignment-submission-list.component';



@NgModule({
  declarations: [
    LessonAssignmentSubmissionListComponent
  ],
  imports: [
    CommonModule,
    LessonAssignmentSubmissionRoutingModule
  ]
})
export class LessonAssignmentSubmissionModule { }
