import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AcademicLevelRoutingModule } from './academic-level-routing.module';
import { AcademicLevelListComponent } from './academic-level-list/academic-level-list.component';
import { AcademicLevelDetailComponent } from './academic-level-detail/academic-level-detail.component';
import { ToastrModule } from 'ngx-toastr';



@NgModule({
  declarations: [
    AcademicLevelListComponent,
    AcademicLevelDetailComponent
  ],
  imports: [
    CommonModule,
    AcademicLevelRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    NgxDatatableModule,
    ToastrModule.forRoot(),
  ]
})
export class AcademicLevelModule { }
