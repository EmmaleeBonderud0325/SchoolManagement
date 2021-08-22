import { Injectable } from '@angular/core';
 
@Injectable()
export class questionModel{
    id : number;
    lessonId : number;
    topicId : number;
    sequenceNo : number;
    questionText : string;
    marks : number;
    difficultyLevel : number;
    questionType : number;
    isActive : boolean;
}