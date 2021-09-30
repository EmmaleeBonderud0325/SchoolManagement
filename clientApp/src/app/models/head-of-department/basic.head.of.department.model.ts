import { Injectable } from '@angular/core';

@Injectable()
export class BasicHeadOfDepartmentModel
{
    id:number; 
    academicYearId:number;
    academicLevelName:string;
    teacherName:string;
    subjectName:string;
    createdByName:string;
    createOn:Date;
    updateOn:Date;
    updatedByName:string; 
}