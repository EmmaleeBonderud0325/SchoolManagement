import { Injectable } from '@angular/core';
 
@Injectable()
export class BasicMCQQuestionStudentAnswerModel{
    questionId : number;
    questionName : string;
    studentId : number;
    studentName : string;
    mCQQuestionAnswerId : number;
    mCQQuestionAnswerName : string;
    answerText : string;
    sequnceNo : number;
    isChecked : boolean;
}