import { ToastrModule } from 'ngx-toastr';
import { MultiSelectModule } from 'primeng/multiselect';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StudentMcqQuestionRoutingModule } from './student-mcq-question-routing.module';
import { StudentMcqQuestionListComponent } from './student-mcq-question-list/student-mcq-question-list.component';
import { StudentMcqQuestionDetailsComponent } from './student-mcq-question-details/student-mcq-question-details.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    StudentMcqQuestionListComponent,
    StudentMcqQuestionDetailsComponent
  ],
  imports: [
    CommonModule,
    StudentMcqQuestionRoutingModule,
    NgxDatatableModule,
    MultiSelectModule,
    FormsModule,
    ReactiveFormsModule,
    NgxDatatableModule,
    ToastrModule.forRoot(),
  ]
})
export class StudentMcqQuestionModule { }
