import { Injectable } from '@angular/core';
 
@Injectable()
export class questionModel{
    id : number;
    lessonId : number;
    lessonName : string;
    topicId : number;
    topicName :string;
    sequenceNo : number;
    questionText : string;
    marks : number;
    difficultyLevel : number;
    difficultyLevelName : String;
    questionType : number;
    questionTypeName : string;
    isActive : boolean;    
    CreatedById : number;
    CreatedByName : string;
    UpdateOn : Date;
    UpdatedById : number;
    UpdatedByName : string;
}