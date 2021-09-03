import { EssayAnswerListComponent } from './essay-answer-list/essay-answer-list.component';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { CustomFormsModule } from 'ngx-custom-validators';
import { ArchwizardModule } from 'angular-archwizard';
import { CKEditorModule } from '@ckeditor/ckeditor5-angular';
import { NgSelectModule } from '@ng-select/ng-select';
import { NgxMaskModule } from 'ngx-mask';
import { TeacherHomeRoutingModule } from './teacher-routing.module'; 
import { PerfectScrollbarModule } from 'ngx-perfect-scrollbar';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LessonsComponent } from './lessons/lessons.component';
import { LessonDetailComponent } from './lesson-detail/lesson-detail.component';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
//import { EssayAnswerListComponent } from './essay-answer/essay-answer-list/essay-answer-list.component';
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
    //EssayAnswerListComponent,
    
  ],
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
