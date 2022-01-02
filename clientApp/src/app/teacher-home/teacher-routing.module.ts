import { QuestionListComponent } from './question/question-list/question-list.component';
/* import { LessonsComponent } from './lessons/lessons.component';
import { LessonDetailComponent } from './lesson-detail/lesson-detail.component'; */
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


const routes: Routes = [
  {
    path: '',
    redirectTo: 'lesson',
    pathMatch: 'full',
  },
  {
    path: 'lessons',
    loadChildren:() =>
          import('./lesson/lesson.module').then((m)=>m.LessonModule)
  },

  {
    path: '',
    redirectTo: 'essay-answer',
    pathMatch: 'full',
  },
  {
    path: 'essay-answer',
    loadChildren:() =>
          import('./essay-answer/essay-answer.module').then((m)=>m.EssayAnswerModule)
  },

  {
    path: '',
    redirectTo: 'essay-student-answwer',
    pathMatch: 'full',
  },
  {
    path: 'essay-student-answer',
    loadChildren:() =>
          import('./essay-student-answer/essay-student-answer.module').then((m)=>m.EssayStudentAnswerModule)
  },

  {
    path: '',
    redirectTo: 'lesson-assignment',
    pathMatch: 'full',
  },
  {
    path: 'lesson-assignment',
    loadChildren:() =>
          import('./lesson-assignment/lesson-assignment.module').then((m)=>m.LessonAssignmentModule)
  },

  {
    path: '',
    redirectTo: 'lesson-assignment-submission',
    pathMatch: 'full',
  },
  {
    path: 'lesson-assignment-submission',
    loadChildren:() =>
          import('./lesson-assignment-submission/lesson-assignment-submission.module').then((m)=>m.LessonAssignmentSubmissionModule)
  },


  //question 
  {
    path: '',
    redirectTo: 'question',
    pathMatch: 'full',
  },
  {
    path: 'question',
    loadChildren:() =>
          import('./question/question.module').then((m)=>m.QuestionModule)
  },


  //mcq-question-answer
  {
    path: '',
    redirectTo: 'mcq-question-answer',
    pathMatch: 'full',
  },
  {
    path: 'mcq-question-answer',
    loadChildren:() =>
          import('./mcq-question-answer/mcq-question-answer.module').then((m)=>m.McqQuestionAnswerModule)
  },


  //mcq-question-student-answer
  {
    path: '',
    redirectTo: 'mcq-question-student-answer',
    pathMatch: 'full',
  },
  {
    path: 'mcq-question-student-answer',
    loadChildren:() =>
          import('./mcq-question-student-answer/mcq-question-student-answer.module').then((m)=>m.McqQuestionStudentAnswerModule)
  },

  //student-mcq-question
  {
    path: '',
    redirectTo: 'student-mcq-question',
    pathMatch: 'full',
  },
  {
    path: 'student-mcq-question',
    loadChildren:() =>
          import('./student-mcq-question/student-mcq-question.module').then((m)=>m.StudentMcqQuestionModule)
  },
  
  
];
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class TeacherHomeRoutingModule {}