import { Injectable } from '@angular/core';
 
@Injectable()
export class mcqquestionanswerModel{
    id : number;
    questionId : number;
    questionName : string;
    answerText : string;
    sequenceNo : number;
    isCorrectAnswer : boolean;
    modifiedDate : Date;
    createdOn : Date;
}