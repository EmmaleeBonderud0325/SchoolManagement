import { TeacherHomeRoutingModule } from './teacher-routing.module'; 
import { PerfectScrollbarModule } from 'ngx-perfect-scrollbar';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LessonsComponent } from './lessons/lessons.component';
import { LessonDetailComponent } from './lesson-detail/lesson-detail.component';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { QuestionListComponent } from './question-list/question-list.component';
import { QuestionDetailComponent } from './question-detail/question-detail.component';
import { EssayAnswerListComponent } from './essay-answer-list/essay-answer-list.component';
import { EssayAnswerDetailComponent } from './essay-answer-detail/essay-answer-detail.component';

@NgModule({
  declarations: [
    LessonsComponent,
    LessonDetailComponent,
    EssayAnswerListComponent,
    EssayAnswerDetailComponent,


    LessonDetailComponent,
    QuestionListComponent,
    QuestionDetailComponent,
    
  ],
  imports: [
    CommonModule,
    NgbModule,
    TeacherHomeRoutingModule,
    PerfectScrollbarModule,
    NgxDatatableModule,
    
  ]
})
export class TeacherHomeModule { }
