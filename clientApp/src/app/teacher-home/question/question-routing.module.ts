import { QuestionDetailComponent } from './question-detail/question-detail.component';
import { QuestionListComponent } from './question-list/question-list.component';
import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'questions',
    pathMatch: 'full',
  },
  {
    path: 'questions',
    component: QuestionListComponent,
  },
  {
    path: 'question-detail',
    component: QuestionDetailComponent,
  },
];

@NgModule({
  declarations: [],
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class QuestionRoutingModule { }
