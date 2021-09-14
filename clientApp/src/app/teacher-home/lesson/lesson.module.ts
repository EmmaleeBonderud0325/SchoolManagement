import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LessonRoutingModule } from './lesson-routing.module';
import { LessonDetailComponent } from './lesson-detail/lesson-detail.component';
import { LessonListComponent } from './lesson-list/lesson-list.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { ToastrModule } from 'ngx-toastr';
import { CalendarModule } from 'primeng/calendar';



@NgModule({
  declarations: [
    LessonDetailComponent,
    LessonListComponent
  ],
  imports: [
    CommonModule,
    LessonRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    NgxDatatableModule,
    CalendarModule,
    ToastrModule.forRoot(),
  ]
})
export class LessonModule { }
