import { ToastModule } from 'primeng/toast';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeadOfDepartmentListComponent } from './head-of-department-list/head-of-department-list.component';
import { HeadOfDepartmentDetailComponent } from './head-of-department-detail/head-of-department-detail.component';
import { HeadOfDepartmentRoutingModule } from './head-of-department-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { ToastrModule } from 'ngx-toastr';



@NgModule({
  declarations: [
    HeadOfDepartmentListComponent,
    HeadOfDepartmentDetailComponent
  ],
  imports: [
    CommonModule,
    HeadOfDepartmentRoutingModule,
    HeadOfDepartmentRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    NgxDatatableModule,
    ToastModule,
    ToastrModule.forRoot()
  ]
})
export class HeadOfDepartmentModule { }
