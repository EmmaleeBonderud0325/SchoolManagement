
import { Injectable } from '@angular/core';

@Injectable()
export class EssayStudentAnswerModel{
  questionId :number ;
  questionName :string ;
  studentId :number;
  studentName :string;
  essayQuestionAnwserId :number;
  essayQuestionAnwserName :string;
  answerText:string;
  teacherComments: string;
  marks: number;
}

