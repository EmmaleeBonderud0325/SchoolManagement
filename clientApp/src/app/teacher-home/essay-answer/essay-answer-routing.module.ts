import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { EssayAnswerListComponent } from './essay-answer-list/essay-answer-list.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'essay-answer',
    pathMatch: 'full',
  },
  {
    path: 'essay-answer',
    component:EssayAnswerListComponent,
  },
  //{
   // path: 'mcq-question-answer-detail',
   // component: McqQuestionAnswerDetailComponent,
 // },
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ]
})
export class EssayAnswerRoutingModule { }
