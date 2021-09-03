import { CustomFormsModule } from 'ngx-custom-validators';
import { NgSelectModule } from '@ng-select/ng-select';
import { TeacherHomeRoutingModule } from './teacher-routing.module'; 
import { LessonsComponent } from './lessons/lessons.component';
import { LessonDetailComponent } from './lesson-detail/lesson-detail.component';
import { CommonModule } from '@angular/common';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgModule } from '@angular/core';
import { PerfectScrollbarModule } from 'ngx-perfect-scrollbar';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { NgxMaskModule } from 'ngx-mask';
import { CKEditorModule } from '@ckeditor/ckeditor5-angular';
import { ArchwizardModule } from 'angular-archwizard';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
//import { EssayAnswerListComponent } from './essay-answer/essay-answer-list/essay-answer-list.component';


//import { QuestionListComponent } from './question/question-list/question-list.component';
//import { QuestionDetailComponent } from './question/question-detail/question-detail.component';


@NgModule({
  declarations: [

    LessonsComponent,
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
