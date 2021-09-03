import { McqQuestionAnswerDetailComponent } from './mcq-question-answer-detail/mcq-question-answer-detail.component';
import { McqQuestionAnswerListComponent } from './mcq-question-answer-list/mcq-question-answer-list.component';
import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';





const routes: Routes = [
  {
    path: '',
    redirectTo: 'mcq-question-answers',
    pathMatch: 'full',
  },
  {
    path: 'mcq-question-answers',
    component: McqQuestionAnswerListComponent,
  },
  {
    path: 'mcq-question-answer-detail',
    component: McqQuestionAnswerDetailComponent,
  },
];
@NgModule({
  declarations: [],
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})


export class McqQuestionAnswerRoutingModule { }
