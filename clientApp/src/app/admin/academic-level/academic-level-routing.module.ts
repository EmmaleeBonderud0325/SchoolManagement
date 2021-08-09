import { AcademicLevelDetailComponent } from './academic-level-detail/academic-level-detail.component';
import { AcademicLevelListComponent } from './academic-level-list/academic-level-list.component';
import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'academic-levels',
    pathMatch: 'full',
  },
  {
    path: 'academic-levels',
    component: AcademicLevelListComponent,
  },
  {
    path: 'academic-level-detail',
    component: AcademicLevelDetailComponent,
  },
];

@NgModule({
  declarations: [],
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AcademicLevelRoutingModule { }
