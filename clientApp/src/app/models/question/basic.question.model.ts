import { Injectable } from '@angular/core';
 
@Injectable()
export class BasicQuestionModel{
    id : number;
    lessonId : number;
    lessonName : string;
    topicId : number;
    topicName :string;
}