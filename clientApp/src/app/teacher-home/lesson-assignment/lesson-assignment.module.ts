import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LessonAssignmentRoutingModule } from './lesson-assignment-routing.module';
import { LessonAssignmentListComponent } from './lesson-assignment-list/lesson-assignment-list.component';



@NgModule({
  declarations: [
    LessonAssignmentListComponent
  ],
  imports: [
    CommonModule,
    LessonAssignmentRoutingModule
  ]
})
export class LessonAssignmentModule { }
