import { Injectable } from '@angular/core';
 
@Injectable()
export class questionModel{
    id : number;
    questionName : string;
    lessonId : number;
    lessonName : string;
    topicId : number;
    topicName :string;
    sequenceNo : number;
    questionText : string;
    marks : number;
    difficultyLevel : number;
    questionType : number;
    isActive : boolean;
}