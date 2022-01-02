import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ClassNameRoutingModule } from './class-name-routing.module';
import { ClassNameListComponent } from './class-name-list/class-name-list.component';
import { ClassNameDetailComponent } from './class-name-detail/class-name-detail.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { ToastrModule } from 'ngx-toastr';



@NgModule({
  declarations: [
    ClassNameListComponent,
    ClassNameDetailComponent
  ],
  imports: [
    CommonModule,
    ClassNameRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    NgxDatatableModule,
    ToastrModule.forRoot(),
  ]
})
export class ClassNameModule { }
