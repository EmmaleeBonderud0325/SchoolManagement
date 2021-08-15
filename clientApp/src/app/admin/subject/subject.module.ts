import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SubjectRoutingModule } from './subject-routing.module';
import { SubjectListComponent } from './subject-list/subject-list.component';
import { SubjectDetailComponent } from './subject-detail/subject-detail.component';



@NgModule({
  declarations: [
    SubjectListComponent,
    SubjectDetailComponent
  ],
  imports: [
    CommonModule,
    SubjectRoutingModule
  ]
})
export class SubjectModule { }
