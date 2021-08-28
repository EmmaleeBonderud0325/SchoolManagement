import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { McqQuestionAnswerRoutingModule } from './mcq-question-answer-routing.module';
import { McqQuestionAnswerListComponent } from './mcq-question-answer-list/mcq-question-answer-list.component';
import { McqQuestionAnswerDetailComponent } from './mcq-question-answer-detail/mcq-question-answer-detail.component';



@NgModule({
  declarations: [
    McqQuestionAnswerListComponent,
    McqQuestionAnswerDetailComponent
  ],
  imports: [
    CommonModule,
    McqQuestionAnswerRoutingModule
  ]
})
export class McqQuestionAnswerModule { }
