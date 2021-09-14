
import { SubjectTeacherListComponent } from "./subject-teacher-list/subject-teacher-list.component";
import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

const routes: Routes = [
    {
        path: '',
        redirectTo: 'subject-teachers',
        pathMatch: 'full',
    },
    {
        path: 'subject-teachers',
        component: SubjectTeacherListComponent,
    }
];


@NgModule({
    declarations: [],
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class SubjectTeacherRoutingModule { }