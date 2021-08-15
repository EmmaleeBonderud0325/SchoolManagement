import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AcademicYearRoutingModule } from './academic-year-routing.module';
import { AcademicYearListComponent } from './academic-year-list/academic-year-list.component';
import { AcademicYearDetailComponent } from './academic-year-detail/academic-year-detail.component';



@NgModule({
  declarations: [
    AcademicYearListComponent,
    AcademicYearDetailComponent
  ],
  imports: [
    CommonModule,
    AcademicYearRoutingModule
  ]
})
export class AcademicYearModule { }
