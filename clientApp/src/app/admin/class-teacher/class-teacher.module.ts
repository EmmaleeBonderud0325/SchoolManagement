import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ClassTeacherRoutingModule } from './class-teacher-routing.module';
import { ClassTeacherListComponent } from './class-teacher-list/class-teacher-list.component';
import { ClassTeacherDetailComponent } from './class-teacher-detail/class-teacher-detail.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ToastrModule } from 'ngx-toastr';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';

@NgModule({
    declarations: [
      ClassTeacherListComponent,
      ClassTeacherDetailComponent
    ],
    imports: [
      CommonModule,
      ClassTeacherRoutingModule,
      FormsModule,
      ReactiveFormsModule,
      NgxDatatableModule,
      ToastrModule.forRoot(),
    ]
  })
  export class ClassTeacherModule { }