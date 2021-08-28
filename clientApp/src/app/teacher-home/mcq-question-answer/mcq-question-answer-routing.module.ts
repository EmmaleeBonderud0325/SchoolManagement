import { QuestionRoutingModule } from './../question/question-routing.module';
import { ToastrModule } from 'ngx-toastr';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MultiSelectModule } from 'primeng/multiselect';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { McqQuestionAnswerDetailComponent } from './mcq-question-answer-detail/mcq-question-answer-detail.component';
import { McqQuestionAnswerListComponent } from './mcq-question-answer-list/mcq-question-answer-list.component';
import { Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';



const routes: Routes = [
  {
    path: '',
    redirectTo: 'mcqquestionanswers',
    pathMatch: 'full',
  },
  {
    path: 'mcqquestionanswers',
    component: McqQuestionAnswerListComponent,
  },
  {
    path: 'question-detail',
    component: McqQuestionAnswerDetailComponent,
  },
];


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    QuestionRoutingModule,
    NgxDatatableModule,
    MultiSelectModule,
    FormsModule,
    ReactiveFormsModule,
    NgxDatatableModule,
    ToastrModule.forRoot(),
  ]
})
export class McqQuestionAnswerRoutingModule { }
