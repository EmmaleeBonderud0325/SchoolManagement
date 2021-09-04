import { Injectable } from '@angular/core';
 
@Injectable()
export class McqQuestionStudentAnswerModel{
    questionId : number;
    studentId : number;
    mCQQuestionAnswerId : number;
    answerText : string;
    sequnceNo : number;
}