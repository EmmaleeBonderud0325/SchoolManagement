import { Injectable } from '@angular/core';
 
@Injectable()
export class BasicMCQQuestionAnswerModel{    
    id : number;
    questionId : number;
    questionName : string;
    answerText : string;
    sequenceNo : number;
    modifiedDate : Date;
    createdOn : Date;
}