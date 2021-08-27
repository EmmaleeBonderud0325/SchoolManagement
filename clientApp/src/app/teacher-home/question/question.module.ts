import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { QuestionRoutingModule } from './question-routing.module';
//import { QuestionComponent } from './question/question.component';
import { QuestionListComponent } from './question-list/question-list.component';
import { QuestionDetailComponent } from './question-detail/question-detail.component';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';



@NgModule({
  declarations: [
    //QuestionComponent,
    QuestionListComponent,
    QuestionDetailComponent
  ],
  imports: [
    CommonModule,
    QuestionRoutingModule,
    NgxDatatableModule,
  ]
})
export class QuestionModule { }
