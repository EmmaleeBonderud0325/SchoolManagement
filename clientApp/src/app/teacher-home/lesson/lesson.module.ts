import { CKEditorModule } from '@ckeditor/ckeditor5-angular';
import { TableModule } from 'primeng/table';
import { MultiSelectModule } from 'primeng/multiselect';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LessonRoutingModule } from './lesson-routing.module';
import { LessonDetailComponent } from './lesson-detail/lesson-detail.component';
import { LessonListComponent } from './lesson-list/lesson-list.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { ToastrModule } from 'ngx-toastr';
import { CalendarModule } from 'primeng/calendar';
import{LessonContentComponent} from './lesson-content/lesson-content.component'
import { NgbProgressbarModule } from '@ng-bootstrap/ng-bootstrap';
import { InputSwitchModule } from 'primeng/inputswitch';
import {ListboxModule} from 'primeng/listbox';
import { ButtonModule } from 'primeng/button';
import { LessonContainerComponent } from './lesson-container/lesson-container.component';
import { LessonTopicComponent } from './lesson-topic/lesson-topic.component';
import { LessonTopicContentComponent } from './lesson-topic-content/lesson-topic-content.component';
import { EditorModule } from 'primeng/editor';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { PanelModule } from 'primeng/panel';
import { MenuModule } from 'primeng/menu';

@NgModule({
  declarations: [
    LessonDetailComponent,
    LessonListComponent,
    LessonContentComponent,
    LessonContainerComponent,
    LessonTopicComponent,
    LessonTopicContentComponent
  ],
  imports: [
    CommonModule,
    LessonRoutingModule,
    CommonModule,
    NgbProgressbarModule,
    FormsModule,
    MultiSelectModule,
    ReactiveFormsModule,
    CalendarModule,
    InputSwitchModule,
    TableModule,
    ListboxModule,
    ButtonModule,
    CKEditorModule,
    EditorModule,
    NgbModule,
    PanelModule,
    MenuModule,
    NgxDatatableModule,
    ToastrModule.forRoot(),
  ]
})
export class LessonModule { }
