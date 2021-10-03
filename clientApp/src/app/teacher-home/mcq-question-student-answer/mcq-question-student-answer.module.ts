import { ToastrModule } from 'ngx-toastr';
import { MultiSelectModule } from 'primeng/multiselect';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { McqQuestionStudentAnswerRoutingModule } from './mcq-question-student-answer-routing.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { McqQuestionStudentAnswerListComponent } from './mcq-question-student-answer-list/mcq-question-student-answer-list.component';
import { McqQuestionStudentAnswerDetailsComponent } from './mcq-question-student-answer-details/mcq-question-student-answer-details.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    McqQuestionStudentAnswerListComponent,
    McqQuestionStudentAnswerDetailsComponent
  ],
  imports: [
    CommonModule,
    McqQuestionStudentAnswerRoutingModule,
    NgxDatatableModule,
    MultiSelectModule,
    FormsModule,
    ReactiveFormsModule,
    NgxDatatableModule,
    ToastrModule.forRoot(),
  ]
})
export class McqQuestionStudentAnswerModule { }
