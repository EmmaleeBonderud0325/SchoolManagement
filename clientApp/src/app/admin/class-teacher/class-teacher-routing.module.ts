import { ClassTeacherDetailComponent } from './class-teacher-detail/class-teacher-detail.component';
import { ClassTeacherListComponent } from './class-teacher-list/class-teacher-list.component';
import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

const routes: Routes = [
    {
      path: '',
      redirectTo: 'class-teachers',
      pathMatch: 'full',
    },
    {
        path: 'class-teachers',
        component: ClassTeacherListComponent,
    },
    {
        path: 'class-teacher-detail',
        component: ClassTeacherDetailComponent,
    },
];

@NgModule({
    declarations: [],
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
  })
  export class ClassTeacherRoutingModule { }