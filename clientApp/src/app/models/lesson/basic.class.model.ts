import { Injectable } from '@angular/core';

@Injectable()
export class BasicLessonModel
{
    LessonName:string;
    Description:string;
    AcademicLevelId:number; 
    ClassNameId:number;
    AcademicYearId:number;
    SubjectId:number;
}