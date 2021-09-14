import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

const routes: Routes = [

  {
    path: '',
    redirectTo: 'user',
    pathMatch: 'full',
  },
  {
    path: 'user',
    loadChildren: () =>
      import('./user/user.module').then((m) => m.UserModule)
  },

  {
    path: '',
    redirectTo: 'academic-level',
    pathMatch: 'full',
  },
  {
    path: 'academic-level',
    loadChildren: () =>
      import('./academic-level/academic-level.module').then((m) => m.AcademicLevelModule)
  },

  {
    path: '',
    redirectTo: 'academic-year',
    pathMatch: 'full',
  },
  {
    path: 'academic-year',
    loadChildren: () =>
      import('./academic-year/academic-year.module').then((m) => m.AcademicYearModule)
  },

  {
    path: '',
    redirectTo: 'class-name',
    pathMatch: 'full',
  },
  {
    path: 'class-name',
    loadChildren: () =>
      import('./class-name/class-name.module').then((m) => m.ClassNameModule)
  },

  {
    path: '',
    redirectTo: 'class',
    pathMatch: 'full',
  },
  {
    path: 'class',
    loadChildren: () =>
      import('./class/class.module').then((m) => m.ClassModule)
  },

  {
    path: '',
    redirectTo: 'class-teacher',
    pathMatch: 'full',
  },
  {
    path: 'class-teacher',
    loadChildren: () =>
      import('./class-teacher/class-teacher.module').then((m) => m.ClassTeacherModule)
  },

  {
    path: '',
    redirectTo: 'student',
    pathMatch: 'full',
  },
  {
    path: 'student',
    loadChildren: () =>
      import('./student/student.module').then((m) => m.StudentModule)
  },

  {
    path: '',
    redirectTo: 'subject',
    pathMatch: 'full',
  },
  {
    path: 'subject',
    loadChildren: () =>
      import('./subject/subject.module').then((m) => m.SubjectModule)
  },
  {
    path: '',
    redirectTo: 'subject-teacher',
    pathMatch: 'full',
  },
  {
    path: 'subject-teacher',
    loadChildren: () =>
      import('./subject-teacher/subject-teacher.module').then((m) => m.SubjectTeacherModule)
  },

  {
    path: '',
    redirectTo: 'head-of-department',
    pathMatch: 'full',
  },
  {
    path: 'head-of-department',
    loadChildren: () =>
          import('./head-of-department/head-of-department.module').then((m) => m.HeadOfDepartmentModule)
  },

  {
    path: '',
    redirectTo: 'example',
    pathMatch: 'full',
  },
  {
    path: 'example',
    loadChildren: () =>
      import('./example/example.module').then((m) => m.ExampleModule)
  },


];

@NgModule({
  declarations: [],
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AdminRoutingModule { }
