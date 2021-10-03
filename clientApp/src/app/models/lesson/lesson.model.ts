import { Injectable } from '@angular/core';
import { LessonDetailModel } from "../lesson/lesson.detail.model";
import { LessonTopicModel } from './lesson.topic.model';

export class LessonModel
{
    id:number;
    lessonDetail:LessonDetailModel
    topics:LessonTopicModel[]; 
     
}