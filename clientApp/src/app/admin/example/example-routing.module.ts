import { ExampleDetailComponent } from './example-detail/example-detail.component';
import { ExampleListComponent } from './example-list/example-list.component';
import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'examples',
    pathMatch: 'full',
  },
  {
    path: 'examples',
    component: ExampleListComponent,
  },
  {
    path: 'example-detail',
    component: ExampleDetailComponent,
  },
];

@NgModule({
  declarations: [],
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ExampleRoutingModule { }
