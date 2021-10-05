import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EssayStudentAnswerRoutingModule } from './essay-student-answer-routing.module';
import { EssayStudentAnswerListComponent } from './essay-student-answer-list/essay-student-answer-list.component';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { MultiSelectModule } from 'primeng/multiselect';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ToastrModule } from 'ngx-toastr';


@NgModule({
  declarations: [
    EssayStudentAnswerListComponent
  ],
  imports: [
    CommonModule,
    EssayStudentAnswerRoutingModule,
    MultiSelectModule,
    FormsModule,
    ReactiveFormsModule,
    NgxDatatableModule,
    ToastrModule.forRoot(),
  ]
})
export class EssayStudentAnswerModule { }
