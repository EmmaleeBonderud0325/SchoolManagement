import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SubjectTeacherListComponent } from './subject-teacher-list/subject-teacher-list.component';
import { SubjectTeacherRoutingModule } from "./subject-teacher-routing.module";
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MultiSelectModule } from 'primeng/multiselect';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { TableModule } from 'primeng/table';
import { ToastrModule } from 'ngx-toastr';


@NgModule({
  declarations: [
    SubjectTeacherListComponent
  ],
  imports: [

    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MultiSelectModule,
    NgxDatatableModule,
    TableModule,
    SubjectTeacherRoutingModule,
    ToastrModule.forRoot(),

  ]
})
export class SubjectTeacherModule { }
