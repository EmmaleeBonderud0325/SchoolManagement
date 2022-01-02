import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LessonAssignmentSubmissionRoutingModule } from './lesson-assignment-submission-routing.module';
import { LessonAssignmentSubmissionListComponent } from './lesson-assignment-submission-list/lesson-assignment-submission-list.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { ToastrModule } from 'ngx-toastr';
import { MultiSelectModule } from 'primeng/multiselect';



@NgModule({
  declarations: [
    LessonAssignmentSubmissionListComponent
  ],
  imports: [
    CommonModule,
    LessonAssignmentSubmissionRoutingModule,
    MultiSelectModule,
    FormsModule,
    ReactiveFormsModule,
    NgxDatatableModule,
    ToastrModule.forRoot(),
  ]
})
export class LessonAssignmentSubmissionModule { }
