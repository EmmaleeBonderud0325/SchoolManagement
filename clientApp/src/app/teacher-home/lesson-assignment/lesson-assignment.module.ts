import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LessonAssignmentRoutingModule } from './lesson-assignment-routing.module';
import { LessonAssignmentListComponent } from './lesson-assignment-list/lesson-assignment-list.component';
import { DatatableComponent, NgxDatatableModule } from '@swimlane/ngx-datatable';
import { MultiSelectModule } from 'primeng/multiselect';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ToastrModule } from 'ngx-toastr';


@NgModule({
  declarations: [
    LessonAssignmentListComponent
  ],
  imports: [
    CommonModule,
    LessonAssignmentRoutingModule,
    MultiSelectModule,
    FormsModule,
    DatatableComponent,
    ReactiveFormsModule,
    NgxDatatableModule,
    ToastrModule.forRoot(),
  ]
})
export class LessonAssignmentModule { }
