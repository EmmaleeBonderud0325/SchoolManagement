import { Injectable } from '@angular/core';

@Injectable()
export class BasicLessonModel
{
    lessonName:string;
    description:string;
    academicLevelId:number; 
    classNameId:number;
    scademicYearId:number;
    subjectId:number;
}