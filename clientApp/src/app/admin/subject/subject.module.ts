import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SubjectRoutingModule } from './subject-routing.module';
import { SubjectListComponent } from './subject-list/subject-list.component';
import { SubjectDetailComponent } from './subject-detail/subject-detail.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { ToastrModule } from 'ngx-toastr';
import {MultiSelectModule} from 'primeng/multiselect';


@NgModule({
  declarations: [
    SubjectListComponent,
    SubjectDetailComponent
  ],
  imports: [
    CommonModule,
    SubjectRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    NgxDatatableModule,
    MultiSelectModule,
    ToastrModule.forRoot(),
  ]
})
export class SubjectModule { }
