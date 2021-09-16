import { Injectable } from '@angular/core';

@Injectable()
export class BasicLessonModel
{
    id:number;
    lessonName:string;
    description:string;
    academicLevelId:string; 
    className:string;
    scademicYearId:number;
    subjectName:string;
}