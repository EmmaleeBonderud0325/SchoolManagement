import { Injectable } from '@angular/core';

export class LessonModel
{
    id:number;
    name:string;
    description:string;

    academicLevelId:number;
    ClassNameId:number;
    AcademicYearId:number;
    SubjectId:number;
    LearningOutcome:string;
    PlannedDate:Date;
    CompletedDate:Date 
        
}