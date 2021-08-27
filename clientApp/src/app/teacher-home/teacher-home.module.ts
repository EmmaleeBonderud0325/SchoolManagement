import { TeacherHomeRoutingModule } from './teacher-routing.module'; 
import { PerfectScrollbarModule } from 'ngx-perfect-scrollbar';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LessonsComponent } from './lessons/lessons.component';
import { LessonDetailComponent } from './lesson-detail/lesson-detail.component';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
//import { QuestionListComponent } from './question-list/question-list.component';
import { QuestionDetailComponent } from './question-detail/question-detail.component';

//import { EssayAnswerDetailComponent } from './essay-answer-detail/essay-answer-detail.component';
//import { EssayStudentAnswerListComponent } from './essay-student-answer-list/essay-student-answer-list.component';
//import { EssayStudentAnswerDetailComponent } from './essay-student-answer-detail/essay-student-answer-detail.component';
//import { LessonAssignmentListComponent } from './lesson-assignment/lesson-assignment-list/lesson-assignment-list.component';
import { NgxMaskModule } from 'ngx-mask';
import { NgSelectModule } from '@ng-select/ng-select';
import { CKEditorModule } from '@ckeditor/ckeditor5-angular';
import { ArchwizardModule } from 'angular-archwizard';
import { CustomFormsModule } from 'ngx-custom-validators';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [

    LessonsComponent,
    LessonDetailComponent,
    LessonDetailComponent,

    
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
