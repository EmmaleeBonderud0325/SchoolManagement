import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ClassNameRoutingModule } from './class-name-routing.module';
import { ClassNameListComponent } from './class-name-list/class-name-list.component';
import { ClassNameDetailComponent } from './class-name-detail/class-name-detail.component';



@NgModule({
  declarations: [
    ClassNameListComponent,
    ClassNameDetailComponent
  ],
  imports: [
    CommonModule,
    ClassNameRoutingModule
  ]
})
export class ClassNameModule { }
