import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { CustomFormsModule } from 'ngx-custom-validators';
import { ArchwizardModule } from 'angular-archwizard';
import { CKEditorModule } from '@ckeditor/ckeditor5-angular';
import { NgSelectModule } from '@ng-select/ng-select';
import { NgxMaskModule } from 'ngx-mask';
//import { QuestionDetailComponent } from './question-detail/question-detail.component';
//import { QuestionListComponent } from './question-list/question-list.component';
import { TeacherHomeRoutingModule } from './teacher-routing.module'; 
import { PerfectScrollbarModule } from 'ngx-perfect-scrollbar';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LessonsComponent } from './lessons/lessons.component';
import { LessonDetailComponent } from './lesson-detail/lesson-detail.component';

//import { EssayAnswerListComponent } from './essay-answer-list/essay-answer-list.component';
//import { EssayAnswerDetailComponent } from './essay-answer-detail/essay-answer-detail.component';
import { McqQuestionAnswerListComponent } from './mcq-question-answer/mcq-question-answer-list/mcq-question-answer-list.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    LessonsComponent,
    LessonDetailComponent,
    McqQuestionAnswerListComponent,
    //EssayAnswerListComponent,
    //EssayAnswerDetailComponent,
    //QuestionListComponent,
    //QuestionDetailComponent,

    
    
  ],
  imports: [
    CommonModule,
    NgbModule,
    TeacherHomeRoutingModule,
    PerfectScrollbarModule,
    NgxDatatableModule,

  
    
    NgxMaskModule.forRoot(),
    NgSelectModule,
    CKEditorModule,
    ArchwizardModule,
    CustomFormsModule,
    FormsModule,
    ReactiveFormsModule,
    
  ]
})
export class TeacherHomeModule { }
