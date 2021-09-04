import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LessonAssignmentListComponent } from './lesson-assignment-list/lesson-assignment-list.component';
import { RouterModule, Routes } from '@angular/router';



 const routes: Routes = [
  {
    path: '',
    redirectTo: 'lesson-assignment',
    pathMatch: 'full',
  },

  {
    path: 'lesson-assignment',
    component: LessonAssignmentListComponent ,
  },

]; 

@NgModule({
  declarations: [],
    imports: [RouterModule.forChild(routes)]
    

})
export class LessonAssignmentRoutingModule { }
