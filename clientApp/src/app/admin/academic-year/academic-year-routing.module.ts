import { AcademicYearDetailComponent } from './academic-year-detail/academic-year-detail.component';
import { AcademicYearListComponent } from './academic-year-list/academic-year-list.component';
import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'academic-years',
    pathMatch: 'full',
  },
  {
    path: 'academic-levels',
    component: AcademicYearListComponent,
  },
  {
    path: 'academic-year-detail',
    component: AcademicYearDetailComponent,
  },
];


@NgModule({
  declarations: [],
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AcademicYearRoutingModule { }
