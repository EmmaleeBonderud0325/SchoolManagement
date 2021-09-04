
import { LessonAssignmentListComponent } from './lesson-assignment-list/lesson-assignment-list.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MultiSelectModule } from 'primeng/multiselect';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ToastrModule } from 'ngx-toastr';
import { LessonAssignmentRoutingModule } from './lesson-assignment-routing.module';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';

@NgModule({
  declarations: [
    LessonAssignmentListComponent
  ],
  
  imports: [
    CommonModule,
    LessonAssignmentRoutingModule,
    MultiSelectModule,
    FormsModule,
    ReactiveFormsModule,
    NgxDatatableModule,
    ToastrModule.forRoot(),

  ]
})
export class LessonAssignmentModule { }
