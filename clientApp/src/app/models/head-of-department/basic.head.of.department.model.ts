import { Injectable } from '@angular/core';

@Injectable()
export class BasicHeadOfDepartmentModel
{
    id:number;
    subjectId:number; 
    academicYearId:number;
    academicLevelId:number;
    teacherId:number;
    academicLevelName:string;
    teacherName:string;
    subjectName:string;
    createdByName:string;
    createOn:Date;
    updateOn:Date;
    updatedByName:string; 
}