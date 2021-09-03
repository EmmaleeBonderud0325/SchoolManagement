
import { CommonModule } from '@angular/common';
import { EssayAnswerRoutingModule } from './essay-answer-routing.module';
import { EssayAnswerListComponent } from './essay-answer-list/essay-answer-list.component';
import {MultiSelectModule} from 'primeng/multiselect';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ToastrModule } from 'ngx-toastr';
import { NgModule } from '@angular/core';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';


@NgModule({
  declarations: [
    EssayAnswerListComponent

  ],
  imports: [
    CommonModule,
    EssayAnswerRoutingModule,
    MultiSelectModule,
    FormsModule,
    ReactiveFormsModule,
    NgxDatatableModule,
    ToastrModule.forRoot(),
  ]
})
export class EssayAnswerModule { }
