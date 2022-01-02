import { Injectable } from '@angular/core';
 
@Injectable()
export class BasicStudentMCQQuestionAnswerModel{
    questionId : number;
    questionName : string;
    studentAnswerText : string;
    studentId : number;
    studentName : string;
    teacherComments : string;
    marks : number;
    isCorrectAnswer : boolean;
}