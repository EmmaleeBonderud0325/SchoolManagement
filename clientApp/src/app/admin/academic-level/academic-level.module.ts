import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AcademicLevelRoutingModule } from './academic-level-routing.module';
import { AcademicLevelListComponent } from './academic-level-list/academic-level-list.component';
import { AcademicLevelDetailComponent } from './academic-level-detail/academic-level-detail.component';



@NgModule({
  declarations: [
    AcademicLevelListComponent,
    AcademicLevelDetailComponent
  ],
  imports: [
    CommonModule,
    AcademicLevelRoutingModule
  ]
})
export class AcademicLevelModule { }
