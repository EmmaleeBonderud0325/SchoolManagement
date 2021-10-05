import { Injectable } from '@angular/core';

@Injectable()
export class BasicEssayStudentAnswerModel{
  questionId :number ;
  questionName :string ;
  studentId :number;
  studentName :string;
  essayQuestionAnswerId:number;
  essayQuestionAnswerName :string;
  answerText:string;
  teacherComments: string;
  marks: number;
}