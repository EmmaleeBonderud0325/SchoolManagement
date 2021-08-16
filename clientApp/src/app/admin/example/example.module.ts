import { ExampleRoutingModule } from './example-routing.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ExampleListComponent } from './example-list/example-list.component';
import { ExampleDetailComponent } from './example-detail/example-detail.component';



@NgModule({
  declarations: [
    ExampleListComponent,
    ExampleDetailComponent
  ],
  imports: [
    CommonModule,
    ExampleRoutingModule
  ]
})
export class ExampleModule { }
