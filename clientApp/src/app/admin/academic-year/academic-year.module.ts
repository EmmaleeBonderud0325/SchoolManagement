import { ToastModule } from 'primeng/toast';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AcademicYearRoutingModule } from './academic-year-routing.module';
import { AcademicYearListComponent } from './academic-year-list/academic-year-list.component';
import { AcademicYearDetailComponent } from './academic-year-detail/academic-year-detail.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { ToastrModule } from 'ngx-toastr';



@NgModule({
  declarations: [
    AcademicYearListComponent,
    AcademicYearDetailComponent
  ],
  imports: [
    CommonModule,
    AcademicYearRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    NgxDatatableModule,
    ToastModule,
    ToastrModule.forRoot(),
  ]
})
export class AcademicYearModule { }
