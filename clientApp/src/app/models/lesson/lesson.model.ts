import { Injectable } from '@angular/core';

export class LessonModel
{
    id:number;
    name:string;
    description:string;

    academicLevelId:number;
    classNameId:number;
    academicYearId:number;
    subjectId:number;
    learningOutcome:string;
    plannedDate:Date;
    completedDate:Date 
        
}