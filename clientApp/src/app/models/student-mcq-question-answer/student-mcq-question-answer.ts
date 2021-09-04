import { Injectable } from '@angular/core';

@Injectable()
export class StudentMcqQuestionAnswerModel {
    questionId : number;
    studentId : number;
    teacherComments : string;
    marks : number;
    isCorrectAnswer : boolean;
}


        