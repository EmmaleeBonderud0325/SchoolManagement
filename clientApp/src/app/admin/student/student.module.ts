import { StudentRoutingModule } from './student-routing.module';
import { StudentListComponent } from './student-list/student-list.component';
import { StudentDetailComponent } from './student-detail/student-detail.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { ToastrModule } from 'ngx-toastr';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';



@NgModule({
  declarations: [
    StudentListComponent,
    StudentDetailComponent
  ],
  imports: [
    CommonModule,
    StudentRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    NgxDatatableModule,
    ToastrModule.forRoot(),
  ]
})
export class StudentModule { }
