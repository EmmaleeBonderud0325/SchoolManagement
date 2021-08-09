import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ClassRoutingModule } from './class-routing.module';
import { ClassDetailComponent } from './class-detail/class-detail.component';
import { ClassListComponent } from './class-list/class-list.component';



@NgModule({
  declarations: [
    ClassDetailComponent,
    ClassListComponent
  ],
  imports: [
    CommonModule,
    ClassRoutingModule
  ]
})
export class ClassModule { }
