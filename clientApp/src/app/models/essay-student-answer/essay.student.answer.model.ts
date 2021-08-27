
import { Injectable } from '@angular/core';

@Injectable()
export class EssayStudentAnswerModel{
  questionId :number ;
  studentId :number;
  essayQuestionAnwserId :number;
  answerText:string;
  teacherComments: string;
  marks: number;
}

