import { MultiSelectModule } from 'primeng/multiselect';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ClassRoutingModule } from './class-routing.module';
import { ClassDetailComponent } from './class-detail/class-detail.component';
import { ClassListComponent } from './class-list/class-list.component';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { ToastrModule } from 'ngx-toastr';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    ClassDetailComponent,
    ClassListComponent
  ],
  imports: [
    CommonModule,
    ClassRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    MultiSelectModule,
    NgxDatatableModule,
    ToastrModule.forRoot(),
  ]
})
export class ClassModule { }
