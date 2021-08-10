import { ClassNameDetailComponent } from './class-name-detail/class-name-detail.component';
import { ClassNameListComponent } from './class-name-list/class-name-list.component';
import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'classe-names',
    pathMatch: 'full',
  },
  {
    path: 'classe-names',
    component: ClassNameListComponent,
  },
  {
    path: 'classes-detail',
    component: ClassNameDetailComponent,
  },
];


@NgModule({
  declarations: [],
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ClassNameRoutingModule { }
