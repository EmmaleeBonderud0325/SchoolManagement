import { Injectable } from '@angular/core';

@Injectable()
export class LessonContentModel
{
    id:number;
    topicId:number;
    introduction:string;
    content:string;
    
}